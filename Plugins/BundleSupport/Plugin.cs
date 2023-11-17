using BundleSupport;
using ServerLib.Controllers;
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

        public string Name => "Bundle Supporter";

        public string Author => "SlejmUr";

        public string Version => "1.0";

        public string Description => "Add Bundle support";

        public List<string> Dependencies => new() { };  //No dependency

        public void Initialize()
        {
            BundleManager.LoadAllBundles("nothing");
            var assembly = this.GetType().Assembly;
            ServerManager.AddRoutes(assembly);
            CommandsController.Commands.Add("reloadbundle", BundleManager.LoadAllBundles);
            CommandsController.CommandsPermission.Add("reloadbundle", JsonLib.Enums.EPerms.Mod);
        }
        public void ShutDown()
        {
            var assembly = this.GetType().Assembly;
            ServerManager.RemoveRoutes(assembly);
        }
    }
}
