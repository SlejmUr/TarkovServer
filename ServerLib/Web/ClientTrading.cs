using HttpServerLite;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities;

namespace ServerLib.Web
{
    public class ClientTrading
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/trading/api/getTradersList")]
        public async Task ClientTradingApiGetTradersList(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(TraderController.GetTradersInfo()));
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/trading/api/traderSettings")]
        public async Task ClientTradingApiTraderSettings(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(TraderController.GetTradersInfo()));
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/trading/customization/storage")]
        public async Task ClientTradingCustomizationStorage(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            string resp = ResponseControl.GetBody(File.ReadAllText(SaveHandler.GetStoragePath(SessionID)));
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [ParameterRoute(HttpServerLite.HttpMethod.GET, "/client/trading/customization/{id}/offers")]
        public async Task x(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string id = ctx.Request.Url.Parameters["id"];
            var suits = JsonConvert.SerializeObject(DatabaseController.DataBase.Traders[id].Suits);

            string resp = ResponseControl.GetBody(suits);
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }
    }
}
