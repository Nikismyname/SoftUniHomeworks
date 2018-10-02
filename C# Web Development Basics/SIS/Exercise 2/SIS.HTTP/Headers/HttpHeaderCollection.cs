namespace SIS.HTTP.Headers
{
    using SIS.HTTP.Headers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (header == null
                || string.IsNullOrWhiteSpace(header.Key)
                || string.IsNullOrEmpty(header.Value))
            {
                throw new Exception($"Header is not valid!");
            }

            //TODO: what if we get headers with same key? 
            this.headers[header.Key] = header;
        }

        public bool ContainsHeader(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new Exception("Invalid key ckecked if it is contained!");
            }

            var result = this.headers.ContainsKey(key);
            return result;
        }

        public HttpHeader GetHeader(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new Exception("Invalid key serched for!");
            }

            HttpHeader result = null;
            if (this.headers.ContainsKey(key))
            {
                result = headers[key];
            }

            return result;
        }

        public override string ToString()
        {
            var result = string.Join(Environment.NewLine, this.headers.Select(x => x.Value.ToString()));
            return result;
        }
    }
}
