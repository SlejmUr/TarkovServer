using System;
using System.Composition;
using System.Runtime.CompilerServices;
using Tarkov_Server_Csharp;
using TestMod;


namespace Plugin
{
    [Export(typeof(IPlugin))]
    public class Plugin : IPlugin, IDisposable
    {



		public Plugin()
		{
            Console.WriteLine("Called plugin");
		}

        public void Dispose()
        {
        }

        public void Initialize()
        {
            Console.WriteLine("Initalized");
            TestMod.Class1 c = new();
            c.This();
        }
    }
}
