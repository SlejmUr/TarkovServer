using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class ClientLocale
    {
        [HTTP("POST", "/client/languages")]
        public static bool GameLang(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            Utils.PrintRequest(request, session);
            var rsp = ResponseControl.GetBody(LocaleController.GetLanguages());
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/menu/locale/{locale}")]
        public static bool GameMenuLang(HttpRequest request, HttpsBackendSession session)
        {
            string locale = session.HttpParam["locale"];
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            Debug.PrintDebug("Locale: " + locale);
            var resp = ResponseControl.GetBody(LocaleController.GetMenu(locale, SessionId));
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/locale/{locale}")]
        public static bool GameLocaleLang(HttpRequest request, HttpsBackendSession session)
        {
            string locale = session.HttpParam["locale"];
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            var resp = ResponseControl.GetBody(LocaleController.GetLocale(locale, SessionId));
            Utils.SendUnityResponse(session, resp);
            return true;

        }
    }
}
