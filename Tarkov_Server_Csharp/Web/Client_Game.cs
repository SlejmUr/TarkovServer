using HttpServerLite;
using Ionic.Zlib;

namespace Tarkov_Server_Csharp.Web
{
    internal class Client_Game
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/start")]
        public static async Task GameStart(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(ctx.Request.ContentType);
            Console.WriteLine("Headers:\n" + string.Join("\n", ctx.Request.Headers.Select(pair => $"{pair.Key} => {pair.Value}")));
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);
            Console.WriteLine(Uncompressed);

            string resp;
            // RPS
            if (Controllers.Profile.ClientHasProfile(Uncompressed))
            {
                resp = Response.GetBody("{ utc_time: " + (UnixTimeNow() / 1000) + " }");
            }
            else
            {
                resp = Response.GetBody("{ utc_time: " +  (UnixTimeNow() / 1000) + " }",999, "Profile Not Found!!");
            }

            var rsp = ZlibStream.CompressString(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }
        public static long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }
    }
}
