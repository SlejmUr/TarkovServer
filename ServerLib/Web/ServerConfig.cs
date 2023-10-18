using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using ModdableWebServer;
using ModdableWebServer.Attributes;
using ModdableWebServer.Helper;
using System.Security.Cryptography;

namespace ServerLib.Web
{
    public class ServerConfig
    {
        [HTTP("GET", "/server/config/server")]
        public static bool ConfigServer(HttpRequest request, ServerStruct serverStruct)
        {
            string resp = "";
            if (ConfigController.Configs.CustomSettings.Server.PublicConfigEnabled)
            {
                resp = JsonConvert.SerializeObject(ConfigController.Configs.Server);
            }
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("GET", "/server/config/gameplay")]
        public static bool ConfigGameplay(HttpRequest request, ServerStruct serverStruct)
        {
            string resp = "";
            if (ConfigController.Configs.CustomSettings.Server.PublicConfigEnabled)
            {
                resp = JsonConvert.SerializeObject(ConfigController.Configs.Gameplay);
            }
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("GET", "/server/config/plugin")]
        public static bool ConfigPlugin(HttpRequest request, ServerStruct serverStruct)
        {
            string resp = "";
            if (ConfigController.Configs.CustomSettings.Server.PublicConfigEnabled)
            {
                resp = JsonConvert.SerializeObject(ConfigController.Configs.Plugins);
            }
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("GET", "/server/config/custom")]
        public static bool ConfigCustom(HttpRequest request, ServerStruct serverStruct)
        {
            string resp = "";
            if (ConfigController.Configs.CustomSettings.Server.PublicConfigEnabled)
            {
                resp = JsonConvert.SerializeObject(ConfigController.Configs.CustomSettings);
            }
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }
    }
}
