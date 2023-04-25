using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Json.Classes;
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

            var plugins = ConfigController.Configs.Plugins;
            if (plugins == null ) 
            {
                plugins = new();
            }

            if (!Directory.Exists(Path.Combine(currdir, "Plugins"))) { Directory.CreateDirectory(Path.Combine(currdir, "Plugins")); }

            Dictionary<IPlugin, List<string>> PluginDependencies = new();

            foreach (string file in Directory.GetFiles(Path.Combine(currdir, "Plugins"), "*.dll"))
            {
                Configs.Plugin plugin = new Configs.Plugin()
                { 
                    ignore = false
                };
                string prettyname = file.Replace(Path.Combine(currdir, "Plugins") + Path.DirectorySeparatorChar,"");;
                if (plugins.Where(x => x.file == prettyname).Any())
                {
                    var maybeplugin = plugins.Where(x=>x.file == prettyname).SingleOrDefault();
                    if (maybeplugin != null) 
                    {
                        plugin = maybeplugin;
                    }
                }
                else
                {
                    plugin.file = prettyname;
                }

                if (file.Contains("ignore"))
                {
                    plugin.ignore = true;
                }

                if (plugin.ignore)
                    continue;

                IPlugin iPlugin = (IPlugin)Activator.CreateInstance(Assembly.LoadFile(file).GetType("Plugin.Plugin"));

                plugin.dependencies = iPlugin.Dependencies;

                PluginDependencies.Add(iPlugin, plugin.dependencies);

                if (plugins.Where(x => x.file == plugin.file).Any())
                {
                    var maybeplugin = plugins.Where(x => x.file == prettyname).SingleOrDefault();
                    plugins.Remove(maybeplugin);
                }
                plugins.Add(plugin);
            }

            var ordered = PluginDependencies.OrderBy(x=>x.Value.Count);

            foreach (var item in ordered)
            {
                Console.WriteLine(item.Key.Name);
                Console.WriteLine(string.Join(", ", item.Value));

                foreach (var dependency in item.Value)
                {
                    if (!pluginsList.ContainsKey(dependency))
                    {
                        Debug.PrintError($"Plugin ({item.Key.Name}) cannot be loaded! (Dependency Error)");
                        return;
                    }
                }

                if (pluginsList.ContainsKey(item.Key.Name))
                {
                    Debug.PrintWarn("Plugin already loaded!");
                }
                else
                {
                    PluginInit(item.Key);
                    pluginsList.Add(item.Key.Name, new PluginInfos
                    {
                        Plugin = item.Key
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
            public IPlugin Plugin;
        }
    }
}
