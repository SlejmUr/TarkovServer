using HttpServerLite;

namespace Tarkov_Server_Csharp.Web
{
    internal class Client_Game
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/start")]
        public virtual async Task GameStart(HttpContext ctx)
        {
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Console.WriteLine("SID : " + SessionID);
            string resp;
            // RPS
            var TimeThingy = Utils.UnixTimeNow().ToString().Replace(",", ".");
            TimeThingy = TimeThingy.Remove(TimeThingy.Length - 4);
            if (Controllers.AccountController.ClientHasProfile(SessionID))
            {
                resp = ResponseControl.GetBody("{\"utc_time\":" + TimeThingy + "}");
            }
            else
            {
                resp = ResponseControl.GetBody("{\"utc_time\":" + TimeThingy + "}", 999, "Profile Not Found!!");
            }
            var rsp = ResponseControl.CompressRsp(resp);
            Console.WriteLine(Utils.ByteArrayToString(rsp));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/menu/locale/en")]
        public virtual async Task GameMenuLang(HttpContext ctx)
        {
            //REQ stuff
            ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Console.WriteLine("SID : " + SessionID);

            var resp = ResponseControl.NullResponse();
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }
    }
}
