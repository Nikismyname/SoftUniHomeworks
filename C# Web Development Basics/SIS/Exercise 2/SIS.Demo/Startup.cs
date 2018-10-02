namespace SIS.Demo
{
    using SIS.HTTP.Enums;
    using SIS.WebServer;
    using SIS.WebServer.Routing;

    public class Startup
    {
        public static void Main()
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index();
            Server server = new Server(8000,serverRoutingTable);
            server.Run();
        }
    }
}
