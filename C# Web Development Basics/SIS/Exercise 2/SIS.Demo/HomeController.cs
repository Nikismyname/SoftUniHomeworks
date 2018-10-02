namespace SIS.Demo
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responces.Contracts;
    using SIS.WebServer.Results;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            var content = "<h1>Hello World</h1>";
            var result = new HtmlResult(content, HttpResponseStatusCode.Ok);
            return result;
        }
    }
}
