using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Utilities;
using ModdableWebServer;
using ModdableWebServer.Attributes;

namespace ServerLib.Web
{
    public class ClientRaid
    {
        [HTTP("POST", "/client/raid/person/killed/showMessage")]
        public static bool ShowMessage(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            // RPS
            var rsp = ConfigController.Configs.Gameplay.Raid.InRaid.ShowDeathMessage.ToString();
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/person/killed")]
        public static bool RaidKilled(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string SessionId = Utils.GetSessionId(serverStruct.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            CharacterController.RaidKilled(Uncompressed, SessionId);
            // RPS
            var rsp = "{}";
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/profile/save")]
        public static bool RaidSave(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(request.BodyBytes);
            File.AppendAllText("saveAccount.json", decomp);
            // RPS
            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/person/lootingContainer")]
        public static bool RaidLootingContainer(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(request.BodyBytes);
            File.AppendAllText("lootingContainer.json", decomp);
            // RPS
            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/configuration")]
        public static bool RaidConfig(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(request.BodyBytes);
            File.AppendAllText("RaidSettings.json", decomp);
            // RPS
            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/configuration-by-profile")]
        public static bool RaidConfigByProfile(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(request.BodyBytes);
            File.AppendAllText("CoopRaidSettings.json", decomp);
            // RPS
            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

    }
}
