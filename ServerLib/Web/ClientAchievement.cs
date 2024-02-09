using ModdableWebServer.Attributes;
using ModdableWebServer;
using NetCoreServer;
using ServerLib.Utilities.Helpers;
using Newtonsoft.Json;
using ServerLib.Controllers;

namespace ServerLib.Web
{
    internal class ClientAchievement
    {
        [HTTP("POST", "/client/achievement/list")]
        public static bool AchievementList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();

            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(AchievementController.GetAchievements()));
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/achievement/statistic")]
        public static bool AchievementStatistic(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();

            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(AchievementController.GetAchievementStatistics()));
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }
    }
}
