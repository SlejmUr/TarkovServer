using JsonLib.Classes.Response;
using ModdableWebServer;
using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities.Helpers;
using System.Text;
using static ServerLib.Web.ResponseControl;

namespace ServerLib.Responders
{
    public class ClientRespond
    {
        public static string GetVersion(HttpRequest request, ServerStruct serverStruct)
        {
            string SessionId = serverStruct.Headers.GetSessionId();
            string version = serverStruct.Headers.GetVersion();
            var server = ConfigController.Configs.Server;
            CheckVersionResponse versionResponse = new()
            {
                latestVersion = server.Version,
                isvalid = true
            };
            if (!string.IsNullOrWhiteSpace(server.Version))
            {
                if (server.Version != version)
                {
                    versionResponse.isvalid = false;
                }
            }
            var rsp = JsonConvert.SerializeObject(versionResponse);
            var hash = CRCHelper.Compute(Encoding.UTF8.GetBytes(rsp));
            CRCHelper.URL_CRC.Add($"{request.Url}_{SessionId}", hash);
            return GetBodyCRC(rsp, 0, "null", hash);
        }

        public static string GetChatServerList(HttpRequest request, ServerStruct serverStruct)
        {
            string SessionId = serverStruct.Headers.GetSessionId();
            ChatServer chatServerList = new()
            {
                _id = AIDHelper.CreateNewID(),
                RegistrationId = 20,
                DateTime = (int)TimeHelper.UnixTimeNow(),
                Regions = new() { "EUR" },
                VersionId = "bgkidft87ddd",
                Ip = "",
                Port = 0,
                Chats = new()
                {
                    new()
                    {
                        _id = "0",
                        Members = 0
                    }
                }

            }; 
            var rsp = JsonConvert.SerializeObject(chatServerList);
            var hash = CRCHelper.Compute(Encoding.UTF8.GetBytes(rsp));
            CRCHelper.URL_CRC.Add($"{request.Url}_{SessionId}", hash);
            return GetBodyCRC(rsp, 0, "null", hash);
        }

        public static string GetServerList(HttpRequest request, ServerStruct serverStruct)
        {
            string SessionId = serverStruct.Headers.GetSessionId();
            List<ServerDetails> servers = new()
            {
                new()
                {
                    ip = ConfigController.Configs.Server.Ip,
                    port = 7777
                }
            }; 
            var rsp = JsonConvert.SerializeObject(servers);
            var hash = CRCHelper.Compute(Encoding.UTF8.GetBytes(rsp));
            CRCHelper.URL_CRC.Add($"{request.Url}_{SessionId}", hash);
            return GetBodyCRC(rsp, 0, "null", hash);
        }

        public static string GetQuests(HttpRequest request, ServerStruct serverStruct)
        {
            string SessionId = serverStruct.Headers.GetSessionId();
            var rsp = QuestController.GetQuestAsString(QuestController.GetQuests());
            var hash = CRCHelper.Compute(Encoding.UTF8.GetBytes(rsp));
            CRCHelper.URL_CRC.Add($"{request.Url}_{SessionId}", hash);
            return GetBodyCRC(rsp, 0, "null", hash);
        }
    }
}
