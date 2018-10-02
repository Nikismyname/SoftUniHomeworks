namespace SIS.HTTP.Sessions.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IHttpSession
    {
        string Id { get; }

        object GetPrameter(string name);

        bool ContainsParamater(string name);

        void AddParameter(string name, object paramater);

        void ClearParameters();
    }
}
