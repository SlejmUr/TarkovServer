using HttpServerLite;
using Newtonsoft.Json;
using ServerLib.Controllers;

namespace ServerLib.Web
{
    public class ServerConfig
    {
        [StaticRoute(HttpServerLite.HttpMethod.GET, "/server/config/server")]
        public async Task ConfigServer(HttpContext ctx)
        {
            string resp = "";
            if (ConfigController.Configs.CustomSettings.Server.PublicConfigEnabled)
            {
                resp = JsonConvert.SerializeObject(ConfigController.Configs.Server);
            }
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.GET, "/server/config/gameplay")]
        public async Task ConfigGameplay(HttpContext ctx)
        {
            string resp = "";
            if (ConfigController.Configs.CustomSettings.Server.PublicConfigEnabled)
            {
                resp = JsonConvert.SerializeObject(ConfigController.Configs.Gameplay);
            }
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.GET, "/server/config/plugin")]
        public async Task ConfigPlugin(HttpContext ctx)
        {
            string resp = "";
            if (ConfigController.Configs.CustomSettings.Server.PublicConfigEnabled)
            {
                resp = JsonConvert.SerializeObject(ConfigController.Configs.Plugins);
            }
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.GET, "/server/config/custom")]
        public async Task ConfigCustom(HttpContext ctx)
        {
            string resp = "";
            if (ConfigController.Configs.CustomSettings.Server.PublicConfigEnabled)
            {
                resp = JsonConvert.SerializeObject(ConfigController.Configs.CustomSettings);
            }
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }
    }
}
