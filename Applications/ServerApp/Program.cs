using ServerLib.Utilities;
using System.Reflection;
using ReaLTaiizor.Forms;

namespace ServerApp
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ServerLib.Handlers.ArgumentHandler.MainArg(args);
            _ = ExtConsoleManagement.handle;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());

            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveEvent;
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
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
                ArgumentNullException.ThrowIfNull(assembly);
                Debug.PrintDebug(assembly, "AssemblyResolveEvent");
                if (assembly.Contains(".resources"))
                    assembly = assembly.Replace(".resources", "");
                _FileName = Path.Combine(File.ReadAllText("path.txt"), $"{assembly}.dll");
                if (Directory.GetFiles(Directory.GetCurrentDirectory()).Contains(assembly + " .dll"))
                {
                    return Assembly.LoadFrom(assembly + " .dll");
                }
                else if (File.Exists(_FileName))
                {
                    return Assembly.LoadFrom(_FileName);
                }
                throw new Exception("Assembly not found");
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