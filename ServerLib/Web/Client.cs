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
                resp = ResponseControl.GetBody("{ isvalid: true, latestVersion: \"\"}");
            }
            else
            {
                if (server.Version == version)
                {
                    resp = ResponseControl.GetBody("{ isvalid: true, latestVersion: \"\"}");
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
    }
}
