namespace SIS.WebServer.Results
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responces;

    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location): base (HttpResponseStatusCode.SeeOther)
        {
            this.Headers.Add(new HttpHeader("location", location));
        }
    }
}
