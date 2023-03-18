using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class ClientGameProfile
    {
        [HTTP("POST", "/client/game/profile/list")]
        public static bool ProfileList(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);

            string resp = CharacterController.GetCompleteCharacter(SessionId);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody(resp));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/search")]
        public static bool ProfileSearch(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            //HealOverTime!!

            // {"nickname": ""}


            string resp = CharacterController.GetCompleteCharacter(SessionId);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody(resp));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/select")]
        public static bool ProfileSelect(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            string resp = "{\"status\": \"ok\",\"notifier\":" + ResponseControl.GetNotifier(SessionId) + ",\"notifierServer\":\"\"}";
            // RPS
            Console.WriteLine(resp);
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody(resp));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/create")]
        public static bool ProfileCreate(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            CharacterController.CreateCharacter(SessionId, Uncompressed);
            string resp = "{\"uid\":\"" + SessionId + "\"}";
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody(resp));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/nickname/reserved")]
        public static bool ProfileNicknameReserved(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            string resp = AccountController.GetReservedNickname(SessionId);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody($"\"{resp}\""));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/nickname/validate")]
        public static bool ProfileNicknameValidate(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var nickname = AccountController.ValidateNickname(Uncompressed);
            var resp = ResponseControl.GetBody("{status: \"ok\"}");
            if (nickname == "taken")
            {
                resp = ResponseControl.GetBody("null", 255, "The nickname is already in use");
            }

            if (nickname == "tooshort")
            {
                resp = ResponseControl.GetBody("null", 256, "The nickname is too short");
            }

            // RPS
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/nickname/change")]
        public static bool ProfileNicknameChange(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var nickname = CharacterController.ChangeNickname(Uncompressed, SessionId);
            var resp = ResponseControl.GetBody("{\"status\": 0, \"nicknamechangedate\": " + Time.UnixTimeNow_Int() + "}");
            if (nickname == "taken")
            {
                resp = ResponseControl.GetBody("null", 255, "The nickname is already in use");
            }

            if (nickname == "tooshort")
            {
                resp = ResponseControl.GetBody("null", 256, "The nickname is too short");
            }
            // RPS
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/voice/change")]
        public static bool ProfileVoiceChange(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            CharacterController.ChangeVoice(Uncompressed, SessionId);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/items/moving")]
        public static bool ProfileItemsMoving(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            string resp = "";
            // RPS
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/profile/status")]
        public static bool ProfileStatus(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            var character = CharacterController.GetCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintError("[ProfileStatus] Character not found!");
            }
            string resp = "{\"maxPveCountExceeded\":false,\"profiles\":[{" +
                "\"profileid\":\"" + character.Savage + "\"," +
                "\"profileToken\":null," +
                "\"status\":\"Free\"," +
                "\"sid\":\"\"," +
                "\"ip\":\"\"," +
                "\"port\":0" +
                "},{" +
                "\"profileid\":\"" + character.Aid + "\"," +
                "\"profileToken\":null," +
                "\"status\":\"Free\"," +
                "\"sid\":\"\"," +
                "\"ip\":\"\"," +
                "\"port\":0" +
                "}]}";
            /*
             {
                maxPveCountExceeded: false,
                profiles: [
                    {
                        profileid: savage,
                        profileToken: null,
                        status: "Free",
                        sid: "",
                        ip: "",
                        port: 0
                    },
                    {
                        profileid: _id,
                        profileToken: null,
                        status: "Free",
                        sid: "",
                        ip: "",
                        port: 0
                    }
                ]
            }
             */

            // RPS
            Console.WriteLine(resp);
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
    }
}
