using ModdableWebServer;
using ModdableWebServer.Attributes;
using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Responders;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Web
{
    public class ClientGameProfile
    {
        [HTTP("POST", "/client/game/profile/list")]
        public static bool ProfileList(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);

            var rsp = GameProfile.ProfileList(SessionId);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/search")]
        public static bool ProfileSearch(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            var rsp = GameProfile.ProfileSearch(Uncompressed);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/select")]
        public static bool ProfileSelect(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);

            var rsp = GameProfile.ProfileSelect(SessionId);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/create")]
        public static bool ProfileCreate(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = GameProfile.ProfileCreate(SessionId, Uncompressed);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/nickname/reserved")]
        public static bool ProfileNicknameReserved(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = AccountController.GetReservedNickname(SessionId);
            // RPS
            var rsp = ResponseControl.GetBody($"\"{resp}\"");
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/nickname/validate")]
        public static bool ProfileNicknameValidate(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            // RPS
            var rsp = GameProfile.ProfileNicknameValidate(Uncompressed);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/nickname/change")]
        public static bool ProfileNicknameChange(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            // RPS
            ServerHelper.SendUnityResponse(request, serverStruct, GameProfile.ProfileNickNameChange(Uncompressed, SessionId));
            return true;
        }

        [HTTP("POST", "/client/game/profile/voice/change")]
        public static bool ProfileVoiceChange(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            CharacterController.ChangeVoice(Uncompressed, SessionId);
            // RPS
            var rsp = ResponseControl.NullResponse();
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/game/profile/items/moving")]
        public static bool ProfileItemsMoving(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);
            Debug.PrintWarn(ResponseControl.DeCompressReq(request.BodyBytes));
            string resp = "";
            // RPS
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/profile/status")]
        public static bool ProfileStatus(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);
            if (request.BodyBytes.Length == 0)
            {

            }
            else
            {
                string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
                Debug.PrintDebug(Uncompressed);
            }
            var rsp = GameProfile.GetProfileStatus(SessionId);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }
    }
}
