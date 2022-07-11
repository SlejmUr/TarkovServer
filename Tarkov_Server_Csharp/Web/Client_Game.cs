using HttpServerLite;

namespace Tarkov_Server_Csharp.Web
{
    internal class Client_Game
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/start")]
        public virtual async Task GameStart(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(ctx.Request.ToJson(true));
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Console.WriteLine("SID : " + SessionID);
            string resp;
            // RPS

            var TimeThingy = Utils.UnixTimeNow().ToString().Replace(",", ".");
            if (Controllers.AccountController.ClientHasProfile(SessionID))
            {
                resp = ResponseControl.GetBody("{\"utc_time\":" + TimeThingy + "}");
            }
            else
            {
                resp = ResponseControl.GetBody("{\"utc_time\":" + TimeThingy + "}", 999, "Profile Not Found!!");
            }
            Console.WriteLine(resp);
            var rsp = ResponseControl.CompressRsp(resp);
            Console.WriteLine(Utils.ByteArrayToString(rsp));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            ctx.Response.Headers.Add("Cookie", "PHPSESSID=" + SessionID);
            Console.WriteLine("Response Sent:" + ctx.Response.ToJson(true));
            
            await ctx.Response.SendWithoutCloseAsync(rsp);
            //Console.WriteLine("Response Sent:" + ctx.Response.ToJson(true));
            return;
        }
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/menu/locale/en")]
        public virtual async Task GameMenuLang(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(ctx.Request.ToJson(true));
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Console.WriteLine("SID : " + SessionID);

            var resp = ResponseControl.NullResponse();
            var rsp = ResponseControl.CompressRsp(resp);
            Console.WriteLine(Utils.ByteArrayToString(rsp));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            ctx.Response.Headers.Add("Content-Type", "application/json");
            ctx.Response.Headers.Add("Cookie", "PHPSESSID=" + SessionID);
            Console.WriteLine("Response Sent:" + ctx.Response.ToJson(true));

            await ctx.Response.SendWithoutCloseAsync(rsp);
            //Console.WriteLine("Response Sent:" + ctx.Response.ToJson(true));
            return;
        }
    }
}
