using ModdableWebServer;
using ModdableWebServer.Attributes;
using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Web
{
    public class ClientRaid
    {
        [HTTP("POST", "/client/raid/person/killed/showMessage")]
        public static bool ShowMessage(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string rsp = "False";
            // RPS
            if (ConfigController.Configs.Gameplay.Raid.InRaid.ShowDeathMessage.HasValue)
                rsp = ConfigController.Configs.Gameplay.Raid.InRaid.ShowDeathMessage.Value.ToString();
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/person/killed")]
        public static bool RaidKilled(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            CharacterController.RaidKilled(Uncompressed, SessionId);
            // RPS
            var rsp = "{}";
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/profile/save")]
        public static bool RaidSave(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(request.BodyBytes);
            File.AppendAllText("saveAccount.json", decomp);
            // RPS
            var rsp = ResponseControl.NullResponse();
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/person/lootingContainer")]
        public static bool RaidLootingContainer(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(request.BodyBytes);
            File.AppendAllText("lootingContainer.json", decomp);
            // RPS
            var rsp = ResponseControl.NullResponse();
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/configuration")]
        public static bool RaidConfig(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(request.BodyBytes);
            File.AppendAllText("RaidSettings.json", decomp);
            // RPS
            var rsp = ResponseControl.NullResponse();
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/configuration-by-profile")]
        public static bool RaidConfigByProfile(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(request.BodyBytes);
            File.AppendAllText("CoopRaidSettings.json", decomp);
            // RPS
            var rsp = ResponseControl.NullResponse();
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

    }
}
