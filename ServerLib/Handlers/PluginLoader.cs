using System.Reflection;
using ServerLib.Utilities;

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
				IPlugin iPlugin = (IPlugin)Activator.CreateInstance(Assembly.LoadFile(file).GetType("Plugin.Plugin"));
				if (pluginsList.ContainsKey(iPlugin.Name))
				{
					Console.WriteLine("Plugin already loaded?");
					iPlugin.ShutDown();
					iPlugin.Dispose();
				}
				else
				{
					EmulatorInit(iPlugin);
					pluginsList.Add(iPlugin.Name, new PluginInfos
					{
						PluginPath = file,
						Plugin = iPlugin
					});
				}
			}
		}
		public static void PluginWebOverride(WebServer webServer)
		{
			foreach (var plugin in pluginsList)
			{
				plugin.Value.Plugin.WebOverride(webServer);
			}

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
				EmulatorInit(iPlugin);
				pluginsList.Add(iPlugin.Name, new PluginInfos
				{
					PluginPath = currdir + "/Plugins/" + DllName + ".dll",
					Plugin = iPlugin
				});
			}
		}
		private static void EmulatorInit(IPlugin iPlugin)
		{
			iPlugin.Initialize();
			Utils.PrintDebug("New Plugin Loaded" +
				"\nPlugin Name: " + iPlugin.Name +
				"\nPlugin Version: " + iPlugin.Version +
				"\nPlugin Author: " + iPlugin.Author +
				"\nPlugin Mode: " + iPlugin.Mode +
				"\nPlugin Desc: " + iPlugin.Description
				);
		}
		internal class PluginInfos
		{
			public string PluginPath;
			public IPlugin Plugin;
		}
	}
}
