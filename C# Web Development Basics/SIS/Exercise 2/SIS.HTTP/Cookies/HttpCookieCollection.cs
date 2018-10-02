namespace SIS.HTTP.Cookies
{
    using SIS.HTTP.Cookies.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        /// probably should be a collection of cookies
        private readonly IDictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            cookies[cookie.Key] = cookie;
        }

        public bool ContainsCookie(string key)
            => this.cookies.ContainsKey(key);

        public HttpCookie GetCookie(string key)
        {
            if (!this.cookies.ContainsKey(key))
            {
                return null;
            }

            return this.cookies[key];
        }

        public bool HasCookies()
        {
            if (!this.cookies.Any())
            {
                return false; 
            }

            return true;
        }

        public override string ToString()
            => string.Join("; ", this.cookies.Values);
    }
}
