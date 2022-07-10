using HttpServerLite;
using Ionic.Zlib;
using Newtonsoft.Json;

namespace Tarkov_Server_Csharp.Web
{
    internal class Client_Raid
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/raid/person/killed/showMessage")]
        public virtual async Task ShowMessage(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(ctx.Request.ContentType);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);
            Console.WriteLine(Uncompressed);
            Console.WriteLine("Headers:\n" + string.Join("\n", ctx.Request.Headers.Select(pair => $"{pair.Key} => {pair.Value}")));

            dynamic gameplayBase = JsonConvert.DeserializeObject(File.ReadAllText("configs/gameplay.json"));

            Console.WriteLine(gameplayBase.inRaid.showDeathMessage);
            // RPS
            string resp = "true";
            var rsp = ZlibStream.CompressString(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }
    }
}
