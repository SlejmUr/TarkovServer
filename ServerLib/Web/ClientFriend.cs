using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
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

            Json.Classes.FriendList friendsList = new Json.Classes.FriendList();
            friendsList.Friends.AddRange(FriendsController.GetFriends(SessionId));

            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(friendsList));
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/send")]
        public static bool FriendReqSend(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);

            var reqID = FriendsController.AddRequest(SessionId, req.toId);
            FriendSendJson friendRsp = new()
            {
                RequestId = reqID,
                RetryAfter = 30,
                Error = 0
            };
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(friendRsp));
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/decline")]
        public static bool FriendReqDecline(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);

            FriendsController.RemoveFriend(SessionId, req.req_Id);

            string resp = ResponseControl.NullResponse();
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/cancel")]
        public static bool FriendReqCancel(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);

            var reqID = FriendsController.RemoveRequest(SessionId, req.reqId);

            string resp = ResponseControl.GetBody(reqID);
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/accept")]
        public static bool FriendReqAccept(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            FriendsController.AcceptAll(SessionId);

            string resp = ResponseControl.GetBody("OK");
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/accept-all")]
        public static bool FriendReqAcceptAll(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            FriendsController.AcceptAll(SessionId);

            string resp = ResponseControl.GetBody("OK");
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/list/outbox")]
        public static bool FriendListOutBox(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            var inbox = FriendsController.GetFriendsOutbox(SessionId);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(inbox));

            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/request/list/inbox")]
        public static bool FriendListInBox(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            var inbox = FriendsController.GetFriendsInbox(SessionId);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(inbox));

            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }


        [HTTP("POST", "/client/friend/ignore/set")]
        public static bool FriendIgnoreSet(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);

            //req.uid;

            string resp = ResponseControl.GetBody("OK");
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/friend/ignore/remove")]
        public static bool FriendIgnoreRemove(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);

            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);

            //req.uid;

            string resp = ResponseControl.GetBody("OK");
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
    }
}
