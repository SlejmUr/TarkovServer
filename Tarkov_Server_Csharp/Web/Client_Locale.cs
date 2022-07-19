using HttpServerLite;

namespace Tarkov_Server_Csharp.Web
{
    internal class Client_Locale
    {
        [ParameterRoute(HttpServerLite.HttpMethod.POST, "/client/menu/locale/{locale}")]
        public virtual async Task GameMenuLang(HttpContext ctx)
        {
            string locale = ctx.Request.Url.Parameters["locale"];
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Console.WriteLine("SID : " + SessionID);

            var resp = ResponseControl.GetBody(File.ReadAllText("Files/locales/" + locale + "/menu.json"));
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }
    }
}
