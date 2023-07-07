using NetCoreServer;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class Client
    {

        [HTTP("POST", "/client/quest/list")]
        public static bool ClientQuestList(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = File.ReadAllText("Files/static/questList.json");
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/items")]
        public static bool ClientItems(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = File.ReadAllText("Files/static/items.json");
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/globals")]
        public static bool ClientGlobals(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var rsp = File.ReadAllText("Files/static/globals.json");
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/weather")]
        public static bool ClientWeather(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var rsp = File.ReadAllText("Files/static/weather.json");
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/items/characteristics")]
        public static bool ClientItemsCharacteristics(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var rsp = File.ReadAllText("Files/static/characteristics.json");
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/locations")]
        public static bool ClientLocations(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var rsp = File.ReadAllText("Files/static/locations.json");
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
     

        [HTTP("POST", "/client/getMetricsConfig")]
        public static bool ClientGetMetricsConfig(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string resp = File.ReadAllText("Files/static/metrics.json");
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/putMetrics")]
        public static bool ClientPutMetrics(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            File.WriteAllText("PutMetrics.json", ResponseControl.DeCompressReq(request.BodyBytes));
            string resp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(session, resp);
            return true;
        }
        [HTTP("POST", "/client/languages")]
        public static bool ClientLanguages(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = File.ReadAllText($"Files/locales/languages.json");
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/locale/{locale}")]
        public static bool ClientLocale(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string locale = session.HttpParam["locale"].ToLower();
            string resp = File.ReadAllText($"Files/locales/{locale}/global.json");
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/menu/locale/{locale}")]
        public static bool ClientLocaleMenu(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string locale = session.HttpParam["locale"].ToLower();
            string resp = File.ReadAllText($"Files/locales/{locale}/menu.json");
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/push/notifier/get/{userId}")]
        public static bool PushNotifier(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string userId = session.HttpParam["userId"].ToLower();
            Debug.PrintDebug(userId);
            Utils.SendUnityResponse(session, System.Text.Encoding.Default.GetBytes(ResponseControl.GetBody("[]")));
            return true;
        }
    }
}
