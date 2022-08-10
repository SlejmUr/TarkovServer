using HttpServerLite;
using ServerLib.Controllers;
using ServerLib.Utilities;
using ServerLib.Json;

namespace ServerLib.Web
{
    public class ClientRaid
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/raid/person/killed/showMessage")]
        public async Task ShowMessage(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            //REQ stuff
            GameplayConfig.Base gameplayBase = ConfigController.Configs.Gameplay;
            // RPS
            var rsp = ResponseControl.CompressRsp(gameplayBase.InRaid.ShowDeathMessage.ToString());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/raid/profile/save")]
        public async Task RaidSave(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            File.AppendAllText("saveAccount.json",decomp);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendAsync(rsp);
            return;
        }
    }
}
