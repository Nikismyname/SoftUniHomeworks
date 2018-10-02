namespace SIS.HTTP.Responces
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Extentions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Responces.Contracts;
    using System.Text;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public IHttpCookieCollection Cookies { get; }

        public byte[] Content { get; set; }

        public byte[] GetBytes()
        {
            ///TODO: Might wanna fix the GetBytes
            
            var responseWithoutContent = Encoding.UTF8.GetBytes(this.ToString());
            var result = new byte[responseWithoutContent.Length + this.Content.Length];
            for (int i = 0; i < responseWithoutContent.Length; i++)
            {
                result[i] = responseWithoutContent[i];
            }

            for (int i = responseWithoutContent.Length; i < responseWithoutContent.Length + this.Content.Length; i++)
            {
                result[i] = this.Content[i - responseWithoutContent.Length];
            }

            return result;
        }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public void AddCookie(HttpCookie cookie)
        {
            this.Cookies.Add(cookie);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            ///TODO: might need to fix the string builder
            sb.AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}");
            sb.AppendLine(this.Headers.ToString());
            if (this.Cookies.HasCookies())
            {
                sb.AppendLine($"Set-Cookie: {this.Cookies.ToString()}");
            }
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
