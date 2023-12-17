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

        public string Name => "MTGA Plugin";

        public string Author => "SlejmUr";

        public string Version => "0.1";

        public string Description => "Add Support for MTGA Binaries.";

        // We need this dependencies because otherwise players couldnt login and support bundle.
        public List<string> Dependencies => new() { "Bundle Supporter", "LauncherSupporter" };

        public void Initialize()
        {
            var assembly = this.GetType().Assembly;
            ServerManager.AddRoutes(assembly);
            Console.WriteLine("Welcome in MTGA Plugin! Have a great time! (testing ofc)");
        }
        public void ShutDown()
        {
            var assembly = this.GetType().Assembly;
            ServerManager.RemoveRoutes(assembly);
        }
    }
}
