namespace SIS.HTTP.Sessions
{
    using SIS.HTTP.Sessions.Contracts;
    using System.Collections.Generic;

    public class HttpSession : IHttpSession
    {
        public HttpSession(string id)
        {
            this.Id = id;
            this.parameters = new Dictionary<string, object>();
        }   

        public string Id { get; }

        private readonly IDictionary<string, object> parameters;

        public object GetPrameter(string name)
        {
            if (!parameters.ContainsKey(name))
            {
                return null;
            }

            return parameters[name];
        }

        public void AddParameter(string name, object paramater)
        {
            this.parameters.Add(name, parameters);
        }

        public void ClearParameters()
        {
            this.parameters.Clear();
        }

        public bool ContainsParamater(string name)
        {
            return this.parameters.ContainsKey(name);
        }
    }
}
