using ServerLib.Controllers;
using ServerLib.Utilities;
using System.Composition;
using System.Net;
using TestServer;

namespace Plugin
{
    [Export(typeof(IPlugin))]
    public class Plugin : IPlugin, IDisposable
    {
        public void Dispose()
        {
        }
        public Plugin()
        {

        }
        public TarkovGameServer gameServer;
        public string Name => "TestServer";

        public string Author => "SlejmUr";

        public string Version => "0.1";

        public string Description => "Test UDP Server";

        public List<string> Dependencies => new();

        public void Initialize()
        {
            gameServer = new(IPAddress.Parse(ConfigController.Configs.Server.Ip), 1000);
            gameServer.Start();
        }
        public void ShutDown()
        {
            gameServer.Stop();
        }
    }
}
