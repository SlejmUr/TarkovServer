using HttpServerLite;
using ServerLib.Controllers;
using ServerLib.Utilities;
using Newtonsoft.Json;

namespace ServerLib.Web
{
    public class Client
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/checkVersion")]
        public async Task ClientCheckVersion(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string resp;
            string version = Utils.GetVersion(ctx.Request.Headers);
            var server = DatabaseController.DataBase.Server;

            if (string.IsNullOrWhiteSpace(server.Version))
            {
                resp = ResponseControl.GetBody("{ isvalid: true, latestVersion: \"" + server.Version + "\"}");
            }
            else
            {
                if (server.Version == version)
                {
                    resp = ResponseControl.GetBody("{ isvalid: true, latestVersion: \"" + server.Version + "\"}");
                }
                else
                {
                    resp = ResponseControl.GetBody("{ isvalid: false, latestVersion: \""+ server.Version + "\"}");
                }         
            }
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/repeatalbeQuests/activityPeriods")]
        public async Task ClientRepeatableQuestsActivityPeriods(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string resp = ResponseControl.GetBody("[]");
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/chatServer/list")]
        public async Task ClientChatServerList(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            Json.Other.ChatServerList chatServerList = new();
            chatServerList.DateTime = (int)Utils.UnixTimeNow();
            chatServerList.Regions.Add("EUR");
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(chatServerList));
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }


        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/items")]
        public async Task ClientItems(HttpContext ctx)
        {
            Utils.PrintRequest(ctx.Request);
            string resp = ResponseControl.GetBody(File.ReadAllText("Files/items/items.json"));
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }
    }
}
