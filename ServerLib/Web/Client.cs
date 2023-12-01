using ModdableWebServer;
using ModdableWebServer.Attributes;
using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities.Helpers;
using ServerLib.Responders;
using JsonLib.Classes.Request;
using static JsonLib.Classes.ProfileRelated.Profile;
using System.Text;

namespace ServerLib.Web
{
    public class Client
    {
        [HTTP("POST", "/client/checkVersion")]
        public static bool ClientCheckVersion(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            uint crc = serverStruct.Headers.GetCRC();
            var ifMatch = CRCHelper.CheckIfCRCMatch($"{request.Url}_{SessionId}", crc);
            if (ifMatch)
            {
                ServerHelper.SendNotModifiedResponse(serverStruct);
                return true;
            }
            var resp = ClientRespond.GetVersion(request, serverStruct);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/repeatalbeQuests/activityPeriods")]
        public static bool ClientRepeatableQuestsActivityPeriods(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody("[]");
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/notifier/channel/create")]
        public static bool ClientNotifier(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            uint crc = serverStruct.Headers.GetCRC();
            var ifMatch = CRCHelper.CheckIfCRCMatch($"{request.Url}_{SessionId}", crc);
            if (ifMatch)
            {
                ServerHelper.SendNotModifiedResponse(serverStruct);
                return true;
            }
            var rsp = JsonConvert.SerializeObject(ResponseControl.GetNotifier(SessionId));
            var hash = CRCHelper.Compute(Encoding.UTF8.GetBytes(rsp));
            CRCHelper.URL_CRC.Add($"{request.Url}_{SessionId}", hash);
            var resp =  ResponseControl.GetBodyCRC(rsp, 0, "null", hash);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/chatServer/list")]
        public static bool ClientChatServerList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            uint crc = serverStruct.Headers.GetCRC();
            var ifMatch = CRCHelper.CheckIfCRCMatch($"{request.Url}_{SessionId}", crc);
            if (ifMatch)
            {
                ServerHelper.SendNotModifiedResponse(serverStruct);
                return true;
            }
            ServerHelper.SendUnityResponse(request, serverStruct, ClientRespond.GetChatServerList(request, serverStruct));
            return true;
        }

        [HTTP("POST", "/client/server/list")]
        public static bool ClientServerList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            uint crc = serverStruct.Headers.GetCRC();
            var ifMatch = CRCHelper.CheckIfCRCMatch($"{request.Url}_{SessionId}", crc);
            if (ifMatch)
            {
                ServerHelper.SendNotModifiedResponse(serverStruct);
                return true;
            }
            ServerHelper.SendUnityResponse(request, serverStruct, ClientRespond.GetServerList(request, serverStruct));
            return true;
        }

        [HTTP("POST", "/client/quest/list")]
        public static bool ClientQuestList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            uint crc = serverStruct.Headers.GetCRC();
            var ifMatch = CRCHelper.CheckIfCRCMatch($"{request.Url}_{SessionId}", crc);
            if (ifMatch)
            {
                ServerHelper.SendNotModifiedResponse(serverStruct);
                return true;
            }
            ServerHelper.SendUnityResponse(request, serverStruct, ClientRespond.GetQuests(request, serverStruct));
            return true;
        }

