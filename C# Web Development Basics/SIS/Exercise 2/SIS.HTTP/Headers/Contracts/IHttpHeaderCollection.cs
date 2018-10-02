namespace SIS.HTTP.Headers.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IHttpHeaderCollection
    {
        void Add(HttpHeader header);

        bool ContainsHeader(string key);

        HttpHeader GetHeader(string key);
    }
}
