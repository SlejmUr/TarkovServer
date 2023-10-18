using ModdableWebServer;
using ModdableWebServer.Attributes;
using NetCoreServer;
using ServerLib.Responders;
using ServerLib.Utilities;


namespace ServerLib.Web
{
    public class ClientFriend
    {
        [HTTP("POST", "/client/friend/list")]
        public static bool FriendList(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);

            var rsp = Friend.FriendList(SessionId);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/delete")]
        public static bool FriendDelete(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendDelete(SessionId, Uncompressed);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/send")]
        public static bool FriendReqSend(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendReqSend(SessionId, Uncompressed);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/decline")]
        public static bool FriendReqDecline(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendReqDecline(SessionId, Uncompressed);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/cancel")]
        public static bool FriendReqCancel(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendReqCancel(SessionId,Uncompressed);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/accept")]
        public static bool FriendReqAccept(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);

            var rsp = Friend.FriendReqAccept(SessionId);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/accept-all")]
        public static bool FriendReqAcceptAll(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);

            var rsp = Friend.FriendReqAccept(SessionId);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/list/outbox")]
        public static bool FriendListOutBox(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);

            var rsp = Friend.FriendListOutBox(SessionId);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/list/inbox")]
        public static bool FriendListInBox(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);

            var rsp = Friend.FriendListInBox(SessionId);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }


        [HTTP("POST", "/client/friend/ignore/set")]
        public static bool FriendIgnoreSet(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendMute(SessionId,Uncompressed);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/ignore/remove")]
        public static bool FriendIgnoreRemove(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendUnMute(SessionId, Uncompressed);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }
    }
}
