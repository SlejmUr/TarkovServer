using HttpServerLite;
using ServerLib.Controllers;
using ServerLib.Utilities;

namespace ServerLib.Web
{
    public class ClientGame
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/start")]
        public async Task GameStart(HttpContext ctx)
        {
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Utils.PrintRequest(ctx.Request);
            string resp;
            // RPS
            var TimeThingy = Utils.UnixTimeNow_Int();
            if (AccountController.ClientHasProfile(SessionID))
            {
                resp = ResponseControl.GetBody("{\"utc_time\":" + TimeThingy + "}");
            }
            else
            {
                resp = ResponseControl.GetBody("{\"utc_time\":" + TimeThingy + "}", 999, "Profile Not Found!!");
            }
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/keepalive")]
        public async Task GameKeepalive(HttpContext ctx)
        {
            //REQ stuff
            string resp;
            Utils.PrintRequest(ctx.Request);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            var TimeThingy = Utils.UnixTimeNow_Int();
            if (SessionID == null)
            {
                resp = ResponseControl.GetBody("{\"msg\":\"No Session\", \"utc_time\":" + TimeThingy + "}");
            }
            else
            {
                //KeepAlive(sessionID);
                resp = ResponseControl.GetBody("{\"msg\":\"OK\", \"utc_time\":" + TimeThingy + "}");
            }
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/version/validate")]
        public async Task GameVersionValidate(HttpContext ctx)
        {
            //REQ stuff
            string resp;
            Utils.PrintRequest(ctx.Request);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            string version = Utils.GetVersion(ctx.Request.Headers);
            if (AccountController.FindAccount(SessionID) != null)
            {
                Utils.PrintDebug($"User ({SessionID}) connected with client version {version}");
            }
            else
            {
                Utils.PrintDebug($"Unknown User connected with client version {version}");
            }
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }
    }
}
