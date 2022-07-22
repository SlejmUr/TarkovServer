using HttpServerLite;
using ServerLib.Controllers;

namespace ServerLib.Web
{
    public class WebLogin
    {
        /*
        Currently this ?u=x&m=x&e=eod&p=x NOT Working
        in BODY send this:
        {
            "username": "YOURNAME",
            "email": "YOURNAME",
	        "password": "YOURPASSWORD",
            "edition": "Edge Of Darkness",
        }
        and will work!
        */
        /*
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
        }*/
    }
}
