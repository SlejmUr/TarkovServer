using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using static ServerLib.Web.HTTPServer;
using ServerLib.Responders;

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

            var rsp = GameProfile.ProfileList(SessionId);
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
            var rsp = GameProfile.ProfileSearch(Uncompressed);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/select")]
        public static bool ProfileSelect(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);

            var rsp = GameProfile.ProfileSelect(SessionId);
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

            var rsp = GameProfile.ProfileCreate(SessionId, Uncompressed);
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
            var rsp = ResponseControl.GetBody($"\"{resp}\"");
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/nickname/validate")]
        public static bool ProfileNicknameValidate(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            // RPS
            var rsp = GameProfile.ProfileNicknameValidate(Uncompressed);
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
            var resp = ResponseControl.GetBody("{\"status\": 0, \"nicknamechangedate\": " + TimeHelper.UnixTimeNow_Int() + "}");
            if (nickname == "taken")
            {
                resp = ResponseControl.GetBody("null", 255, "The nickname is already in use");
            }

            if (nickname == "tooshort")
            {
                resp = ResponseControl.GetBody("null", 256, "The nickname is too short");
            }
            // RPS
            Utils.SendUnityResponse(session, resp);
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
            var rsp = ResponseControl.NullResponse();
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
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/profile/status")]
        public static bool ProfileStatus(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);

            var rsp = GameProfile.ProfileStatus(SessionId);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
    }
}
