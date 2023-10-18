using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Utilities;
using ModdableWebServer;
using ModdableWebServer.Attributes;

namespace ServerLib.Web
{
    public class ClientLocale
    {
        [HTTP("POST", "/client/languages")]
        public static bool GameLang(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            Utils.PrintRequest(request, serverStruct);
            var rsp = ResponseControl.GetBody(LocaleController.GetLanguages());
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/menu/locale/{locale}")]
        public static bool GameMenuLang(HttpRequest request, ServerStruct serverStruct)
        {
            string locale = serverStruct.Parameters["locale"];
            //REQ stuff
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.PrintRequest(request, serverStruct);
            Debug.PrintDebug("Locale: " + locale);
            var resp = ResponseControl.GetBody(LocaleController.GetMenu(locale, SessionId));
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/locale/{locale}")]
        public static bool GameLocaleLang(HttpRequest request, ServerStruct serverStruct)
        {
            string locale = serverStruct.Parameters["locale"];
            //REQ stuff
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            Utils.PrintRequest(request, serverStruct);
            var resp = ResponseControl.GetBody(LocaleController.GetLocale(locale, SessionId));
            Utils.SendUnityResponse(request, serverStruct, resp);
            return true;

        }
    }
}
