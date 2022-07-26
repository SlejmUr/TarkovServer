using HttpServerLite;
using ServerLib.Controllers;
using ServerLib.Utilities;
using Newtonsoft.Json;

namespace ServerLib.Web
{
    public class SingleplayerSettings
    {

        [StaticRoute(HttpServerLite.HttpMethod.GET, "/singleplayer/settings/bot/maxCap")]
        public async Task SSBotMaxCap(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            var rsp = ResponseControl.CompressRsp("20");
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.GET, "/singleplayer/settings/raid/menu")]
        public async Task SSRaidMenu(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            var defaultraid = JsonConvert.SerializeObject(DatabaseController.DataBase.Gameplay.DefaultRaidSettings);
            var rsp = ResponseControl.CompressRsp(ResponseControl.NoBody(defaultraid));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [ParameterRoute(HttpServerLite.HttpMethod.GET, "/singleplayer/settings/bot/difficulty/{botname}/{difficulty}")]
        public async Task SSBotDiff(HttpContext ctx)
        {
            string botname = ctx.Request.Url.Parameters["botname"];
            string difficulty = ctx.Request.Url.Parameters["difficulty"];
            Utils.PrintRequest(ctx.Request);
            var difff = BotController.GetBotDifficulty(botname, difficulty);
            var rsp = ResponseControl.CompressRsp(ResponseControl.NoBody(difff));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }
    }
}
