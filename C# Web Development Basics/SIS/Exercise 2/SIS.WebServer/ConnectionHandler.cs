namespace SIS.WebServer
{
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responces;
    using SIS.HTTP.Responces.Contracts;
    using SIS.HTTP.Sessions;
    using SIS.WebServer.Routing;
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly ServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
        {
            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        private async Task<HttpRequest> ReadRequest()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesToRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if(numberOfBytesToRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array,0,numberOfBytesToRead);
                result.Append(bytesAsString);

                ///why 1023 and not 1024
                if(numberOfBytesToRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            ///logging the request
            Console.WriteLine(Environment.NewLine 
                + "REQUEST:" + Environment.NewLine 
                + result.ToString().Trim() 
                + Environment.NewLine);

            //TODO: this trim might couse problems
            var methodResult = new HttpRequest(result.ToString().Trim());

            return methodResult;
        }

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            if(!this.serverRoutingTable.Routes.ContainsKey(httpRequest.RequestMethod) ||
               !this.serverRoutingTable.Routes[httpRequest.RequestMethod].ContainsKey(httpRequest.Path))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var response = this.serverRoutingTable.Routes[httpRequest.RequestMethod][httpRequest.Path].Invoke(httpRequest);

            return response;
        }

        private async Task PrepareResponse(IHttpResponse httpResponse)
        {
            byte[] byteSegments = httpResponse.GetBytes();

            var plainTextResponse = Encoding.UTF8.GetString(byteSegments);
            Console.WriteLine(
                Environment.NewLine 
                +"RESPOSE:" + Environment.NewLine 
                +plainTextResponse
                +Environment.NewLine);

            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await this.ReadRequest();

            if(httpRequest != null)
            {
                string sessionId = this.SetRequestSession(httpRequest);

                var httpResponse = this.HandleRequest(httpRequest);

                this.SetResponseSession(httpResponse, sessionId);

                await this.PrepareResponse(httpResponse);
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private string SetRequestSession(IHttpRequest httpRequest)
        {
            string sessionId = null;

            if (httpRequest.Cookies.ContainsCookie(HttpSessionStorage.SessionCookieKey))
            {
                var cookie = httpRequest.Cookies.GetCookie(HttpSessionStorage.SessionCookieKey);
                sessionId = cookie.Value;
                httpRequest.Session = HttpSessionStorage.GetSession(sessionId);
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();
                httpRequest.Session = HttpSessionStorage.GetSession(sessionId);
            }

            return sessionId;
        }

        private void SetResponseSession(IHttpResponse response,string sessionId)
        {
            if(sessionId != null)
            {
                ///TODO: setting the expiration manualy 
                response.Cookies.Add(new HttpCookie(HttpSessionStorage.SessionCookieKey,$"{sessionId};HttpOnly=true", 3));
            }
        }
    }
}
