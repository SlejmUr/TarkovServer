﻿using ServerLib.Controllers;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using System.Reflection;
using System.Text;
using SL = ServerLib;
using SLH = ServerLib.Handlers;

namespace ConsoleApp
{
    internal class Program
    {
        static readonly CVersion Version = new();
        static void LogDetailed(string text)
        {
            Debug.PrintInfo(text);
        }
        static void ConsoleSpacer()
        {
            Console.WriteLine();
        }

        static void ServerInfo()
        {
            LogDetailed("Welcome in Tarkov Server Console!");
            ConsoleSpacer();
            LogDetailed($"Server Version: {Versions.ServerVersion} | Console Version: {Version.LoadVersion} | Tarkov Version: {Versions.TarkovVersion}");
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
            Console.Title = $"TarkovServer - [{Version.LoadVersion}]";
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



            SL.Main.Init();
            LogDetailed("Initialization Done!");
            /*
            var keys = ProfileController.ProfilesDict.Keys;
            foreach (var item in keys)
            {
                Console.WriteLine(JWTHandler.CreateGameToken(item));
            }
            */

            Console.WriteLine("Commands are starting with !. Like !help");
            Console.WriteLine("Type 'exit' or 'q' to end application");
            string endCheck = "not";
            while (endCheck.ToLower() != "exit")
            {
                endCheck = Console.ReadLine()!;
                if (endCheck.StartsWith("!"))
                {
                    CommandsController.Run(endCheck);
                }
                if (endCheck.ToLower() == "q")
                    break;
            }

            SL.Main.Stop();

            if (SLH.ArgumentHandler.Debug)
                Console.ReadLine();
        }

        private static void CurrentDomain_AssemblyLoad(object? sender, AssemblyLoadEventArgs args)
        {
            Debug.PrintDebug(args.LoadedAssembly.GetName().FullName, "AssemblyLoad");
        }

        internal static Assembly AssemblyResolveEvent(object? sender, ResolveEventArgs args)
        {
            var _FileName = "";
            try
            {
                var assembly = new AssemblyName(args.Name).Name;
                Debug.PrintDebug(assembly, "AssemblyResolveEvent");
                if (assembly == null)
                    Debug.PrintDebug("Assembly is null!");
                if (assembly.Contains(".resources"))
                    assembly = assembly.Replace(".resources", "");
                _FileName = Path.Combine(File.ReadAllText("path.txt"), $"{assembly}.dll");
                if (Directory.GetFiles(Directory.GetCurrentDirectory()).Contains(assembly+ " .dll"))
                {
                    return Assembly.LoadFrom(assembly + " .dll");
                }
                else if (File.Exists(_FileName))
                {
                    return Assembly.LoadFrom(_FileName);
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(
                   $"Cannot find a file(or file is not unlocked) named:\r\n{_FileName}\r\nWith an exception: {e.Message}\r\nApplication will close!");
                Console.ReadLine();
                throw;
            }
        }

    }
}