using System.Reflection;
using System.Text;
using Newtonsoft.Json;

using SL = ServerLib;
using SLH = ServerLib.Handlers;
using SLU = ServerLib.Utilities;
using SLC = ServerLib.Controllers;
using SLW = ServerLib.Web;
using ServerLib.Controllers;
using ServerLib.Utilities;

namespace ConsoleApp
{
    internal class Program
    {
        static CVersion Version = new CVersion();
        static void LogDetailed(string text) 
        {
            SLU.Debug.PrintInfo(text);
        }
        static void ConsoleSpacer()
        {
            Console.WriteLine();
        }

        static void ServerInfo() 
        {
            LogDetailed("Welcome to the EXFIL dedicated server console!");
            ConsoleSpacer();
            LogDetailed($"Versions: \n{SLU.Versions.ServerVersion}\n{Version.LoadVersion}");
            ConsoleSpacer();
        }

        static void Main(string[] args)
        {
            Console.Clear();
            if (!File.Exists("path.txt"))
            {
                File.WriteAllText("path.txt", "_References");
            }

            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveEvent;
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;

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
                LogDetailed("Warning! You're trying to load a plugin before everything else is loaded! Please wait!");
                Console.ResetColor();

                Console.WriteLine(SLH.ArgumentHandler.LoadMyPlugin);
                SLH.PluginLoader.ManualLoadPlugin(SLH.ArgumentHandler.LoadMyPlugin);
            }

            SL.ServerLib.Init();
            LogDetailed("Initialization Done!");
            Console.WriteLine("Commands start with !, an example of this would be: !help");
            Console.WriteLine("Type 'exit' or 'q' to exit the ConsoleApp and close the server.");
            string endCheck = "not";
            while (endCheck.ToLower() != "exit")
            {
                endCheck = Console.ReadLine();
                if (endCheck.StartsWith("!"))
                {
                    CommandsController.Run(endCheck);
                }
                if (endCheck.ToLower() == "q")
                    break;
            }

            SL.ServerLib.Stop();

            if (SLH.ArgumentHandler.Debug)
                Console.ReadLine();
        }

        private static void CurrentDomain_AssemblyLoad(object? sender, AssemblyLoadEventArgs args)
        {
            Debug.PrintDebug(args.LoadedAssembly.FullName, "AssemblyLoad");
        }

        internal static Assembly AssemblyResolveEvent(object sender, ResolveEventArgs args)
        {
            var _FileName = "";
            try
            {
                var assembly = new AssemblyName(args.Name).Name;
                Debug.PrintDebug(assembly, "AssemblyResolveEvent");
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
                    $"Cannot find the file (or ConsoleApp doesn't have permission to use the file) named:\r\n{_FileName}\r\nWith the exception: {e.Message}\r\nThe application will close after pressing OK.",
                    "File load error!");
                Console.ReadLine();
            }
            return null;
        }

    }
}