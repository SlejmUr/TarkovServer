using ModdableWebServer;
using ModdableWebServer.Attributes;
using ModdableWebServer.Helper;
using NetCoreServer;
using ServerLib.Controllers;

namespace TestServer
{
    public class URLs
    {
        [HTTP("POST", "/testserver")]
        public static bool TestServer(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine(request.Body);
            serverStruct.Response.MakeGetResponse("HELLO");
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("POST", "/ts/GetLocationInteractables")]
        public static bool GetLocationInteractables(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine(request.Body);
            serverStruct.Response.MakeGetResponse("HELLO");
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("POST", "/ts/GetAccountCustomiztationIds")]
        public static bool GetAccountCustomiztationIds(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine(request.Body);
            serverStruct.Response.MakeGetResponse("HELLO");
            serverStruct.SendResponse();
            return true;
        }


        [HTTP("POST", "/ts/registerServer")]
        public static bool registerServer(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine(request.Body);
            serverStruct.Response.MakeGetResponse("OK");
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("POST", "/ts/unregisterServer")]
        public static bool unregisterServer(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine(request.Body);
            serverStruct.Response.MakeGetResponse("OK");
            serverStruct.SendResponse();
            return true;
        }
    }
}
