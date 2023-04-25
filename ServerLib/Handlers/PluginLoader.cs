using NetCoreServer;
using ServerLib.Utilities;
using System.Reflection;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Handlers
{
    public class PluginLoader
    {
        private static Dictionary<string, PluginInfos> pluginsList = new Dictionary<string, PluginInfos>();
        public static void LoadPlugins()
        {
            string currdir = Directory.GetCurrentDirectory();

            if (!Directory.Exists(Path.Combine(currdir, "Plugins"))) { Directory.CreateDirectory(Path.Combine(currdir, "Plugins")); }

            foreach (string file in Directory.GetFiles(Path.Combine(currdir, "Plugins"), "*.dll"))
            {
                if (file.Contains("ignore")) { continue; }

                IPlugin iPlugin = (IPlugin)Activator.CreateInstance(Assembly.LoadFile(file).GetType("Plugin.Plugin"));
                if (pluginsList.ContainsKey(iPlugin.Name))
                {
                    Debug.PrintWarn("Plugin already loaded!");
                    //iPlugin.ShutDown();
                    //iPlugin.Dispose();
                }
                else
                {
                    PluginInit(iPlugin);
                    pluginsList.Add(iPlugin.Name, new PluginInfos
                    {
                        PluginPath = file,
                        Plugin = iPlugin
                    });



                }
            }
        }

        public static Dictionary<string, MethodInfo> UrlLoader(Assembly assembly)
        {
            Dictionary<string, MethodInfo> ret = new();
            var methods = assembly.GetTypes().SelectMany(x => x.GetMethods()).ToArray();
            var basemethods = methods.Where(x => x.GetCustomAttribute<HTTPAttribute>() != null && x.ReturnType == typeof(bool)).ToArray();
            methods = basemethods.Where(x => x.GetCustomAttribute<HTTPAttribute>().method.Contains("GET")).ToArray();
            foreach (var method in methods)
            {
                if (method == null)
                    continue;
                var url = method.GetCustomAttribute<HTTPAttribute>().url;
                Debug.PrintDebug(method.Name + $" ({url}) is added as an URL", "[HTTPServer/Plugin]");
                ret.Add(url, method);
            }
            methods = basemethods.Where(x => x.GetCustomAttribute<HTTPAttribute>().method.Contains("POST")).ToArray();
            foreach (var method in methods)
            {
                if (method == null)
                    continue;
                var url = method.GetCustomAttribute<HTTPAttribute>().url;
                Debug.PrintDebug(method.Name + $" ({url}) is added as an URL", "[HTTPServer/Plugin]");
                ret.Add(url, method);
            }
            return ret;
        }

        public static List<bool> PluginHttpRequest(HttpRequest request, HttpsBackendSession session)
        {
            List<bool> boolret = new();
            foreach (var plugin in pluginsList)
            {
                boolret.Add(plugin.Value.Plugin.HttpRequest(request, session));
            }
            return boolret;
        }

        public static void UnloadPlugins()
        {
            foreach (var plugin in pluginsList)
            {
                plugin.Value.Plugin.ShutDown();
                plugin.Value.Plugin.Dispose();
                Console.WriteLine($"Plugin {plugin.Key} is now unloaded!");
            }
        }
        public static void ManualLoadPlugin(string DllName)
        {

            string currdir = Directory.GetCurrentDirectory();
            IPlugin iPlugin = (IPlugin)Activator.CreateInstance(Assembly.LoadFile(currdir + "/Plugins/" + DllName + ".dll").GetType("Plugin.Plugin"));
            if (pluginsList.ContainsKey(iPlugin.Name))
            {
                Console.WriteLine("Plugin already loaded?");
                iPlugin.ShutDown();
                iPlugin.Dispose();
            }
            else
            {
                PluginInit(iPlugin);
                pluginsList.Add(iPlugin.Name, new PluginInfos
                {
                    PluginPath = currdir + "/Plugins/" + DllName + ".dll",
                    Plugin = iPlugin
                });
            }
        }
        private static void PluginInit(IPlugin iPlugin)
        {
            iPlugin.Initialize();
            Debug.PrintDebug("New Plugin Loaded" +
                "\nPlugin Name: " + iPlugin.Name +
                "\nPlugin Version: " + iPlugin.Version +
                "\nPlugin Author: " + iPlugin.Author +
                "\nPlugin Desc: " + iPlugin.Description
                , "[PLUGIN]");
        }

        internal class PluginInfos
        {
            public string PluginPath;
            public IPlugin Plugin;
        }
    }
}
