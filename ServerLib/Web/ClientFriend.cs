using NetCoreServer;
using ServerLib.Responders;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;


namespace ServerLib.Web
{
    public class ClientFriend
    {
        [HTTP("POST", "/client/friend/list")]
        public static bool FriendList(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            var rsp = Friend.FriendList(SessionId);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/delete")]
        public static bool FriendDelete(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendDelete(SessionId, Uncompressed);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/send")]
        public static bool FriendReqSend(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendReqSend(SessionId, Uncompressed);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/decline")]
        public static bool FriendReqDecline(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendReqDecline(SessionId, Uncompressed);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/cancel")]
        public static bool FriendReqCancel(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendReqCancel(SessionId,Uncompressed);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/accept")]
        public static bool FriendReqAccept(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            var rsp = Friend.FriendReqAccept(SessionId);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/accept-all")]
        public static bool FriendReqAcceptAll(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            var rsp = Friend.FriendReqAccept(SessionId);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/list/outbox")]
        public static bool FriendListOutBox(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            var rsp = Friend.FriendListOutBox(SessionId);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/list/inbox")]
        public static bool FriendListInBox(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            var rsp = Friend.FriendListInBox(SessionId);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }


        [HTTP("POST", "/client/friend/ignore/set")]
        public static bool FriendIgnoreSet(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendMute(SessionId,Uncompressed);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/ignore/remove")]
        public static bool FriendIgnoreRemove(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            var rsp = Friend.FriendUnMute(SessionId, Uncompressed);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
    }
}
