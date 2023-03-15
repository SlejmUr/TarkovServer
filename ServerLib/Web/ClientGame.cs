using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class ClientGame
    {
        [HTTP("POST", "/client/game/start")]
        public static bool GameStart(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            string resp;
            // RPS
            var TimeThingy = Utils.UnixTimeNow_Int();
            if (AccountController.ClientHasProfile(SessionId))
            {
                resp = ResponseControl.GetBody("{\"utc_time\":" + TimeThingy + "}");
            }
            else
            {
                resp = ResponseControl.GetBody("{\"utc_time\":" + TimeThingy + "}", 999, "Profile Not Found!!");
            }
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/keepalive")]
        public static bool GameKeepalive(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string resp;
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            var TimeThingy = Utils.UnixTimeNow_Int();
            if (SessionId == null)
            {
                resp = ResponseControl.GetBody("{\"msg\":\"No Session\", \"utc_time\":" + TimeThingy + "}");
            }
            else
            {
                KeepAliveController.Main(SessionId);
                resp = ResponseControl.GetBody("{\"msg\":\"OK\", \"utc_time\":" + TimeThingy + "}");
            }
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
        [HTTP("POST", "/client/game/version/validate")]
        public static bool GameVersionValidate(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string resp;
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string version = Utils.GetVersion(session.Headers);
            if (AccountController.FindAccount(SessionId) != null)
            {
                Debug.PrintDebug($"User ({SessionId}) connected with client version {version}");
            }
            else
            {
                Debug.PrintDebug($"Unknown User connected with client version {version}");
            }
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/config")]
        public static bool GameConfig(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string resp;
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            Json.Other.GameConfig game = new()
            {
                Aid = SessionId,
                Lang = AccountController.GetAccountLang(SessionId),
                Languages = AccountController.GetAccountLang(SessionId),
                NdaFree = false,
                Taxonomy = 6,
                ActiveProfileId = "pmc" + SessionId,
                Backend = new()
                {
                    Main = ServerLib.IP,
                    Messaging = ServerLib.IP,
                    Trading = ServerLib.IP,
                    RagFair = ServerLib.IP,
                    Lobby = ServerLib.IP,
                },
                UtcTime = Utils.UnixTimeNow(),
                TotalInGame = AccountController.ActiveAccountIds.Count,
                ReportAvailable = true,
                TwitchEventMember = false
            };

            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody(JsonConvert.SerializeObject(game)));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/logout")]
        public static bool GameLogout(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            AccountController.SessionLogout(SessionId);
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody("{status: \"ok\"}"));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/bot/generate")]
        public static bool BotGenerate(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            var conditions = JsonConvert.DeserializeObject<List<WaveInfo>>(Uncompressed);

            CharacterController.RaidKilled(Uncompressed, SessionId);
            // RPS
            var rsp = ResponseControl.CompressRsp("{}");
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
    }
}
