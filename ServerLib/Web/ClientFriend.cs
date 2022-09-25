using HttpServerLite;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Json;
using ServerLib.Utilities;


namespace ServerLib.Web
{
    public class ClientFriend
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/friend/list")]
        public async Task FriendList(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);

            Other.FriendsList friendsList = new Other.FriendsList();
            friendsList.Friends.Add(FriendsController.GetFriends(SessionID));

            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(friendsList));
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/friend/request/send")]
        public async Task FriendReqSend(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);

            string Uncompressed = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            var req = JsonConvert.DeserializeObject<Other.FriendsReq>(Uncompressed);

            var reqID = FriendsController.AddRequest(SessionID, req.toId);
            Other.AddFriendRsp friendRsp = new Other.AddFriendRsp();
            friendRsp.RequestId = reqID;

            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(friendRsp));
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/friend/request/decline")]
        public async Task FriendReqDecline(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);

            string Uncompressed = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            var req = JsonConvert.DeserializeObject<Other.FriendsReq>(Uncompressed);

            FriendsController.RemoveFriend(SessionID, req.req_Id);

            string resp = ResponseControl.NullResponse();
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/friend/request/cancel")]
        public async Task FriendReqCancel(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);

            string Uncompressed = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            var req = JsonConvert.DeserializeObject<Other.FriendsReq>(Uncompressed);

            var reqID = FriendsController.RemoveRequest(SessionID, req.reqId);

            string resp = ResponseControl.GetBody(reqID);
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/friend/request/accept")]
        public async Task FriendReqAccept(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);

            FriendsController.AcceptAll(SessionID);

            string resp = ResponseControl.GetBody("OK");
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/friend/request/accept-all")]
        public async Task FriendReqAcceptAll(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);

            FriendsController.AcceptAll(SessionID);

            string resp = ResponseControl.GetBody("OK");
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/friend/request/list/outbox")]
        public async Task FriendListOutBox(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);

            var inbox = FriendsController.GetFriendsOutbox(SessionID);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(inbox));

            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/friend/request/list/inbox")]
        public async Task FriendListInBox(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);

            var inbox = FriendsController.GetFriendsInbox(SessionID);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(inbox));

            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }
    }
}
