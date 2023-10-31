using ModdableWebServer;
using ModdableWebServer.Attributes;
using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Web
{
    public class SingleplayerSettings
    {

        [HTTP("GET", "/singleplayer/settings/bot/maxCap")]
        public static bool SSBotMaxCap(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            return ServerHelper.SendUnityResponse(request, serverStruct, "20");
        }

        [HTTP("GET", "/singleplayer/settings/raid/menu")]
        public static bool SSRaidMenu(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var defaultraid = JsonConvert.SerializeObject(ConfigController.Configs.Gameplay.Raid.DefaultRaidSettings);
            var resp = ResponseControl.NoBody(defaultraid);
            return ServerHelper.SendUnityResponse(request, serverStruct, resp);
        }

        [HTTP("GET", "/singleplayer/settings/bot/difficulty/{botname}/{difficulty}")]
        public static bool SSBotDiff(HttpRequest request, ServerStruct serverStruct)
        {
            string botname = serverStruct.Parameters["botname"];
            string difficulty = serverStruct.Parameters["difficulty"];
            ServerHelper.PrintRequest(request, serverStruct);
            //var difff = BotController.GetBotDifficulty(botname, difficulty);
            var resp = ResponseControl.NullResponse();
            return ServerHelper.SendUnityResponse(request, serverStruct, resp);
        }

        [HTTP("GET", "/singleplayer/airdrop/config")]
        public static bool SSAirdropConfig(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var defaultraid = JsonConvert.SerializeObject(ConfigController.Configs.Gameplay.Raid.AirdropSettings);
            var resp = ResponseControl.NoBody(defaultraid);
            return ServerHelper.SendUnityResponse(request, serverStruct, resp);
        }
    }
}
