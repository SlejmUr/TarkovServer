using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class ClientTrading
    {
        [HTTP("POST", "/client/trading/api/getTradersList")]
        public static bool ClientTradingApiGetTradersList(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(TraderController.GetTradersInfo()));
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/trading/api/traderSettings")]
        public static bool ClientTradingApiTraderSettings(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(TraderController.GetTradersInfo()));
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/trading/api/getTraderAssort/{traderId}")]
        public static bool ClientTradingApiGetTraderAssort(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string traderId = session.HttpParam["traderId"];
            string SessionId = Utils.GetSessionId(session.Headers);
            var assort = JsonConvert.SerializeObject(TraderController.GenerateFilteredAssort(SessionId, traderId));
            string resp = ResponseControl.GetBody(assort);
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/trading/api/getUserAssortPrice/trader/{traderId}")]
        public static bool ClientTradingApiGetUserAssortPriceTrader(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string traderId = session.HttpParam["traderId"];
            string SessionId = Utils.GetSessionId(session.Headers);
            var assort = JsonConvert.SerializeObject(TraderController.GetPurchasesData(SessionId, traderId));
            string resp = ResponseControl.GetBody(assort);
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/trading/customization/storage")]
        public static bool ClientTradingCustomizationStorage(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string resp = ResponseControl.GetBody(File.ReadAllText(SaveHandler.GetStoragePath(SessionId)));
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/trading/customization/{id}/offers")]
        public static bool ClientTradingCustomizationOffers(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string id = session.HttpParam["id"];
            var suits = JsonConvert.SerializeObject(TraderController.GetSuitsByTrader(id));

            string resp = ResponseControl.GetBody(suits);
            var rsp = ResponseControl.CompressRsp(resp);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
    }
}
