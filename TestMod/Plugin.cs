using ServerLib;
using ServerLib.Utilities;
using System.Composition;
using TestPlugin;
using HttpServerLite;
using System.Reflection;

namespace Plugin
{
    [Export(typeof(IPlugin))]
    public class Plugin : IPlugin, IDisposable
    {
		public Plugin()
		{
            Console.WriteLine("This will be called First!");
		}

        public string Name { get; } = "TestMod";

        public string Author { get; } = "SlejmUr";

        public string Version { get; } = "0.1";

        public string Mode { get; } = "Server";

        public void Initialize()
        {
            Console.WriteLine("Initalized");
            Class1 c = new();
            c.This();
        }
        public void Dispose()
        {
            if (_webserver != null)
            {
                PlusFromWeb plusFromWeb = new();
                var staticRoutes = this.GetType().Assembly //Get This Assembly
                    .GetTypes() // Get all classes from assembly
                    .SelectMany(x => x.GetMethods()) // Get all methods from assembly
                    .Where(PlusFromWeb.IsStaticRoute);
                foreach (var staticRoute in staticRoutes)
                {
                    var attribute = staticRoute.GetCustomAttributes().OfType<StaticRouteAttribute>().First();
                    if (_webserver._Server.Routes.Parameter.Exists(attribute.Method, attribute.Path))
                    {
                        Console.WriteLine(attribute.Method + " " + attribute.Path + " is not Existed, created!");
                        _webserver._Server.Routes.Static.Remove(attribute.Method, attribute.Path);
                    }

                }
                Console.WriteLine("WebOverride is deleted! (Probably some leftover)");
                FixWeb();
            }
        }

        public void WebOverride(WebServer webServer)
        {
            _webserver = webServer;
            var staticRoutes = this.GetType().Assembly //Get This Assembly
                .GetTypes() // Get all classes from assembly
                .SelectMany(x => x.GetMethods()) // Get all methods from assembly
                .Where(PlusFromWeb.IsStaticRoute);

            var staticRoutes_called = Assembly.GetCallingAssembly() //Get called assembly (ServerLib)
                .GetTypes() // Get all classes from assembly
                .SelectMany(x => x.GetMethods()) // Get all methods from assembly
                .Where(PlusFromWeb.IsStaticRoute);

            foreach (var staticRoute in staticRoutes)
            {
                var attribute = staticRoute.GetCustomAttributes().OfType<StaticRouteAttribute>().First();
                foreach (var staticRoute_called in staticRoutes_called)
                {
                    var attribute_called = staticRoute_called.GetCustomAttributes().OfType<StaticRouteAttribute>().First();
                    if (attribute.Method == attribute_called.Method && attribute.Path == attribute_called.Path)
                    {
                        Console.WriteLine(attribute.Method + " " + attribute.Path + " == " + attribute_called.Method + " " + attribute_called.Path);
                        var called_route = webServer._Server.Routes.Static.Get(attribute_called.Method, attribute_called.Path);
                        called_route.Handler = PlusFromWeb.ToRouteMethod(staticRoute);
                        //called_route.Method = attribute.Method;
                        //called_route.Path = attribute.Path;
                    }
                }
                if (!webServer._Server.Routes.Parameter.Exists(attribute.Method, attribute.Path))
                {
                    Console.WriteLine(attribute.Method + " " + attribute.Path + " is not Existed, created!");
                    webServer._Server.Routes.Static.Add(attribute.Method, attribute.Path, PlusFromWeb.ToRouteMethod(staticRoute));
                }

            }
            Console.WriteLine("WebOverride Done!");
        }
        private WebServer _webserver;

        private void FixWeb()
        {
            if (_webserver != null)
            {
                var staticRoutes_called = Assembly.GetCallingAssembly() //Get called assembly (ServerLib)
                   .GetTypes() // Get all classes from assembly
                   .SelectMany(x => x.GetMethods()) // Get all methods from assembly
                   .Where(PlusFromWeb.IsStaticRoute);
                foreach (var staticRoute_called in staticRoutes_called)
                {
                    var attribute_called = staticRoute_called.GetCustomAttributes().OfType<StaticRouteAttribute>().First();
                    if (!_webserver._Server.Routes.Parameter.Exists(attribute_called.Method, attribute_called.Path))
                    {
                        Console.WriteLine(attribute_called.Method + " " + attribute_called.Path + " is not Existed, created (Fixed)!");
                        _webserver._Server.Routes.Static.Add(attribute_called.Method, attribute_called.Path, PlusFromWeb.ToRouteMethod(staticRoute_called));
                    }
                }
            }
        }
    }
}
