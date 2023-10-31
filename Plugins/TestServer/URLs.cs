using ModdableWebServer;
using ModdableWebServer.Attributes;
using ModdableWebServer.Helper;
using NetCoreServer;
using ServerLib.Controllers;

namespace TestServer
{
    public class URLs
    {
        [HTTP("POST", "/testserver/")]
        public static bool TestServer(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine(request.Body);
            serverStruct.Response.MakeGetResponse("HELLO");
            serverStruct.SendResponse();
            return true;
        }     
    }
}
