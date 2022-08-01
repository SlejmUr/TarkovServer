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
            Console.WriteLine("Initalized");
            //Put here something if you want to start after it was called
        }
        public void ShutDown()
        {
            var called = Assembly.GetCallingAssembly();
            if (_webserver != null)
            {
                var staticRoutes = this.GetType().Assembly //Get This Assembly
                    .GetTypes() // Get all classes from assembly
                    .SelectMany(x => x.GetMethods()) // Get all methods from assembly
                    .Where(Utils.IsStaticRoute);
                foreach (var staticRoute in staticRoutes)
                {
                    var attribute = staticRoute.GetCustomAttributes().OfType<StaticRouteAttribute>().First();
                    if (_webserver._Server.Routes.Static.Exists(attribute.Method, attribute.Path))
                    {
                        Console.WriteLine(attribute.Method + " " + attribute.Path + " is Existed, Remove!");
                        _webserver._Server.Routes.Static.Remove(attribute.Method, attribute.Path);
                    }

                }
                Console.WriteLine("WebOverride is deleted! (Probably some leftover)");
                FixWeb(called);
                Console.WriteLine("Leftovers fixed!");
            }
        }

        public void WebOverride(WebServer webServer)
        {
            _webserver = webServer;
            var staticRoutes = this.GetType().Assembly //Get This Assembly
                .GetTypes() // Get all classes from assembly
                .SelectMany(x => x.GetMethods()) // Get all methods from assembly
                .Where(Utils.IsStaticRoute);

            var staticRoutes_called = Assembly.GetCallingAssembly() //Get called assembly (ServerLib)
                .GetTypes() // Get all classes from assembly
                .SelectMany(x => x.GetMethods()) // Get all methods from assembly
                .Where(Utils.IsStaticRoute);

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
                        called_route.Handler = Utils.ToRouteMethod(staticRoute);
                        //called_route.Method = attribute.Method;
                        //called_route.Path = attribute.Path;
                    }
                }
                if (!webServer._Server.Routes.Static.Exists(attribute.Method, attribute.Path))
                {
                    Console.WriteLine(attribute.Method + " " + attribute.Path + " is not Existed, created!");
                    webServer._Server.Routes.Static.Add(attribute.Method, attribute.Path, Utils.ToRouteMethod(staticRoute));
                }

            }
            Console.WriteLine("WebOverride Done!");
        }
        private WebServer _webserver;

        private void FixWeb(Assembly called)
        {
            if (_webserver != null)
            {
                var staticRoutes_called = called //Get called assembly (ServerLib)
                   .GetTypes() // Get all classes from assembly
                   .SelectMany(x => x.GetMethods()) // Get all methods from assembly
                   .Where(Utils.IsStaticRoute);
                foreach (var staticRoute_called in staticRoutes_called)
                {
                    var attribute_called = staticRoute_called.GetCustomAttributes().OfType<StaticRouteAttribute>().First();

                    if (!_webserver._Server.Routes.Static.Exists(attribute_called.Method, attribute_called.Path))
                    {
                        Console.WriteLine(attribute_called.Method + " " + attribute_called.Path + " is not Existed, created (Fixed)!");
                        _webserver._Server.Routes.Static.Add(attribute_called.Method, attribute_called.Path, Utils.ToRouteMethod(staticRoute_called));
                    }
                }
            }
        }


    }
}
