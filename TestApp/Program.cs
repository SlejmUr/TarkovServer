using ChatShared;
using EFT;
using EFT.Communications;
using EFT.Game.Spawning;
using EFT.Hideout;
using EFT.InputSystem;
using EFT.Interactive;
using EFT.InventoryLogic;
using EFT.Quests;
using EFT.Settings.Graphics;
using EFT.UI.Ragfair;
using EFT.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Reflection;
using UnityEngine;
using EFT.Ballistics;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveEvent;
            Console.WriteLine("Hello World!");
            Console.WriteLine("yeet!");
            var char_ = "";//ItemBase.FromJson(File.ReadAllText("items.json"));


            if (char_ == null)
            {
                Console.WriteLine("sad");
            }
            else
            {
                File.WriteAllText("items_reparesed.json", (char_.ToPrettyJson()));

            }

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
                Console.WriteLine(_FileName);
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