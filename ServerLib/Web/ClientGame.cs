﻿using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using static ServerLib.Json.Classes.Response;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class ClientGame
    {

        [HTTP("POST", "/client/game/keepalive")]
        public static bool GameKeepalive(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            Debug.PrintDebug($"User ({SessionId}) is still in the server!");
            Utils.SendUnityResponse(session, ResponseControl.NullResponse());
            return true;
        }

        [HTTP("POST", "/client/game/version/validate")]
        public static bool GameVersionValidate(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string resp;
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            Debug.PrintDebug(Uncompressed);
            Requests.Validate validate = JsonConvert.DeserializeObject<Requests.Validate>(Uncompressed);
            if (AccountController.FindAccount(SessionId) != null)
            {
                Debug.PrintDebug($"User ({SessionId}) connected with client version {validate.version.ToString()}");
            }
            else
            {
                Debug.PrintDebug($"Unknown User connected with client version {validate.version.ToString()}");
            }
            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/login")]
        public static bool GameLoging(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            Debug.PrintDebug(Uncompressed);
            var ID =  AccountController.Login(JsonConvert.DeserializeObject<Requests.Login>(Uncompressed));
            string rsp = "";
            if (ID == "FAILED")
            {
                // NO walid error code for Login?
                rsp = ResponseControl.GetBody("null", 206, "account not found");
            }
            else 
            {
                LoginRSP response = new()
                {
                    Lang = "en",
                    ActiveProfileId = ID,
                    Aid = ID,
                    Token = ID,
                    Taxonomy = "341",
                    Backend = new()
                    {
                        Main = ServerLib.IP,
                        Messaging = ServerLib.IP,
                        Trading = ServerLib.IP,
                        RagFair = ServerLib.IP
                    },
                    TotalInGame = 1,
                    UtcTime = TimeHelper.UnixTimeNow(),
                    Queued = false
                };
                rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(response));
                session.Headers.Add("Cookie", "PHPSESSID=" + ID);
            }

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
            var rsp = ResponseControl.GetBody("{status: \"ok\"}");
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
    }
}
