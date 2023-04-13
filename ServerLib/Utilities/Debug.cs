using ServerLib.Handlers;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Utilities
{
    public class Debug
    {
        #region Debug Print
        public static void PrintInfo(string ToPrint, string prefix = "[INFO]")
        {
            Console.ForegroundColor = GetColorByType("info");
            PW(prefix + " " + ToPrint);
            Console.ResetColor();
        }

        public static void PrintDebug(string ToPrint, string prefix = "[DEBUG]")
        {
            if (ArgumentHandler.Debug)
            {
                Console.ForegroundColor = GetColorByType("debug");
                PW(prefix + " " + ToPrint);
                Console.ResetColor();
            }
            else
            {
                PWOnly(prefix + " " + ToPrint);
            }
        }

        public static void PrintWarn(string ToPrint, string prefix = "[WARN]")
        {
            Console.ForegroundColor = GetColorByType("warning");
            PW(prefix + " " + ToPrint);
            Console.ResetColor();
        }

        public static void PrintError(string ToPrint, string prefix = "[ERROR]")
        {
            Console.ForegroundColor = GetColorByType("error");
            PW(prefix + " " + ToPrint);
            Console.ResetColor();
        }
        static ConsoleColor GetColorByType(string type)
        {
            switch (type)
            {
                case "warning":
                    return ConsoleColor.Yellow;
                case "error":
                    return ConsoleColor.DarkRed;
                case "debug":
                    return ConsoleColor.Green;
                case "info":
                    return ConsoleColor.Blue;
                default:
                    return ConsoleColor.White;
            }
        }

        //
        static void PW(string print)
        {
            Console.WriteLine(print);
            if (!Directory.Exists("logs")) { Directory.CreateDirectory("logs"); }
            File.AppendAllText($"logs/{TimeHelper.GetTimeWrite()}.log", $"[{DateTime.Now.ToString()}] {print}\n");
        }
        static void PWOnly(string print)
        {
            if (!Directory.Exists("logs")) { Directory.CreateDirectory("logs"); }
            File.AppendAllText($"logs/{TimeHelper.GetTimeWrite()}.log", $"[{DateTime.Now.ToString()}] {print}\n");
        }

        #endregion
    }
}
