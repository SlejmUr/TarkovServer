using System.ComponentModel;

namespace ServerLib.Handlers
{
    public class ArgumentHandler
    {
        #region Handler
        public static string Ip { get; internal set; } = "172.0.0.1";
        public static int Port { get; internal set; } = 6969;
        public static bool Debug { get; internal set; } = false;
        public static bool AskHelp { get; internal set; } = false;
        public static bool DontLoadPlugin { get; internal set; } = false;
        public static string LoadMyPlugin { get; internal set; } = "";
        public static bool ReloadAllConfigs { get; internal set; } = false;
        public static void MainArg(string[] args)
        {
            Ip = GetParameter<string>(args, "-ip");
            Port = GetParameter<int>(args, "-port");
            Debug = HasParameter(args, "-debug");
            AskHelp = HasParameter(args, "-help");
            DontLoadPlugin = HasParameter(args, "-noplugin");
            LoadMyPlugin = GetParameter<string>(args, "-loadplugin");
            ReloadAllConfigs = HasParameter(args, "-reloadconfig");
        }
        public static void PrintHelp()
        {
            Console.WriteLine();
            Console.WriteLine("\tHelp");
            Console.WriteLine();
            Console.WriteLine("Command arguments to change server behavour:");
            Console.WriteLine();
            Console.WriteLine("-ip {168.192.1.50} \t\t Running the server under this IP. (Default: 172.0.0.1 AKA Localhost)");
            Console.WriteLine("-port {6969} \t\t\t Running the server under this Port. (Default: 6969)");
            Console.WriteLine("-loadplugin {pluginfile.dll} \t Running the server & load plugin before everything else. (Not default)");
            Console.WriteLine("-noplugin \t\t\t Disable loading all plugins, override -loadplugin!");
            Console.WriteLine("-reloadconfig \t\t\t Reload all config");
            Console.WriteLine("-debug \t\t\t\t Running the server with debug mode");
            Console.WriteLine("-help \t\t\t\t Showing this text.");
            Console.WriteLine();
            Console.ReadLine();
            Environment.Exit(1);
        }
        #endregion
        #region Functions
        static int IndexOfParam(string[] args, string param)
        {
            for (var x = 0; x < args.Length; ++x)
            {
                if (args[x].Equals(param, StringComparison.OrdinalIgnoreCase))
                    return x;
            }

            return -1;
        }

        static bool HasParameter(string[] args, string param)
        {
            return IndexOfParam(args, param) > -1;
        }

        static T GetParameter<T>(string[] args, string param, T defaultValue = default(T))
        {
            var index = IndexOfParam(args, param);

            if (index == -1 || index == (args.Length - 1))
                return defaultValue;

            var strParam = args[index + 1];

            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                return (T)converter.ConvertFromString(strParam);
            }

            return default(T);
        }
        #endregion
    }
}
