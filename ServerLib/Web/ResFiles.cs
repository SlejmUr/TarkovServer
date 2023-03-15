using HttpServerLite;
using ServerLib.Utilities;

namespace ServerLib.Web
{
    public class ResFiles
    {

        [ParameterRoute(HttpServerLite.HttpMethod.GET, "/files/trader/avatar/{avatar}")]
        public async Task GetFilesAvatar(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string avatar = ctx.Request.Url.Parameters["avatar"].Replace("jpg", "png");
            byte[] rsp;
            if (!File.Exists($"Files/res/trader/{avatar}"))
            {
                rsp = File.ReadAllBytes($"Files/res/noimage/avatar.png");
            }
            else
            {
                rsp = File.ReadAllBytes($"Files/res/trader/{avatar}");
            }
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "image/png";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }

        [ParameterRoute(HttpServerLite.HttpMethod.GET, "/files/handbook/{handbook}")]
        public async Task GetFilesHandbook(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string handbook = ctx.Request.Url.Parameters["handbook"].Replace("jpg", "png");
            byte[] rsp;
            if (!File.Exists($"Files/res/handbook/{handbook}"))
            {
                rsp = File.ReadAllBytes($"Files/res/noimage/handbook.png");
            }
            else
            {
                rsp = File.ReadAllBytes($"Files/res/handbook/{handbook}");
            }
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "image/png";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }

        [ParameterRoute(HttpServerLite.HttpMethod.GET, "/files/Hideout/{Hideout}")]
        public async Task GetFilesHideout(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string Hideout = ctx.Request.Url.Parameters["Hideout"].Replace("jpg", "png");
            byte[] rsp;
            if (!File.Exists($"Files/res/hideout/{Hideout}"))
            {
                rsp = File.ReadAllBytes($"Files/res/noimage/hideout.png");
            }
            else
            {
                rsp = File.ReadAllBytes($"Files/res/hideout/{Hideout}");
            }
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "image/png";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }

        [ParameterRoute(HttpServerLite.HttpMethod.GET, "/files/quest/icon/{quest}")]
        public async Task GetFilesQuestIcon(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string quest = ctx.Request.Url.Parameters["quest"].Replace("jpg", "png");
            byte[] rsp;
            if (!File.Exists($"Files/res/quest/{quest}"))
            {
                rsp = File.ReadAllBytes($"Files/res/noimage/quest.png");
            }
            else
            {
                rsp = File.ReadAllBytes($"Files/res/quest/{quest}");
            }
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "image/png";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }

    }
}
