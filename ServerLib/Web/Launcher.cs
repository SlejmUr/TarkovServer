using HttpServerLite;
using Ionic.Zlib;
using ServerLib.Controllers;

namespace ServerLib.Web
{
    public class Launcher
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/launcher/profile/login")]
        public virtual async Task LauncherLogin(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(ctx.Request.ContentType);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);
            Console.WriteLine(Uncompressed);
            Console.WriteLine("Headers:\n" + string.Join("\n", ctx.Request.Headers.Select(pair => $"{pair.Key} => {pair.Value}")));

            // RPS
            string resp = AccountController.Login(Uncompressed);
            var rsp = ZlibStream.CompressString(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/launcher/profile/register")]
        public virtual async Task LauncherRegister(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(ctx.Request.ContentType);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);
            Console.WriteLine(Uncompressed);
            Console.WriteLine("Headers:\n" + string.Join("\n", ctx.Request.Headers.Select(pair => $"{pair.Key} => {pair.Value}")));

            // RPS
            string resp = AccountController.Register(Uncompressed);
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
