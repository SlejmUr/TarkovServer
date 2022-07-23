using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using HttpServerLite;
using ServerLib.Handlers;

namespace ServerLib.Utilities
{
    public class Utils
    {
        public static Func<HttpContext, Task> ToRouteMethod(MethodInfo method)
        {
            if (method.IsStatic)
            {
                return (Func<HttpContext, Task>)Delegate.CreateDelegate(typeof(Func<HttpContext, Task>), method);
            }
            else
            {
                object instance = Activator.CreateInstance(method.DeclaringType ?? throw new Exception("Declaring class is null"));
                return (Func<HttpContext, Task>)Delegate.CreateDelegate(typeof(Func<HttpContext, Task>), instance, method);
            }
        }
        public static bool IsStaticRoute(MethodInfo method)
        {
            return method.GetCustomAttributes().OfType<StaticRouteAttribute>().Any()
               && method.ReturnType == typeof(Task)
               && method.GetParameters().Length == 1
               && method.GetParameters().First().ParameterType == typeof(HttpContext);
        }
        public static void PrintDebug(string ToPrint, string type = "info",string prefix = "[DEBUG]")
        {
            if (ArgumentHandler.Debug)
            { 
                Console.ForegroundColor = GetColorByType(type);
                Console.WriteLine(prefix + " " + ToPrint);
                Console.ResetColor();
            }      
        }
        public static void PrintRequest(HttpRequest req)
        {
            string time = req.TimestampUtc.ToString();
            string fullurl = req.Url.Full;
            string from_ip = req.Source.IpAddress;
            string SessionID = GetSessionID(req.Headers);
            Console.WriteLine("[" + time + "] " + from_ip + " | " + SessionID + " = " + fullurl);
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

        public static double UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return timeSpan.TotalSeconds;
        }

        public static string GetSessionID(Dictionary<string,string> HttpHeaders)
        {
            if (HttpHeaders.ContainsKey("Cookie"))
            {
                var Cookie = HttpHeaders["Cookie"];
                var SessionID = Cookie.Split("=")[1];
                return SessionID;
            }
            return null;
        }

        public static string GetVersion(Dictionary<string, string> HttpHeaders)
        {
            if (HttpHeaders.ContainsKey("App-Version"))
            {
                var AppVersion = HttpHeaders["App-Version"];
                var Version = AppVersion.Replace("EFT Client ", "");
                return Version;
            }
            return null;
        }
        public static string ByteArrayToString(byte[] bytearray)
        {
            return BitConverter.ToString(bytearray).Replace("-", " ");
        }

        public static string ToBase64(byte[] bytearray)
        {
            return Convert.ToBase64String(bytearray);
        }
        public static string CreateNewProfileID(string prefix = "")
        {
            Random rand = new Random();

            // Choosing the size of string
            // Using Next() string
            int stringlen = 24;
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {

                // Generating a random number.
                randValue = rand.Next(0, 26);

                // Generating random character by converting
                // the random number into character.
                letter = Convert.ToChar(randValue + 65);

                // Appending the letter to string.
                str = str + letter;
            }
            string md5_str = ConvertStringtoMD5(str);
            if (prefix == "AID")
            {
                md5_str = "AID" + md5_str;
            }
            return md5_str;
        }

        public static string ConvertStringtoMD5(string strword)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(strword);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
