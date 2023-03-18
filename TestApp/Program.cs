using System;
using System.Reflection;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveEvent;
            Console.WriteLine("Hello World!");
            Console.WriteLine("yeet!");

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