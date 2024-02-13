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
            Servers.RemoveAll(x=>x.GUID == unregisterServer.GUID);
            ServersGUID.Remove(unregisterServer.GUID);
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
