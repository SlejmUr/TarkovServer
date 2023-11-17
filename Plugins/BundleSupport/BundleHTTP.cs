using ModdableWebServer;
using ModdableWebServer.Attributes;
using NetCoreServer;
using ServerLib.Utilities.Helpers;
using Newtonsoft.Json;

namespace BundleSupport
{
    public class BundleHTTP
    {
        public static string GetBundles()
        {
            //return JsonConvert.SerializeObject(BundleManager.Bundles);
            return "[]";
        }

        [HTTP("GET", "/getBundleList")]
        public static bool GetBundeList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            return ServerHelper.SendUnityResponse(request, serverStruct, GetBundles());
        }

        [HTTP("GET", "/singleplayer/bundles")]
        public static bool singleplayerGetBundeList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            return ServerHelper.SendUnityResponse(request, serverStruct, GetBundles());
        }
    }
}