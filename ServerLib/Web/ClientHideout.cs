using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class ClientHideout
    {
        [HTTP("POST", "/client/hideout/areas")]
        public static bool Areas(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Hideout.Areas);
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/hideout/production/recipes")]
        public static bool ProductionRecipes(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Hideout.Production);
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/hideout/production/scavcase/recipes")]
        public static bool ProductionScavcaseRecipes(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Hideout.Scavcase);
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/hideout/settings")]
        public static bool Settings(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = ResponseControl.GetBodyCRC(DatabaseController.DataBase.Hideout.Settings,0,"null", 4187301386);
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/hideout/qte/list")]
        public static bool QTEList(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Hideout.Qte);
            Utils.SendUnityResponse(session, resp);
            return true;
        }
    }
}
