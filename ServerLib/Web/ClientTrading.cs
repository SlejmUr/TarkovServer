using NetCoreServer;
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
            string resp = File.ReadAllText("Files/static/traderList.json");
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/trading/api/getTraderAssort/{traderId}")]
        public static bool ClientTradingApiGetTraderAssort(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string traderId = session.HttpParam["traderId"];
            string resp = File.ReadAllText($"Files/assort/{traderId}.json");
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/trading/api/getTrader/{traderId}")]
        public static bool ClientTradingApiGetTrader(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string traderId = session.HttpParam["traderId"];
            string resp = File.ReadAllText($"Files/traders/{traderId}.json");
            Utils.SendUnityResponse(session, resp);
            return true;
        }

        [HTTP("POST", "/client/trading/api/getUserAssortPrice/trader/{TraderId}")]
        public static bool ClientTradingApiGetUserAssortPriceTrader(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string traderId = session.HttpParam["traderId"];
            string resp = File.ReadAllText($"Files/static/purchases.json");
            Utils.SendUnityResponse(session, resp);
            return true;
        }
    }
}
