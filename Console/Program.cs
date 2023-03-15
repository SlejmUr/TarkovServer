using System.Reflection;
using System.Text;
using Newtonsoft.Json;

using SL = ServerLib;
using SLH = ServerLib.Handlers;
using SLU = ServerLib.Utilities;
using SLC = ServerLib.Controllers;
using SLW = ServerLib.Web;

namespace Tarkov_Server_Console
{
    internal class Program
    {
        static CVersion Version = new CVersion();
        static void LogDetailed(string text) 
        {
            Console.WriteLine(text);
        }
        static void ConsoleSpacer()
        {
            Console.WriteLine();
        }

        static void ServerInfo() 
        {
            LogDetailed("Welcome in Tarkov Server Console!");
            ConsoleSpacer();
            LogDetailed($"Versions: \n{SLU.Versions.ServerVersion}\n{Version.LoadVersion}");
            ConsoleSpacer();
        }

        static void Main(string[] args)
        {
            if (!File.Exists("path.txt"))
            {
                File.WriteAllText("path.txt", "_References");
            }

            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveEvent;

            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = $"MTGA - SharpServer [{Version.LoadVersion}]";
            ServerInfo();

            SLH.ArgumentHandler.MainArg(args);

            if (SLH.ArgumentHandler.AskHelp)
            {
                SLH.ArgumentHandler.PrintHelp();
            }

            if (!string.IsNullOrWhiteSpace(SLH.ArgumentHandler.LoadMyPlugin))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                LogDetailed("Warning! You loading a plugin before everything else is loaded!");
                Console.ResetColor();

                Console.WriteLine(SLH.ArgumentHandler.LoadMyPlugin);
                SLH.PluginLoader.ManualLoadPlugin(SLH.ArgumentHandler.LoadMyPlugin);
            }

            var server = new SL.ServerLib();
            server.Init();
            LogDetailed("Initialization Done!");

            Console.WriteLine("Type 'exit' to end application");
            string endCheck = "not";
            while (endCheck.ToLower() != "exit")
            {
                endCheck = Console.ReadLine();
            }

            server.Stop();
        }

        internal static Assembly AssemblyResolveEvent(object sender, ResolveEventArgs args)
        {
            var _FileName = "";
            try
            {
                var assembly = new AssemblyName(args.Name).Name;
                _FileName = Path.Combine(File.ReadAllText("path.txt"), $"{assembly}.dll");
                // resources are embedded inside assembly
                if (_FileName.Contains("resources"))
                {
                    return null;
                }
                return Assembly.LoadFrom(_FileName);
            }
            catch (Exception e)
            {
                 Console.WriteLine(
                    $"Cannot find a file(or file is not unlocked) named:\r\n{_FileName}\r\nWith an exception: {e.Message}\r\nApplication will close after pressing OK.",
                    "File load error!");
                Console.ReadLine();
            }
            return null;
        }

    }
}