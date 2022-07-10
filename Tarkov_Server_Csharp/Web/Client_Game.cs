using HttpServerLite;
using Ionic.Zlib;
using ComponentAce.Compression.Libs.zlib;
using System.Text;

namespace Tarkov_Server_Csharp.Web
{
    internal class Client_Game
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/start")]
        public virtual async Task GameStart(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(Utils.ByteArrayToString(ctx.Request.DataAsBytes));

            //Console.WriteLine(ctx.Request.ToJson(true));
            //Console.WriteLine("Headers:\n" + string.Join("\n", ctx.Request.Headers.Select(pair => $"{pair.Key} => {pair.Value}")));
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Console.Write("SID : " + SessionID);
            string resp;
            // RPS

            var TimeThingy = (Utils.UnixTimeNow() / 1000).ToString().Replace(",", ".");
            if (Controllers.AccountController.ClientHasProfile(SessionID))
            {
                resp = Response.GetBody("{\"utc_time\":" + TimeThingy.Remove(TimeThingy.Length - 4) + "}");
            }
            else
            {
                resp = Response.GetBody("{\"utc_time\":" + TimeThingy.Remove(TimeThingy.Length - 4) + "}", 999, "Profile Not Found!!");
            }

            //DECODE AS BASE64!!!

            byte[] rsp = ZlibStream.CompressString(resp);
            //byte[]  rsp = DeflateStream.CompressString(resp);
            //Pooled9LevelZLib.CompressToBytesNonAlloc(resp, rsp);
            Console.WriteLine("RSP: " + resp + " L: " + rsp.Length + " rsp byte:\n" + Utils.ByteArrayToString(rsp));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            ctx.Response.Headers.Add("Content-Type", "application/json");
            ctx.Response.Headers.Add("Cookie", "PHPSESSID=" + SessionID);
            await ctx.Response.SendWithoutCloseAsync(rsp);
            Console.WriteLine("Response Sent:" + ctx.Response.ToJson(true));
            return;
        }

    }
}
