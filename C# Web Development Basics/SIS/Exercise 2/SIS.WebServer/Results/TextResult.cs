namespace SIS.WebServer.Results
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responces;
    using System.Text;

    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpResponseStatusCode responseStatusCode) : base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type","text/plain"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
