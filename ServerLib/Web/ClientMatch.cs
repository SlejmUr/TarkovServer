using HttpServerLite;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;


namespace ServerLib.Web
{
    public class ClientMatch
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/match/available")]
        public async Task ClientMatchAvailable(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody("true"));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/match/offline/end")]
        public async Task ClientMatchOfflineEnd(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            //Class73<T, U, V> | (exitStatus, exitName, raidSeconds)

            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/match/join")]
        public async Task ClientMatchJoin(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/match/group/start_game")]
        public async Task ClientMatchStartGame(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/match/group/status")]
        public async Task ClientMatchGroupStatus(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/match/group/status")]
        public async Task ClientMatchGroupCreate(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);

            ACS.ClientGroupStatusJson clientGroupStatus = new();
            List<ACS.FromProfile> fromProfile = new();
            clientGroupStatus.Players = fromProfile.ToArray();

            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody(JsonConvert.SerializeObject(clientGroupStatus)));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }
    }
}