        [HTTP("POST", "/client/items")]
        public static bool ClientItems(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            uint crc = serverStruct.Headers.GetCRC();
            var ifMatch = CRCHelper.CheckIfCRCMatch($"{request.Url}_{SessionId}", crc);
            if (ifMatch)
            {
                ServerHelper.SendNotModifiedResponse(serverStruct);
                return true;
            }
            var rsp = File.ReadAllText("Files/others/items.json");
            var hash = CRCHelper.Compute(Encoding.UTF8.GetBytes(rsp));
            CRCHelper.URL_CRC.Add($"{request.Url}_{SessionId}", hash);
            var resp = ResponseControl.GetBodyCRC(rsp, 0, "null", hash);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/customization")]
        public static bool ClientCustomization(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            uint crc = serverStruct.Headers.GetCRC();
            var ifMatch = CRCHelper.CheckIfCRCMatch($"{request.Url}_{SessionId}", crc);
            if (ifMatch)
            {
                ServerHelper.SendNotModifiedResponse(serverStruct);
                return true;
            }
            var rsp = File.ReadAllText("Files/others/customization.json");
            var hash = CRCHelper.Compute(Encoding.UTF8.GetBytes(rsp));
            CRCHelper.URL_CRC.Add($"{request.Url}_{SessionId}", hash);
            var resp = ResponseControl.GetBodyCRC(rsp, 0, "null", hash);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/globals")]
        public static bool ClientGlobals(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct); 
            string SessionId = serverStruct.Headers.GetSessionId();
            uint crc = serverStruct.Headers.GetCRC();
            var ifMatch = CRCHelper.CheckIfCRCMatch($"{request.Url}_{SessionId}", crc);
            if (ifMatch)
            {
                ServerHelper.SendNotModifiedResponse(serverStruct);
                return true;
            }
            var rsp = File.ReadAllText("Files/static/globals.json");
            var hash = CRCHelper.Compute(Encoding.UTF8.GetBytes(rsp));
            CRCHelper.URL_CRC.Add($"{request.Url}_{SessionId}", hash);
            var resp = ResponseControl.GetBodyCRC(rsp, 0, "null", hash);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/settings")]
        public static bool ClientSettings(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            uint crc = serverStruct.Headers.GetCRC();
            var ifMatch = CRCHelper.CheckIfCRCMatch($"{request.Url}_{SessionId}", crc);
            if (ifMatch)
            {
                ServerHelper.SendNotModifiedResponse(serverStruct);
                return true;
            }
            var rsp = File.ReadAllText("Files/static/client.settings.json");
            var hash = CRCHelper.Compute(Encoding.UTF8.GetBytes(rsp));
            CRCHelper.URL_CRC.Add($"{request.Url}_{SessionId}", hash);
            var resp = ResponseControl.GetBodyCRC(rsp, 0, "null", hash);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/weather")]
        public static bool ClientWeather(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);

            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Weather["sun"]);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/locations")]
        public static bool ClientLocations(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var json = JsonConvert.SerializeObject(LocationController.GetAllLocation());
            string resp = ResponseControl.GetBody(json);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/location/getLocalloot")]
        public static bool ClientLocationLocalLoot(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var jsonreq = JsonConvert.DeserializeObject<GetLocation>(ResponseControl.DeCompressReq(request.BodyBytes));
            ArgumentNullException.ThrowIfNull(jsonreq);
            var location = LocationController.GetLocationLoot(jsonreq);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(location));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/account/customization")]
        public static bool ClientAccountCustomization(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(CustomizationController.GetAccountCustomization()));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/handbook/templates")]
        public static bool ClientHandbookTemplates(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(DatabaseController.DataBase.Others.Templates));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/handbook/builds/my/list")]
        public static bool ClientHandbookBuildsMyList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();

            ProfileBuilds ret = new()
            { 
                EquipmentBuilds = new(),
                WeaponBuilds = new()
            };
            var profile = ProfileController.GetProfile(SessionId);
            if (profile != null && profile.Builds != null)
            {
                ret = profile.Builds;
            }

            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(ret));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/getMetricsConfig")]
        public static bool ClientGetMetricsConfig(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            string resp = File.ReadAllText("Files/static/metrics.json");
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/putMetrics")]
        public static bool ClientPutMetrics(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            File.WriteAllText("PutMetrics.json", ResponseControl.DeCompressReq(request.BodyBytes));
            ServerHelper.SendUnityResponse(request, serverStruct, ResponseControl.NullResponse());
            return true;
        }
    }
}
