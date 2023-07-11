using System.Reflection;
using System.Text;

using SL = ServerLib;
using SLH = ServerLib.Handlers;
using SLU = ServerLib.Utilities;
using ServerLib.Controllers;
using ServerLib.Utilities;

namespace ConsoleApp
{
    internal class Program
    {
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
            LogDetailed("Welcome to the EXFIL Dedicated Server Console!");
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
            Console.Title = $"TarkovServer - AlphaGame";
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
            Console.WriteLine("Commands start with !. For example: !help");
            Console.WriteLine("Type 'exit' or 'q' to quit the console and shutdown the server.");
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
                    $"Cannot find a file (or the server doesn't have permission to use the file) named:\r\n{_FileName}\r\nWith the exception: {e.Message}\r\nThe app will close after pressing OK.",
                    "File load error!");
                Console.ReadLine();
            }
            return null;
        }

    }
}