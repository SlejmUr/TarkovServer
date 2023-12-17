using JsonLib.Classes.Configurations;
using JsonLib.Classes.Request;
using ServerLib.Controllers;
using ServerLib.Utilities;
using System.Reflection;

namespace ServerLib.Handlers
{
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
    public class PluginLoader
    {
        private static Dictionary<string, IPlugin> pluginsList = new();
        public static void LoadPlugins()
        {
            Dictionary<IPlugin, List<string>> PluginDependencies = new();
            pluginsList.Clear();
            string currdir = Directory.GetCurrentDirectory();
            if (!Directory.Exists(Path.Combine(currdir, "Plugins"))) { Directory.CreateDirectory(Path.Combine(currdir, "Plugins")); }
            foreach (string file in Directory.GetFiles(Path.Combine(currdir, "Plugins"), "*.dll"))
            {
                IPlugin iPlugin = (IPlugin)Activator.CreateInstance(Assembly.LoadFile(file).GetType("Plugin.Plugin"));

                if (iPlugin == null)
                    continue;

                PluginDependencies.Add(iPlugin, iPlugin.Dependencies);
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
        }

        public static void UnloadPlugins()
        {
            foreach (var plugin in pluginsList)
            {
                plugin.Value.ShutDown();
                plugin.Value.Dispose();
                Debug.PrintInfo($"Plugin {plugin.Key} is now unloaded!");
            }
            pluginsList.Clear();
        }

        public static void ManualLoadPlugin(string DllName)
        {
            string currdir = Directory.GetCurrentDirectory();
            if (Activator.CreateInstance(Assembly.LoadFile(currdir + "/Plugins/" + DllName + ".dll").GetType("Plugin.Plugin")) is not IPlugin iPlugin)
            {
                Debug.PrintWarn("Plugin could not be loaded. Are you missing the IPlugin Export?");
                return;
            }
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
            pluginsList.Add(iPlugin.Name, iPlugin);
            iPlugin.Initialize();
            Debug.PrintInfo($"Plugin loaded: {iPlugin.Name}");
            Debug.PrintDebug("New Plugin Loaded" +
                "\nPlugin Name: " + iPlugin.Name +
                "\nPlugin Version: " + iPlugin.Version +
                "\nPlugin Author: " + iPlugin.Author +
                "\nPlugin Desc: " + iPlugin.Description
                , "PLUGIN");

        }
    }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
}
