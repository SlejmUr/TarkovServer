using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class ServerConfig
    {
        [HTTP("GET", "/server/config/server")]
        public static bool ConfigServer(HttpRequest request, HttpsBackendSession session)
        {
            string resp = "";
            if (ConfigController.Configs.CustomSettings.Server.PublicConfigEnabled)
            {
                resp = JsonConvert.SerializeObject(ConfigController.Configs.Server);
            }
            session.SendResponse(session.Response.MakeGetResponse(resp));
            return true;
        }

        [HTTP("GET", "/server/config/plugin")]
        public static bool ConfigPlugin(HttpRequest request, HttpsBackendSession session)
        {
            string resp = "";
            if (ConfigController.Configs.CustomSettings.Server.PublicConfigEnabled)
            {
                resp = JsonConvert.SerializeObject(ConfigController.Configs.Plugins);
            }
            session.SendResponse(session.Response.MakeGetResponse(resp));
            return true;
        }

        [HTTP("GET", "/server/config/custom")]
        public static bool ConfigCustom(HttpRequest request, HttpsBackendSession session)
        {
            string resp = "";
            if (ConfigController.Configs.CustomSettings.Server.PublicConfigEnabled)
            {
                resp = JsonConvert.SerializeObject(ConfigController.Configs.CustomSettings);
            }
            session.SendResponse(session.Response.MakeGetResponse(resp));
            return true;
        }
    }
}
