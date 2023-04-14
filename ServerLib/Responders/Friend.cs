using Newtonsoft.Json;
using ServerLib.Controllers;
using static ServerLib.Web.ResponseControl;

namespace ServerLib.Responders
{
    public static class Friend
    {
        public static byte[] FriendList(string SessionId)
        {
            Json.Classes.FriendList friendsList = FriendsController.GetFriendList(SessionId);
            return CompressRsp(GetBody(JsonConvert.SerializeObject(friendsList)));
        }

        public static byte[] FriendDelete(string SessionId, string Uncompressed)
        {
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendId>(Uncompressed);
            FriendsController.RemoveFriend(SessionId, req.friend_id);
            return CompressRsp(NullResponse());
        }

        public static byte[] FriendReqSend(string SessionId, string Uncompressed)
        {
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);

            var reqID = FriendsController.AddRequest(SessionId, req.toId);
            FriendSendJson friendRsp = new()
            {
                RequestId = reqID,
                RetryAfter = 30,
                Error = 0
            };
            return CompressRsp(GetBody(JsonConvert.SerializeObject(friendRsp)));
        }

        public static byte[] FriendReqDecline(string SessionId, string Uncompressed)
        {
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);
            FriendsController.RemoveRequest(SessionId, req.reqId);
            return CompressRsp(GetBody(req.reqId));
        }

        public static byte[] FriendReqCancel(string SessionId, string Uncompressed)
        {
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);
            FriendsController.RemoveRequest(SessionId, req.req_Id);
            return CompressRsp(GetBody(req.req_Id));
        }

        public static byte[] FriendReqAccept(string SessionId)
        {
            FriendsController.AcceptAll(SessionId);
            return CompressRsp(NullResponse());
        }

        public static byte[] FriendListOutBox(string SessionId)
        {
            var inbox = FriendsController.GetFriendsOutbox(SessionId);
            return CompressRsp(GetBody(JsonConvert.SerializeObject(inbox)));
        }

        public static byte[] FriendListInBox(string SessionId)
        {
            var inbox = FriendsController.GetFriendsInbox(SessionId);
            return CompressRsp(GetBody(JsonConvert.SerializeObject(inbox)));
        }

        public static byte[] FriendMute(string SessionId, string Uncompressed)
        {
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);
            FriendsController.MuteFriend(SessionId,req.uid);
            return CompressRsp(NullResponse());
        }

        public static byte[] FriendUnMute(string SessionId, string Uncompressed)
        {
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);
            FriendsController.UnMuteFriend(SessionId, req.uid);
            return CompressRsp(NullResponse());
        }
    }
}
