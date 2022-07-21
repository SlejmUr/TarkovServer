using HttpServerLite;
using Newtonsoft.Json;
using Tarkov_Server_Csharp.Controllers;

namespace Tarkov_Server_Csharp.Web
{
    public class Client_Raid
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/raid/person/killed/showMessage")]
        public virtual async Task ShowMessage(HttpContext ctx)
        {
            //REQ stuff
            dynamic gameplayBase = JsonConvert.DeserializeObject(File.ReadAllText("configs/gameplay.json"));

            Console.WriteLine(gameplayBase.inRaid.showDeathMessage);
            // RPS
            string resp = "true";
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendAsync(rsp);
            return;
        }
    }
}
