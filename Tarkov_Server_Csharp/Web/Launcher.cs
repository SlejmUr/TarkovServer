using HttpServerLite;
using Ionic.Zlib;

namespace Tarkov_Server_Csharp.Web
{
    internal class Launcher
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/launcher/profile/login")]
        public static async Task LauncherLogin(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(ctx.Request.ContentType);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);
            Console.WriteLine(Uncompressed);
            Console.WriteLine("Headers:\n" + string.Join("\n", ctx.Request.Headers.Select(pair => $"{pair.Key} => {pair.Value}")));

            // RPS
            string resp = Controllers.Profile.Login(Uncompressed);
            var rsp = ZlibStream.CompressString(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/launcher/profile/register")]
        public static async Task LauncherRegister(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(ctx.Request.ContentType);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);
            Console.WriteLine(Uncompressed);
            Console.WriteLine("Headers:\n" + string.Join("\n", ctx.Request.Headers.Select(pair => $"{pair.Key} => {pair.Value}")));

            // RPS
            string resp = Controllers.Profile.Register(Uncompressed);
            var rsp = ZlibStream.CompressString(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }
    }
}
