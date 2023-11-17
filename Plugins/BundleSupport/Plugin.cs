﻿using BundleSupport;
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
            BundleManager.LoadAllBundles();
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
