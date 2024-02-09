using ServerLib.Controllers;
using ServerLib.Utilities;
using ServerLib.Web;
using System.Composition;
using System.Net;

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
        public string Name => "TestServer";

        public string Author => "SlejmUr";

        public string Version => "0.3";

        public string Description => "MiddleWare plugin for U19/U21 Tarkov Server";

        public List<string> Dependencies => new();
        public void Initialize()
        {
            var assembly = this.GetType().Assembly;
            ServerManager.AddRoutes(assembly);
        }
        public void ShutDown()
        {
            var assembly = this.GetType().Assembly;
            ServerManager.RemoveRoutes(assembly);
        }
    }
}
