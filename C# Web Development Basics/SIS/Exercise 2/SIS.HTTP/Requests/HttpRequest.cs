namespace SIS.HTTP.Requests
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Extentions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Sessions.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class HttpRequest : IHttpRequest
    {
        private const string HostHeaderKey = "Host"; 


        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        ///this was not in the tutorial
        public IHttpSession Session { get; set; }


        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string[] requestLine = splitRequestContent[0].Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            ///gets the value from this.Url
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();
            ///TODO: why is it the last line should't that be empty if split by new line 
            ///and then have a ampty line in the request
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
            ///TODO: what about ParseFormDataParameters() if it is post
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if(requestLine.Any(x=> string.IsNullOrWhiteSpace(x)))
            {
                return false;
            }

            if(requestLine.Length != 3)
            {
                return false;
            }

            var method = requestLine[0];
            var validMethod = Enum.TryParse(method.Capitalize(), out HttpRequestMethod parsedMethod);

            if(validMethod == false)
            {
                return false;
            }

            var protocol = requestLine[2];
            if(protocol != GlobalConstants.HttpOneProtocolFragment)
            {
                return false;
            }

            return true;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            if (string.IsNullOrWhiteSpace(queryString))
            {
                return false;
            }

            if (queryParameters.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var method = requestLine[0];
            ///It is already checked if the method is valid
            var validMethod = Enum.TryParse(method.Capitalize(), out HttpRequestMethod parsedMethod);
            var result = parsedMethod;
            this.RequestMethod = result;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            ///TODO: MORE
            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            ///allowed characters in path:
            ///A–Z, a–z, 0–9, -, ., _, ~, !, $, &, ', (, ), *, +, ,, ;, =, :,  @,
            ///as well as % that must be followed by two hexadecimal digits.\
            ///Any other character/byte needs to be encoded using the percent-encoding.
            ///https://stackoverflow.com/questions/4669692/valid-characters-for-directory-part-of-a-url-for-short-links
            ///catches the path, only edns on end of line, # or ?, maybe there are other options, catches
            ///unescaped symbols as well
            ///It will capture a single / but does not match if no / is present, so I will put a path of 
            ///'/' if no match is gotten.
            
            var pattern = @"((?<!\/)\/{1}(?!\/)([a-zA-Z0-9-._~!$&'()*+,;=:@]*(%[0-9A-F]{2})*)*)+(?=$|#|\?)";
            var match = Regex.Match(this.Url, pattern);
            if(match.Success == false)
            {
                this.Path = "/";
                return;
            }

            this.Path = match.Groups[0].Value;
        }

        private void ParseHeaders(string[] requestContent)
        {
            for (int i = 0; i < requestContent.Length; i++)
            {
                var line = requestContent[i];
                ///TODO: better way to check for CRLF
                if (line.Length == 0)
                {
                    break;
                }

                var tokens = line.Split(": ");
                var headerKey = tokens[0];
                var headerValue = tokens[1];
                this.Headers.Add(new HttpHeader(headerKey,headerValue));
            }

            if (!this.Headers.ContainsHeader(HostHeaderKey))
            {
                throw new BadRequestException();
            }
        }

        private void ParseQueryParameters()
        {
            var pattern = @"\?[^#]*(?=$|#)";
            var match = Regex.Match(this.Url,pattern);
            if(match.Success == false)
            {
                return;
            }

            var queryString = match.Groups[0].Value;
            var subQueries = queryString.Split("&", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < subQueries.Length; i++)
            {
                var subQueryTokens = subQueries[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                if(subQueryTokens.Length != 2)
                {
                    continue;
                }
                var key = subQueryTokens[0];
                var value = subQueryTokens[1];

                this.QueryData.Add(key,value);
            }

            if(!this.IsValidRequestQueryString(queryString, subQueries))
            {
                throw new BadRequestException();
            }
        }

        private void ParseFormDataParameters(string formData)
        {
            var paramethers = formData.Split('&',StringSplitOptions.RemoveEmptyEntries);
            foreach (var param in paramethers)
            {
                var tokens = param.Split('=',StringSplitOptions.RemoveEmptyEntries);
                if(tokens.Length != 2)
                {
                    return;
                }

                var key = tokens[0];
                var value = tokens[1];

                this.FormData.Add(key, value);
            }
        }

        private void ParseRequestParameters(string formData)
        {
            ParseQueryParameters();
            ParseFormDataParameters(formData);
        }

        private void ParseCookies()
        {
            if (this.Headers.ContainsHeader("Cookie"))
            {
                var cookieHeader = Headers.GetHeader("Cookie");
                var cookieString = cookieHeader.Value;
                var cookieTokens = cookieString.Split("=", StringSplitOptions.RemoveEmptyEntries);
                var cookieKey = cookieTokens[0];
                var cookieValue = cookieTokens[1];

                ///TODO: seting the timer for the cookie might be wrong
                var cookie = new HttpCookie(cookieKey,cookieValue, 3);
                this.Cookies.Add(cookie);
            }
        }
    }
}
