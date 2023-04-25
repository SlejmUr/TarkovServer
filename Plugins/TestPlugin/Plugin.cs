using NetCoreServer;
using ServerLib.Handlers;
using ServerLib.Utilities;
using System.Composition;
using System.Reflection;
using TestPlugin;
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
        public Plugin() //This will be called First!
        {
            Console.WriteLine("Welcome from " + Name + " !");
        }

        public string Name => "TestPlugin";

        public string Author => "SlejmUr";

        public string Version => "0.1";

        public string Description => "Testing and showoff for future plugins";

        public List<string> Dependencies => new();

        public void Initialize()
        {
            Class1.This();
            Console.WriteLine("Initalized");
            //Put here something if you want to start after it was called
            var assembly = this.GetType().Assembly;
            HttpServerThingy = PluginLoader.UrlLoader(assembly);
        }
        public void ShutDown()
        {
            Console.WriteLine("shutdown!");
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
