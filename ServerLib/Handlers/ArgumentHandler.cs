using System.ComponentModel;

namespace ServerLib.Handlers
{
    public class ArgumentHandler
    {
        public static string Ip { get; internal set; } = "172.0.0.1";
        public static int Port { get; internal set; } = 7777;
        public static bool Debug { get; internal set; } = false;
        public static bool AskHelp { get; internal set; } = false;
        public static bool DontLoadPlugin { get; internal set; } = false;
        public static string LoadMyPlugin { get; internal set; } = "";
        public static void MainArg(string[] args)
        {
            Ip = GetParameter<string>(args, "-ip");
            Port = GetParameter<int>(args, "-port");
            Debug = HasParameter(args, "-debug");
            AskHelp = HasParameter(args, "-help");
            DontLoadPlugin = HasParameter(args, "-noplugin");
            LoadMyPlugin = GetParameter<string>(args, "-loadplugin");
        }
        public static void PrintHelp()
        {
            Console.WriteLine();
            Console.WriteLine("\tHelp");
            Console.WriteLine();
            Console.ReadLine();
            Environment.Exit(1);
        }
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

        static List<T> GetParameterList<T>(string[] args, string param)
        {
            var list = new List<T>();
            var index = IndexOfParam(args, param);

            if (index == -1 || index == (args.Length - 1))
                return list;

            index++;

            while (index < args.Length)
            {
                var strParam = args[index];

                if (strParam[0] == '-') break;

                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    list.Add((T)converter.ConvertFromString(strParam));
                }

                index++;
            }

            return list;
        }

    }
}
