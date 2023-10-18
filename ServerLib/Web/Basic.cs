using ModdableWebServer.Attributes;
using ModdableWebServer;
using NetCoreServer;
using ServerLib.Controllers;
using ModdableWebServer.Helper;
using ServerLib.Utilities;

namespace ServerLib.Web
{
    internal class Basic
    {
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

        [HTTP("GET", "/getBundleList")]
        public static bool GetBundeList(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string resp = "[]"; //Need better handling on bundles
            return Utils.SendUnityResponse(request, serverStruct, resp);
        }

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
