using ModdableWebServer;
using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using ModdableWebServer.Attributes;

namespace ServerLib.Web
{
    public class ClientGame
    {
        [HTTP("POST", "/client/game/start")]
        public static bool GameStart(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.PrintRequest(request, serverStruct);
            string resp;
            // RPS
            var TimeThingy = TimeHelper.UnixTimeNow_Int();
            if (AccountController.ClientHasProfile(SessionId))
            {
                resp = ResponseControl.GetBody("{\"utc_time\":" + TimeThingy + "}");
            }
            else
            {
                resp = ResponseControl.GetBody("{\"utc_time\":" + TimeThingy + "}", 999, "Profile Not Found!!");
            }
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/game/keepalive")]
        public static bool GameKeepalive(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string resp;
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            var TimeThingy = TimeHelper.UnixTimeNow_Int();
            if (SessionId == null)
            {
                resp = ResponseControl.GetBody("{\"msg\":\"No Session\", \"utc_time\":" + TimeThingy + "}");
            }
            else
            {
                KeepAliveController.Main(SessionId);
                resp = ResponseControl.GetBody("{\"msg\":\"OK\", \"utc_time\":" + TimeThingy + "}");
            }
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }
        [HTTP("POST", "/client/game/version/validate")]
        public static bool GameVersionValidate(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string resp;
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            string version = Utils.GetVersion(serverStruct.Headers);
            if (AccountController.FindAccount(SessionId) != null)
            {
                Debug.PrintDebug($"User ({SessionId}) connected with client version {version}");
            }
            else
            {
                Debug.PrintDebug($"Unknown User connected with client version {version}");
            }
            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/config")]
        public static bool GameConfig(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string resp;
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            var serverips = ConfigController.Configs.Server.ServerIPs;
            Json.Classes.GameConfig.Backend backend = new();
            if (serverips.Enable)
            {
                backend = new()
                {
                    Main = serverips.Main,
                    Messaging = serverips.Messaging,
                    Trading = serverips.Trading,
                    RagFair = serverips.RagFair,
                    Lobby = serverips.Lobby,
                };
            }
            else
            {
                backend = new()
                {
                    Main = ServerLib.IP,
                    Messaging = ServerLib.IP,
                    Trading = ServerLib.IP,
                    RagFair = ServerLib.IP,
                    Lobby = ServerLib.IP,
                };
            }
            Json.Classes.GameConfig.Response game = new()
            {
                aid = SessionId,
                lang = AccountController.GetAccountLang(SessionId),
                languages = LocaleController.GetDictLanguages(),
                ndaFree = false,
                taxonomy = 6,
                activeProfileId = "pmc" + SessionId,
                backend = backend,
                utc_time = TimeHelper.UnixTimeNow_Int(),
                totalInGame = AccountController.ActiveAccountIds.Count,
                reportAvailable = true,
                twitchEventMember = false
            };

            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(game));
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/logout")]
        public static bool GameLogout(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            AccountController.SessionLogout(SessionId);
            var rsp = ResponseControl.GetBody("{status: \"ok\"}");
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/bot/generate")]
        public static bool BotGenerate(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            var conditions = JsonConvert.DeserializeObject<List<WaveInfo>>(Uncompressed);
            // RPS
            var rsp = "{}";
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }
    }
}
