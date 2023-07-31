using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using System.Globalization;
using static ServerLib.Json.Classes.Response;
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
            string resp = ResponseControl.GetBody(File.ReadAllText("Files/static/items.json"));
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

            Response.WeatherData weather = JsonConvert.DeserializeObject<Response.WeatherData>(rsp);
            weather.Weather.Timestamp = TimeHelper.UnixTimeNow_Int();
            var time = DateTime.UtcNow;
            weather.Date = time.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            weather.Time = time.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
            weather.Weather.Date = time.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            weather.Weather.Time = time.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(weather));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/handbook/templates")]
        public static bool ClientHandbookTemplates(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var rsp = File.ReadAllText("Files/static/templates.json");
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

        [HTTP("POST", "/client/notifier/channel/create")]
        public static bool NotifierChannelCreate(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var sessionId = Utils.GetSessionId(session.Headers);
            notif2 serv = new()
            { 
                notifierServer = $"http://172.0.0.1:6969/notifier/{sessionId}" 
            };
            Utils.SendUnityResponse(session, ResponseControl.GetBody(JsonConvert.SerializeObject(serv)));
            return true;
        }

        [HTTP("POST", "/notifier/{id}")]
        public static bool NotifierId(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var sessionId = Utils.GetSessionId(session.Headers);
            string id = session.HttpParam["id"].ToLower();
            Console.WriteLine("yeeeeeeeeeeeeeeet");
            Utils.SendUnityResponse(session, ResponseControl.NullResponse());
            return true;
        }
    }
}
