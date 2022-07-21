using HttpServerLite;

namespace Tarkov_Server_Csharp
{
    internal class ModTest : WebServer
    {
        /*
        public override async Task Test(HttpContext ctx)
        {
            string resp = "OVERRIDED!";
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }*/
    }
}
