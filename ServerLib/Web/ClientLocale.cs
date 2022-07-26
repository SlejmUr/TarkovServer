using HttpServerLite;
using ServerLib.Controllers;
using ServerLib.Utilities;

namespace ServerLib.Web
{
    public class ClientLocale
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/languages")]
        public async Task GameLang(HttpContext ctx)
        {
            //REQ stuff
            Utils.PrintRequest(ctx.Request);
            var resp = ResponseControl.GetBody(LocaleController.GetLanguages());
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }

        [ParameterRoute(HttpServerLite.HttpMethod.POST, "/client/menu/locale/{locale}")]
        public async Task GameMenuLang(HttpContext ctx)
        {
            string locale = ctx.Request.Url.Parameters["locale"];
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Utils.PrintRequest(ctx.Request);
            string account_lang = AccountController.FindAccount(SessionID).Lang;
            var resp = ResponseControl.GetBody(LocaleController.GetMenu(account_lang, locale, SessionID));
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }

        [ParameterRoute(HttpServerLite.HttpMethod.POST, "/client/locale/{locale}")]
        public virtual async Task GameLocaleLang(HttpContext ctx)
        {
            string locale = ctx.Request.Url.Parameters["locale"];
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Utils.PrintRequest(ctx.Request);
            string account_lang = AccountController.FindAccount(SessionID).Lang;
            var resp = ResponseControl.GetBody(LocaleController.GetLocale(account_lang, locale, SessionID));
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }
    }
}
