using ServerLib.Utilities;
using ServerLib.Web;
using System.Composition;

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

        public string Name => "LauncherSupporter";

        public string Author => "SlejmUr";

        public string Version => "0.1";

        public string Description => "Add Support for wierd launcher on all place.";

        public List<string> Dependencies => new() { };  //No dependency

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
