using HttpServerLite;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;

namespace ServerLib.Web
{
    public class Client_Raid
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/raid/person/killed/showMessage")]
        public async Task ShowMessage(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            //REQ stuff
            dynamic gameplayBase = JsonConvert.DeserializeObject(DatabaseController.DataBase.Gameplay);
            // RPS
            string resp = gameplayBase.inRaid.showDeathMessage;
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendAsync(rsp);
            return;
        }
    }
}
