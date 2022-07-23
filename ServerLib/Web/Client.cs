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
            dynamic server = JsonConvert.DeserializeObject<dynamic>(DatabaseController.DataBase.Server);

            if (string.IsNullOrWhiteSpace(server.version))
            {
                resp = ResponseControl.GetBody("{ isvalid: true, latestVersion: \"\"}");
            }
            else
            {
                if (server.version == version)
                {
                    resp = ResponseControl.GetBody("{ isvalid: true, latestVersion: \"\"}");
                }
                else
                {
                    resp = ResponseControl.GetBody("{ isvalid: false, latestVersion: \""+ server.version + "\"}");
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
