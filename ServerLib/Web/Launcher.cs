using HttpServerLite;
using Ionic.Zlib;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;

namespace ServerLib.Web
{
    public class Launcher
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/launcher/profile/login")]
        public async Task LauncherLogin(HttpContext ctx)
        {
            //REQ stuff
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);
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
        public async Task LauncherRegister(HttpContext ctx)
        {
            //REQ stuff
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);

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

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/launcher/profile/get")]
        public async Task LauncherGet(HttpContext ctx)
        {
            //REQ stuff
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);

            // RPS
            string resp = JsonConvert.SerializeObject(AccountController.FindAccount(Uncompressed));
            var rsp = ZlibStream.CompressString(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/launcher/profile/remove")]
        public async Task LauncherRemove(HttpContext ctx)
        {
            //REQ stuff
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);

            // RPS
            Console.WriteLine(Uncompressed);
            string resp = AccountController.RemoveAccount(Uncompressed);
            var rsp = ZlibStream.CompressString(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/launcher/profile/change/email")]
        public async Task LauncherChangeEmail(HttpContext ctx)
        {
            //REQ stuff
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);

            // RPS
            string resp = AccountController.ChangeEmail(Uncompressed);
            var rsp = ZlibStream.CompressString(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/launcher/profile/change/password")]
        public async Task LauncherChangePassword(HttpContext ctx)
        {
            //REQ stuff
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);

            // RPS
            string resp = AccountController.ChangePassword(Uncompressed);
            var rsp = ZlibStream.CompressString(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }


        [StaticRoute(HttpServerLite.HttpMethod.POST, "/launcher/profile/change/wipe")]
        public async Task LauncherChangeWipe(HttpContext ctx)
        {
            //REQ stuff
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);

            // RPS
            Console.WriteLine(Uncompressed);
            var resp = AccountController.SetWipe(Uncompressed);
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
