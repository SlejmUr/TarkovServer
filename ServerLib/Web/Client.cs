using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class Client
    {
        [HTTP("POST", "/client/checkVersion")]
        public static bool ClientCheckVersion(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp;
            string version = Utils.GetVersion(session.Headers);
            var server = ConfigController.Configs.Server;

            if (string.IsNullOrWhiteSpace(server.Version))
            {
                resp = ResponseControl.GetBody("{ isvalid: true, latestVersion: \"" + server.Version + "\"}");
            }
            else
            {
                if (server.Version == version)
                {
                    resp = ResponseControl.GetBody("{ isvalid: true, latestVersion: \"" + server.Version + "\"}");
                }
                else
                {
                    resp = ResponseControl.GetBody("{ isvalid: false, latestVersion: \"" + server.Version + "\"}");
                }
            }
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/repeatalbeQuests/activityPeriods")]
        public static bool ClientRepeatableQuestsActivityPeriods(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = ResponseControl.GetBody("[]");
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/WebSocketAddress")]
        public static bool ClientWebSocketAddress(HttpRequest request, HttpsBackendSession session)
        {
            Console.WriteLine("WebSocketAddress!!!!!!!");
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            var rsp = ResponseControl.CompressRsp(WebSocket.IpPort + SessionId);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/notifier/channel/create")]
        public static bool ClientNotifier(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string resp = ResponseControl.GetBody(ResponseControl.GetNotifier(SessionId));
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/chatServer/list")]
        public static bool ClientChatServerList(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            Json.Other.ChatServerList chatServerList = new();
            chatServerList.DateTime = (int)Time.UnixTimeNow();
            chatServerList.Regions.Add("EUR");
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(chatServerList));
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/server/list")]
        public static bool ClientServerList(HttpRequest request, HttpsBackendSession session)
        {

            Utils.PrintRequest(request, session);
            var server = ConfigController.Configs.Server;
            List<Server> servers = new();
            Server acsserver = new();
            acsserver.Address = server.Ip;
            acsserver.Port = $"{server.Port}";
            servers.Add(acsserver);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(servers));
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/items")]
        public static bool ClientItems(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = ResponseControl.GetBody(File.ReadAllText("Files/others/items.json"));
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/customization")]
        public static bool ClientCustomization(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = ResponseControl.GetBody(File.ReadAllText("Files/others/customization.json"));
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/globals")]
        public static bool ClientGlobals(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var rsp = ResponseControl.CompressRsp(File.ReadAllText("Files/base/globals.json"));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/settings")]
        public static bool ClientSettings(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var rsp = ResponseControl.CompressRsp(File.ReadAllText("Files/others/client.settings.json"));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/weather")]
        public static bool ClientWeather(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);

            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Weather["sun"]);
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/locations")]
        public static bool ClientLocations(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Location.AllLocations);
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/account/customization")]
        public static bool ClientAccountCustomization(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(CustomizationController.GetAccountCustomization()));
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
        /*
        [HTTP("POST", "/client/items/price/{traderId}")]
        public static bool ClientItemsPriceTrader(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request,session);
            string resp = ResponseControl.GetBody(File.ReadAllText("Files/items/items.json"));
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session,rsp);
            return true;
        }*/
    }
}
