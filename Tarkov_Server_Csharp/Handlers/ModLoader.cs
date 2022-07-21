using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Tarkov_Server_Csharp.Handlers
{
    internal class ModLoader
    {
        public static void LoadMod()
        {
			string currdir = Directory.GetCurrentDirectory();
            IPlugin iPlugin = (IPlugin)Activator.CreateInstance(Assembly.LoadFile(currdir + "/TestMod.dll").GetType("Plugin.Plugin"));
			BuildEmulatorTab(iPlugin);
		}
		private static void BuildEmulatorTab(IPlugin iPlugin)
		{
			iPlugin.Initialize();
		}
	}
}
