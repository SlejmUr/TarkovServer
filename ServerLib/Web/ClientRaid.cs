using HttpServerLite;
using Newtonsoft.Json;
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
            GameplayConfig.Base gameplayBase = DatabaseController.DataBase.Gameplay;
            // RPS
            var rsp = ResponseControl.CompressRsp(gameplayBase.InRaid.ShowDeathMessage.ToString());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendAsync(rsp);
            return;
        }
    }
}
