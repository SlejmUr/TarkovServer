using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using ServerLib.Responders;
using ModdableWebServer;
using ModdableWebServer.Attributes;
using System.Security.Cryptography;

namespace ServerLib.Web
{
    public class ClientGameProfile
    {
        [HTTP("POST", "/client/game/profile/list")]
        public static bool ProfileList(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.PrintRequest(request, serverStruct);

            var rsp = GameProfile.ProfileList(SessionId);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/search")]
        public static bool ProfileSearch(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            var rsp = GameProfile.ProfileSearch(Uncompressed);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/select")]
        public static bool ProfileSelect(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.PrintRequest(request, serverStruct);

            var rsp = GameProfile.ProfileSelect(SessionId);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/create")]
        public static bool ProfileCreate(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = GameProfile.ProfileCreate(SessionId, Uncompressed);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/nickname/reserved")]
        public static bool ProfileNicknameReserved(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.PrintRequest(request, serverStruct);
            string resp = AccountController.GetReservedNickname(SessionId);
            // RPS
            var rsp = ResponseControl.GetBody($"\"{resp}\"");
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/nickname/validate")]
        public static bool ProfileNicknameValidate(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            Utils.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            // RPS
            var rsp = GameProfile.ProfileNicknameValidate(Uncompressed);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/nickname/change")]
        public static bool ProfileNicknameChange(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.PrintRequest(request, serverStruct);
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
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/voice/change")]
        public static bool ProfileVoiceChange(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            CharacterController.ChangeVoice(Uncompressed, SessionId);
            // RPS
            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/items/moving")]
        public static bool ProfileItemsMoving(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.PrintRequest(request, serverStruct);
            string resp = "";
            // RPS
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/profile/status")]
        public static bool ProfileStatus(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.PrintRequest(request, serverStruct);

            var rsp = GameProfile.ProfileStatus(SessionId);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }
    }
}
