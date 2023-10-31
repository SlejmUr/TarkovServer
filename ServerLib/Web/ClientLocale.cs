using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Utilities.Helpers;
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
            ServerHelper.PrintRequest(request, serverStruct);
            var rsp = ResponseControl.GetBody(LocaleController.GetLanguages());
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/menu/locale/{locale}")]
        public static bool GameMenuLang(HttpRequest request, ServerStruct serverStruct)
        {
            string locale = serverStruct.Parameters["locale"];
            //REQ stuff
            var session = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);
            var resp = ResponseControl.GetBody(LocaleController.GetMenu(locale, session));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/locale/{locale}")]
        public static bool GameLocaleLang(HttpRequest request, ServerStruct serverStruct)
        {
            string locale = serverStruct.Parameters["locale"];
            //REQ stuff
            var session = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);
            var resp = ResponseControl.GetBody(LocaleController.GetLocale(locale, session));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;

        }
    }
}
