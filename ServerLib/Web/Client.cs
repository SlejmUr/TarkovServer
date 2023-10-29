using ModdableWebServer;
using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using static ServerLib.Json.Classes.Profile;
using static ServerLib.Json.Converters;
using ModdableWebServer.Attributes;

namespace ServerLib.Web
{
    public class Client
    {
        [HTTP("POST", "/client/checkVersion")]
        public static bool ClientCheckVersion(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp;
            string version = serverStruct.Headers.GetVersion();
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

        [HTTP("POST", "/client/WebSocketAddress")]
        public static bool ClientWebSocketAddress(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine("WebSocketAddress!!!!!!!");
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.SendUnityResponse(request, serverStruct, ServerManager.IpPort_WS + SessionId);
            return true;
        }

        [HTTP("POST", "/client/notifier/channel/create")]
        public static bool ClientNotifier(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(ResponseControl.GetNotifier(SessionId)));
            ServerHelper.SendUnityResponse(request, serverStruct, resp); ;
            return true;
        }

        [HTTP("POST", "/client/chatServer/list")]
        public static bool ClientChatServerList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            Json.Classes.ChatServer.Base chatServerList = new()
            { 
                _id = AIDHelper.CreateNewID(),
                RegistrationId = 20,
                DateTime = (int)TimeHelper.UnixTimeNow(),
                Regions = new() { "EUR" },
                VersionId = "bgkidft87ddd",
                Ip = "",
                Port = 0,
                Chats = new()
                { 
                    new()
                    { 
                        _id = "0",
                        Members = 0
                    }
                }
            };
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(chatServerList));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/server/list")]
        public static bool ClientServerList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var server = ConfigController.Configs.Server;
            List<Server> servers = new()
            { 
                new()
                { 
                    Address = server.Ip,
                    Port = $"{1000}"
                }
            };
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(servers));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/quest/list")]
        public static bool ClientQuestList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            try
            {
                var quests = Controllers.QuestController.GetQuests();
                string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(quests, new JsonConverter[]
                    {
                    QuestTargetConverter.Singleton
                    }));
                ServerHelper.SendUnityResponse(request, serverStruct, resp);
            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
            }

            return true;
        }

        [HTTP("POST", "/client/items")]
        public static bool ClientItems(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(File.ReadAllText("Files/others/items.json"));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/customization")]
        public static bool ClientCustomization(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(File.ReadAllText("Files/others/customization.json"));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/globals")]
        public static bool ClientGlobals(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var rsp = ResponseControl.GetBody(File.ReadAllText("Files/static/globals.json"));
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/settings")]
        public static bool ClientSettings(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var rsp = File.ReadAllText("Files/static/client.settings.json");
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
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
            var location =  LocationController.GetLocationLoot(jsonreq);
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
            string SessionId = serverStruct.Headers.GetSessionId();
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(DatabaseController.DataBase.Others.Templates));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/handbook/builds/my/list")]
        public static bool ClientHandbookBuildsMyList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();

            List<WeaponBuild> ret = new();
            var profile = ProfileController.GetProfile(SessionId);
            if (profile != null && profile.Weaponbuilds != null && profile.Weaponbuilds.Count > 0)
            {
                ret = profile.Weaponbuilds;
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
            string resp = ResponseControl.NullResponse();
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }
    }
}
