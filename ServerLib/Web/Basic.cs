
using ModdableWebServer;
using ModdableWebServer.Attributes;
using ModdableWebServer.Helper;
using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Responders;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Web
{
    internal class Basic
    {
        //#if DEBUG
        [HTTP("GET", "/test/{thing}")]
        public static bool TestParam(HttpRequest request, ServerStruct serverStruct)
        {
            string resp = "test param: " + serverStruct.Parameters["thing"];
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("GET", "/test")]
        public static bool Test(HttpRequest request, ServerStruct serverStruct)
        {
            string resp = "test";
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("GET", "/")]
        public static bool Root(HttpRequest request, ServerStruct serverStruct)
        {
            string resp = "test";
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }
        //#endif
        [HTTP("GET", "/ServerInternalIPAddress")]
        public static bool ServerInternalIPAddress(HttpRequest request, ServerStruct serverStruct)
        {
            string resp = ConfigController.Configs.Server.Ip;
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("GET", "/ServerExternalIPAddress")]
        public static bool ServerExternalIPAddress(HttpRequest request, ServerStruct serverStruct)
        {
            string resp = ConfigController.Configs.Server.Ip;
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }
    }
}
