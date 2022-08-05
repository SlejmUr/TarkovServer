using HttpServerLite;
using Newtonsoft.Json;
using ServerLib.Controllers;

namespace ServerLib.Web
{
    public class WebLogin
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/webprofile/login")]
        public virtual async Task GameStart(HttpContext ctx)
        {
            Console.WriteLine(ctx.Request.ToJson(true));
            // RPS
            string resp = AccountController.Login(ctx.Request.DataAsString);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.TrySendAsync(resp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/webprofile/register")]
        public virtual async Task LauncherRegister(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(ctx.Request.ToJson(true));
            // RPS
            string resp = AccountController.Register(ctx.Request.DataAsString);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/webprofile/wipe")]
        public virtual async Task LauncherWipe(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(ctx.Request.ToJson(true));
            var WipeProfile  = JsonConvert.DeserializeObject<Json.WebProfile.WebWipe>(ctx.Request.DataAsString);
            // RPS
            string resp = AccountController.SetWipe(WipeProfile.AccountId);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/webprofile/delete")]
        public virtual async Task LauncherDelete(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(ctx.Request.ToJson(true));
            var profile = JsonConvert.DeserializeObject<Json.WebProfile.WebAccount>(ctx.Request.DataAsString);
            // RPS
            string resp = AccountController.DeleteAccount(profile.AccountId, profile.Name);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }
    }
}
