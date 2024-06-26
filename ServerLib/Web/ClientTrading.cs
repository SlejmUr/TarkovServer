﻿using JsonLib.Classes.Response;
using ModdableWebServer;
using ModdableWebServer.Attributes;
using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Web
{
    public class ClientTrading
    {
        [HTTP("POST", "/client/trading/api/getTradersList")]
        public static bool ClientTradingApiGetTradersList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(TraderController.GetTradersInfo()));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/trading/api/traderSettings")]
        public static bool ClientTradingApiTraderSettings(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(TraderController.GetTradersInfo()));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/trading/api/getTraderAssort/{traderId}")]
        public static bool ClientTradingApiGetTraderAssort(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string traderId = serverStruct.Parameters["traderId"];
            string SessionId = serverStruct.Headers.GetSessionId();
            var assort = JsonConvert.SerializeObject(TraderController.GenerateFilteredAssort(SessionId, traderId));
            string resp = ResponseControl.GetBody(assort);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/trading/customization/storage")]
        public static bool ClientTradingCustomizationStorage(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            var profile = ProfileController.GetProfile(SessionId);
            ArgumentNullException.ThrowIfNull(profile);
            GetSuits suits = new()
            {
                _id = "pmc" + SessionId,
                suites = profile.Suits
            };
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(suits));
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }

        [HTTP("POST", "/client/trading/customization/{id}/offers")]
        public static bool ClientTradingCustomizationOffers(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string id = serverStruct.Parameters["id"];
            var suits = JsonConvert.SerializeObject(TraderController.GetSuitsByTrader(id));

            string resp = ResponseControl.GetBody(suits);
            ServerHelper.SendUnityResponse(request, serverStruct, resp);
            return true;
        }
    }
}
