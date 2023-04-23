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
            string SessionId = Utils.GetSessionId(session.Headers);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Hideout.Areas);
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/hideout/production/recipes")]
        public static bool ProductionRecipes(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Hideout.Production);
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/hideout/production/scavcase/recipes")]
        public static bool ProductionScavcaseRecipes(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Hideout.Scavcase);
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/hideout/settings")]
        public static bool Settings(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string resp = ResponseControl.GetBodyCRC(DatabaseController.DataBase.Hideout.Settings,0,"null", 4187301386);
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/hideout/qte/list")]
        public static bool QTEList(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Hideout.Qte);
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
    }
}
