using ModdableWebServer;
using ModdableWebServer.Attributes;
using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Web
{
    public class ClientHideout
    {
        [HTTP("POST", "/client/hideout/areas")]
        public static bool Areas(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Hideout.Areas);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/hideout/production/recipes")]
        public static bool ProductionRecipes(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Hideout.Production);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/hideout/production/scavcase/recipes")]
        public static bool ProductionScavcaseRecipes(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Hideout.Scavcase);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/hideout/settings")]
        public static bool Settings(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBodyCRC(DatabaseController.DataBase.Hideout.Settings, 0, "null", 4187301386);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/hideout/qte/list")]
        public static bool QTEList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(DatabaseController.DataBase.Hideout.Qte);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }
    }
}
