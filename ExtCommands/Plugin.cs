﻿using ExtCommands;
using NetCoreServer;
using ServerLib.Handlers;
using ServerLib.Utilities;
using System.Composition;
using System.Reflection;
using static ServerLib.Web.HTTPServer;

namespace Plugin
{
    [Export(typeof(IPlugin))]
    public class Plugin : IPlugin, IDisposable
    {
        public static Dictionary<string, MethodInfo> HttpServerThingy = new();
        public void Dispose()
        {
        }
        public Plugin()
        {
            JWTHandler.CreateRSA();
        }

        public string Name { get; } = "ExtCommands";

        public string Author { get; } = "SlejmUr";

        public string Version { get; } = "0.1";

        public string Mode { get; } = "Server";

        public string Description { get; } = "Add external commands support";

        public void Initialize()
        {
            var assembly = this.GetType().Assembly;
            HttpServerThingy = PluginLoader.UrlLoader(assembly);
        }
        public void ShutDown()
        {
            HttpServerThingy.Clear();
        }

        public bool HttpRequest(HttpRequest request, HttpsBackendSession session)
        {
            string url = request.Url;
            url = Uri.UnescapeDataString(url);
            if (HttpServerThingy.TryGetValue(url, out var method))
            {
                var ret = method.Invoke(this, new object[] { request, session });
                return (bool)ret;
            }
            return false;
        }
    }
}
