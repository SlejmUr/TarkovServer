using HttpServerLite;
using ServerLib;
using ServerLib.Controllers;

namespace TestPlugin
{
    public class Class1
    {
        public void This()
        {
            //Console.WriteLine("Function inside a class");
        }

        [StaticRoute(HttpServerLite.HttpMethod.GET, "/test")]
        public async Task Testing(HttpContext ctx)
        {
            string resp = "OVERRIDED!";
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.GET, "/test2")]
        public async Task Test2(HttpContext ctx)
        {
            string resp = "test2 from a Plugin!";
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }
    }
}
