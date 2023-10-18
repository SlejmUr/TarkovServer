using ServerLib.Utilities;
using ServerLib.Web;
using System.Composition;
using TestPlugin;

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
            ServerManager.OverrideRoutes(assembly);
        }
        public void ShutDown()
        {
            Console.WriteLine("shutdown!");
            var assembly = this.GetType().Assembly;
            ServerManager.RemoveRoutes(assembly);
        }
    }
}
