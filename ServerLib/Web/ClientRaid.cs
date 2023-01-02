using HttpServerLite;
using ServerLib.Controllers;
using ServerLib.Utilities;

namespace ServerLib.Web
{
    public class ClientRaid
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/raid/person/killed/showMessage")]
        public async Task ShowMessage(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            // RPS
            var rsp = ResponseControl.CompressRsp(ConfigController.Configs.Gameplay.InRaid.ShowDeathMessage.ToString());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/raid/person/killed")]
        public async Task RaidKilled(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            CharacterController.RaidKilled(Uncompressed, SessionID);
            // RPS
            var rsp = ResponseControl.CompressRsp("{}");
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/raid/profile/save")]
        public async Task RaidSave(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            File.AppendAllText("saveAccount.json", decomp);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/raid/person/lootingContainer")]
        public async Task RaidLootingContainer(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            File.AppendAllText("lootingContainer.json", decomp);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/raid/configuration")]
        public async Task RaidConfig(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            File.AppendAllText("saveAccount.json", decomp);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/raid/configuration-by-profile")]
        public async Task RaidConfigByProfile(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            File.AppendAllText("saveAccount.json", decomp);
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
