using JsonLib.Classes.LocationRelated;
using ServerLib.Controllers;
using ServerLib.Generators;
using TestServer.Jsons;

namespace TestServer
{
    public class ServerController
    {
        public struct Server
        {
            public string GUID;
            public string IP;
            public int Port;
            public string Location;
            public string Version;
            public List<string> Players;
            public bool IsDebugServer;
            public bool IsLootInitialized;
            public List<string> AssetsList;
            public Dictionary<string, uint> NetIds;
        }
        public static List<Server> Servers = new();
        public static List<string> ServersGUID = new();

        public static void Register(RegisterServer registerServer)
        {
            if (ServersGUID.Contains(registerServer.GUID))
            {
                Console.WriteLine("ERROR! Server GUID Already registered!");
                return;
            }
            Server server = new()
            {
                GUID = registerServer.GUID,
                IP = registerServer.IP,
                Port = registerServer.Port,
                Location = registerServer.Location,
                Version = registerServer.Version,
                Players = new(),
                IsDebugServer = false,
                IsLootInitialized = false,
                AssetsList = new(),
                NetIds = new()
            };
            Servers.Add(server);
            ServersGUID.Add(registerServer.GUID);
        }

        public static void Delete(UnregisterServer unregisterServer)
        {
            if (!ServersGUID.Contains(unregisterServer.GUID))
            {
                Console.WriteLine("ERROR! Server GUID IS NOT exist in registered servers!");
                return;
            }
            Servers.RemoveAll(x => x.GUID == unregisterServer.GUID);
            ServersGUID.Remove(unregisterServer.GUID);
        }


        public static List<LootBase> GenerateLoot(string GUID)
        {
            var server = Servers.Where(x => x.GUID == GUID).First();
            var loots = Loot.GenerateLoot(server.Location);

            foreach (var loot in loots)
            {
                foreach (var item in loot.Items)
                {
                    var item_template = ItemController.Get(item.Tpl);
                    var path = item_template._props.Prefab.path;
                    if (string.IsNullOrEmpty(path))
                        continue;

                    server.AssetsList.Add(path);
                }
            }
            return loots;
        }

        public static List<string> GetAssetList(string GUID)
        {
            var server = Servers.Where(x => x.GUID == GUID).First();
            return server.AssetsList;
        }

        public static void GenerateWorld()
        {
            // Get all location exits.
            // get all interactibles, and the doors, make it all open for test
            // get all lamps, adjust to be all ON
            // no airdrop, breakablewindows
            // no btr

        }

        public static void GetPlayerData(string GUID, string PlayerSessionId)
        {

        }

        public static void PlayerJoined(string GUID, string PlayerSessionId)
        {

        }

        public static void PlayerLeft(string GUID, string PlayerSessionId)
        {

        }

        // Map stuff
        public static bool RequestLoadMap(string map)
        {
            if (File.Exists($"TestServer/{map}.json"))  //Interactibles
            {
                return true;
            }
            return false;
        }

        public static string GetMap(string map)
        {
            return File.ReadAllText($"TestServer/{map}.json");
        }

    }
}
