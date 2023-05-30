using Newtonsoft.Json;
using ServerLib.Controllers;
using static ServerLib.Web.ResponseControl;

namespace ServerLib.Responders
{
    public static class Friend
    {
        public static string FriendList(string SessionId)
        {
            Json.Classes.FriendList friendsList = FriendsController.GetFriendList(SessionId);
            return GetBody(JsonConvert.SerializeObject(friendsList));
        }

        public static string FriendDelete(string SessionId, string Uncompressed)
        {
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendId>(Uncompressed);
            FriendsController.RemoveFriend(SessionId, req.friend_id);
            return NullResponse();
        }

        public static string FriendReqSend(string SessionId, string Uncompressed)
        {
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);

            var reqID = FriendsController.AddRequest(SessionId, req.toId);
            FriendSendJson friendRsp = new()
            {
                RequestId = reqID,
                RetryAfter = 30,
                Error = 0
            };
            return GetBody(JsonConvert.SerializeObject(friendRsp));
        }

        public static string FriendReqDecline(string SessionId, string Uncompressed)
        {
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);
            FriendsController.RemoveRequest(SessionId, req.reqId);
            return GetBody(req.reqId);
        }

        public static string FriendReqCancel(string SessionId, string Uncompressed)
        {
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);
            FriendsController.RemoveRequest(SessionId, req.req_Id);
            return GetBody(req.req_Id);
        }

        public static string FriendReqAccept(string SessionId)
        {
            FriendsController.AcceptAll(SessionId);
            return NullResponse();
        }

        public static string FriendListOutBox(string SessionId)
        {
            var inbox = FriendsController.GetFriendsOutbox(SessionId);
            return GetBody(JsonConvert.SerializeObject(inbox));
        }

        public static string FriendListInBox(string SessionId)
        {
            var inbox = FriendsController.GetFriendsInbox(SessionId);
            return GetBody(JsonConvert.SerializeObject(inbox));
        }

        public static string FriendMute(string SessionId, string Uncompressed)
        {
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);
            FriendsController.MuteFriend(SessionId,req.uid);
            return NullResponse();
        }

        public static string FriendUnMute(string SessionId, string Uncompressed)
        {
            var req = JsonConvert.DeserializeObject<Json.Classes.FriendsReq>(Uncompressed);
            FriendsController.UnMuteFriend(SessionId, req.uid);
            return NullResponse();
        }
    }
}
