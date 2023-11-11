using JsonLib.Classes.Response;
using ModdableWebServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities.Helpers;
using static ServerLib.Web.ResponseControl;

namespace ServerLib.Responders
{
    internal class ClientRespond
    {
        public static string GetVersion(ServerStruct serverStruct)
        {
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
            return GetBody(JsonConvert.SerializeObject(versionResponse));
        }

        public static string GetChatServerList()
        {
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
            return GetBody(JsonConvert.SerializeObject(chatServerList));
        }

        public static string GetServerList()
        {
            List<ServerDetails> servers = new()
            {
                /*
                new()
                {
                    Address = ConfigController.Configs.Server.Ip,
                    Port = $"{7000}"
                }
                */
            };
            return GetBody(JsonConvert.SerializeObject(servers));
        }

        public static string GetQuests()
        {
            return GetBody(Controllers.QuestController.GetQuestAsString(Controllers.QuestController.GetQuests()));
        }
    }
}
