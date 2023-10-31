using ModdableWebServer;
using ModdableWebServer.Attributes;
using NetCoreServer;
using ServerLib.Responders;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Web
{
    public class ClientFriend
    {
        [HTTP("POST", "/client/friend/list")]
        public static bool FriendList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();

            var rsp = Friend.FriendList(SessionId);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/delete")]
        public static bool FriendDelete(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendDelete(SessionId, Uncompressed);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/send")]
        public static bool FriendReqSend(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendReqSend(SessionId, Uncompressed);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/decline")]
        public static bool FriendReqDecline(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendReqDecline(SessionId, Uncompressed);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/cancel")]
        public static bool FriendReqCancel(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendReqCancel(SessionId, Uncompressed);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/accept")]
        public static bool FriendReqAccept(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();

            var rsp = Friend.FriendReqAccept(SessionId);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/accept-all")]
        public static bool FriendReqAcceptAll(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();

            var rsp = Friend.FriendReqAccept(SessionId);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/list/outbox")]
        public static bool FriendListOutBox(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();

            var rsp = Friend.FriendListOutBox(SessionId);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/list/inbox")]
        public static bool FriendListInBox(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();

            var rsp = Friend.FriendListInBox(SessionId);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }


        [HTTP("POST", "/client/friend/ignore/set")]
        public static bool FriendIgnoreSet(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendMute(SessionId, Uncompressed);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/ignore/remove")]
        public static bool FriendIgnoreRemove(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendUnMute(SessionId, Uncompressed);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }
    }
}
