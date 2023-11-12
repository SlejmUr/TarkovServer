using JsonLib.Classes.Configurations;
using ServerLib.Controllers;
using ServerLib.Utilities;
using System.Reflection;

namespace ServerLib.Handlers
{
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
    public class PluginLoader
    {
        private static Dictionary<string, PluginInfos> pluginsList = new();
        public static void LoadPlugins()
        {
            string currdir = Directory.GetCurrentDirectory();

            var plugins = ConfigController.Configs.Plugins;
            plugins ??= new();

            if (!Directory.Exists(Path.Combine(currdir, "Plugins"))) { Directory.CreateDirectory(Path.Combine(currdir, "Plugins")); }

            Dictionary<IPlugin, List<string>> PluginDependencies = new();

            foreach (string file in Directory.GetFiles(Path.Combine(currdir, "Plugins"), "*.dll"))
            {
                BaseConfig.Plugin plugin = new()
                {
                    ignore = false
                };
                string prettyname = file.Replace(Path.Combine(currdir, "Plugins") + Path.DirectorySeparatorChar, ""); ;
                if (plugins.Where(x => x.file == prettyname).Any())
                {
                    var maybeplugin = plugins.Where(x => x.file == prettyname).SingleOrDefault();
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

                if (iPlugin == null)
                    continue;
                plugin.dependencies = iPlugin.Dependencies;

                PluginDependencies.Add(iPlugin, plugin.dependencies);

                if (plugins.Where(x => x.file == plugin.file).Any())
                {
                    var maybeplugin = plugins.Where(x => x.file == prettyname).SingleOrDefault();
                    plugins.Remove(maybeplugin);
                }
                plugins.Add(plugin);
            }

            var ordered = PluginDependencies.OrderBy(x => x.Value.Count);

            foreach (var item in ordered)
            {
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
                }
            }

            ConfigController.Save();

        }

        public static void UnloadPlugins()
        {
            foreach (var plugin in pluginsList)
            {
                plugin.Value.Plugin.ShutDown();
                plugin.Value.Plugin.Dispose();
                Debug.PrintInfo($"Plugin {plugin.Key} is now unloaded!");
            }
            pluginsList.Clear();
        }

        public static void ManualLoadPlugin(string DllName)
        {
            string currdir = Directory.GetCurrentDirectory();
            if (Activator.CreateInstance(Assembly.LoadFile(currdir + "/Plugins/" + DllName + ".dll").GetType("Plugin.Plugin")) is not IPlugin iPlugin)
                return;
            if (pluginsList.ContainsKey(iPlugin.Name))
            {
                Debug.PrintWarn("Plugin already loaded?");
                //iPlugin.ShutDown();
                //iPlugin.Dispose();
            }
            else
            {
                PluginInit(iPlugin);
            }
        }
        private static void PluginInit(IPlugin iPlugin)
        {
            pluginsList.Add(iPlugin.Name, new PluginInfos
                {
                    Plugin = iPlugin
                });
            iPlugin.Initialize();
            Debug.PrintInfo($"Plugin loaded: {iPlugin.Name}");
            Debug.PrintDebug("New Plugin Loaded" +
                "\nPlugin Name: " + iPlugin.Name +
                "\nPlugin Version: " + iPlugin.Version +
                "\nPlugin Author: " + iPlugin.Author +
                "\nPlugin Desc: " + iPlugin.Description
                , "PLUGIN");

        }

        internal class PluginInfos
        {
            public IPlugin Plugin;
        }
    }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
}
