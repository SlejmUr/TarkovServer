using NetCoreServer;
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

        public string Name { get; } = "TestPlugin";

        public string Author { get; } = "SlejmUr";

        public string Version { get; } = "0.1";

        public string Mode { get; } = "Server";

        public string Description { get; } = "Testing and showoff for future plugins";

        public void Initialize()
        {
            Class1.This();
            Console.WriteLine("Initalized");
            //Put here something if you want to start after it was called
            var assembly = this.GetType().Assembly;
            var methods = assembly.GetTypes().SelectMany(x => x.GetMethods()).ToArray();
            var basemethods = methods.Where(x => x.GetCustomAttribute<HTTPAttribute>() != null && x.ReturnType == typeof(bool)).ToArray();
            methods = basemethods.Where(x => x.GetCustomAttribute<HTTPAttribute>().method.Contains("GET")).ToArray();
            foreach (var method in methods)
            {
                if (method == null)
                    continue;
                var url = method.GetCustomAttribute<HTTPAttribute>().url;
                Debug.PrintDebug(method.Name + $" ({url}) is added as an URL", "debug", "[HTTPServer/Plugin]");
                HttpServerThingy.Add(url, method);
            }
            methods = basemethods.Where(x => x.GetCustomAttribute<HTTPAttribute>().method.Contains("POST")).ToArray();
            foreach (var method in methods)
            {
                if (method == null)
                    continue;
                var url = method.GetCustomAttribute<HTTPAttribute>().url;
                Debug.PrintDebug(method.Name + $" ({url}) is added as an URL", "debug", "[HTTPServer/Plugin]");
                HttpServerThingy.Add(url, method);
            }
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
