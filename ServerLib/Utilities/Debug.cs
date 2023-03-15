using ServerLib.Handlers;

namespace ServerLib.Utilities
{
    public class Debug
    {
        #region Debug Print
        public static void PrintDebug(string ToPrint, string type = "info", string prefix = "[INFO]")
        {
            if (ArgumentHandler.Debug || type != "debug")
            {
                Console.ForegroundColor = GetColorByType(type);
                Console.WriteLine(prefix + " " + ToPrint);
                Console.ResetColor();
            }
        }
        public static void PrintError(string ToPrint, string type = "error", string prefix = "[ERROR]")
        {
            Console.ForegroundColor = GetColorByType(type);
            Console.WriteLine(prefix + " " + ToPrint);
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
        #endregion
    }
}
