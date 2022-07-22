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
					iPlugin.Dispose();
				}
				else
				{
					BuildEmulatorTab(iPlugin);
					pluginsList.Add(iPlugin.Name, new PluginInfos
					{
						PluginPath = file,
						Plugin = iPlugin
					});
				}
			}
		}
		public static void DoWebLoad(WebServer webServer)
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
				plugin.Value.Plugin.Dispose();
				Console.WriteLine($"Plugin {plugin.Key} is now unloaded!");
			}
		}
		private static void BuildEmulatorTab(IPlugin iPlugin)
		{
			iPlugin.Initialize();
		}
		internal class PluginInfos
		{
			public string PluginPath;
			public IPlugin Plugin;
		}
	}
}
