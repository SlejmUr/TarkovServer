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
            Utils.PrintRequest(request, serverStruct);
            string resp;
            string version = Utils.GetVersion(serverStruct.Headers);
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
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/repeatalbeQuests/activityPeriods")]
        public static bool ClientRepeatableQuestsActivityPeriods(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody("[]");
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/WebSocketAddress")]
        public static bool ClientWebSocketAddress(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine("WebSocketAddress!!!!!!!");
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.SendUnityResponse(request, serverStruct, ServerManager.IpPort + SessionId);
            return true;
        }

        [HTTP("POST", "/client/notifier/channel/create")]
        public static bool ClientNotifier(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(ResponseControl.GetNotifier(SessionId)));
            Utils.SendUnityResponse(request, serverStruct, resp); ;
            return true;
        }

        [HTTP("POST", "/client/chatServer/list")]
        public static bool ClientChatServerList(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            Json.Classes.ChatServer.Base chatServerList = new()
            { 
                _id = Utils.CreateNewID(),
                RegistrationId = 20,
                DateTime = (int)TimeHelper.UnixTimeNow(),
                IsDeveloper = true,
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
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/server/list")]
        public static bool ClientServerList(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
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
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/quest/list")]
        public static bool ClientQuestList(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            try
            {
                var quests = Controllers.QuestController.GetQuests();
                string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(quests, new JsonConverter[]
                    {
                    QuestTargetConverter.Singleton
                    }));
                Utils.SendUnityResponse(request, serverStruct, resp);
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
            Utils.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(File.ReadAllText("Files/others/items.json"));
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/customization")]
        public static bool ClientCustomization(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(File.ReadAllText("Files/others/customization.json"));
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/globals")]
        public static bool ClientGlobals(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            var rsp = ResponseControl.GetBody(File.ReadAllText("Files/static/globals.json"));
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/settings")]
        public static bool ClientSettings(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            var rsp = File.ReadAllText("Files/static/client.settings.json");
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/weather")]
        public static bool ClientWeather(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);

            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Weather["sun"]);
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/locations")]
        public static bool ClientLocations(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            var json = JsonConvert.SerializeObject(LocationController.GetAllLocation());
            string resp = ResponseControl.GetBody(json);
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/location/getLocalloot")]
        public static bool ClientLocationLocalLoot(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            var jsonreq = JsonConvert.DeserializeObject<GetLocation>(ResponseControl.DeCompressReq(request.BodyBytes));
            var location =  LocationController.GetLocationLoot(jsonreq);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(location));
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/account/customization")]
        public static bool ClientAccountCustomization(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(CustomizationController.GetAccountCustomization()));
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/handbook/templates")]
        public static bool ClientHandbookTemplates(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(DatabaseController.DataBase.Others.Templates));
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/handbook/builds/my/list")]
        public static bool ClientHandbookBuildsMyList(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);

            List<WeaponBuild> ret = new();
            var profile = ProfileController.GetProfile(SessionId);
            if (profile != null && profile.Weaponbuilds != null && profile.Weaponbuilds.Count > 0)
            {
                ret = profile.Weaponbuilds;
            }

            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(ret));
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/getMetricsConfig")]
        public static bool ClientGetMetricsConfig(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            string resp = File.ReadAllText("Files/static/metrics.json");
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/putMetrics")]
        public static bool ClientPutMetrics(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            File.WriteAllText("PutMetrics.json", ResponseControl.DeCompressReq(request.BodyBytes));
            string resp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }
    }
}
