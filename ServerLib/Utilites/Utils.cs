using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using HttpServerLite;
using ServerLib.Handlers;
using ServerLib.Json;
using ServerLib.Controllers;
using Newtonsoft.Json;

namespace ServerLib.Utilities
{
    public class Utils
    {
        #region HttpStuff
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
        #endregion
        #region Debug Print
        public static void PrintDebug(string ToPrint, string type = "info",string prefix = "[DEBUG]")
        {
            if (ArgumentHandler.Debug)
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
        #region Session Stuff
        public static void PrintRequest(HttpRequest req)
        {
            string time = req.TimestampUtc.ToString();
            string fullurl = req.Url.Full;
            string from_ip = req.Source.IpAddress;
            string SessionID = GetSessionID(req.Headers);
            Console.WriteLine("[" + time + "] " + from_ip + " | " + SessionID + " = " + fullurl);
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
        #endregion

        private static int _id = 100;
        public static string CreateNewProfileID(string prefix = "")
        {
            Random rand = new();
            int stringlen = 24;
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {
                randValue = rand.Next(0, 26);
                letter = Convert.ToChar(randValue + 65);
                str = str + letter;
            }
            string md5_str = ConvertStringtoMD5(str);
            if (prefix == "AID")
            {
                md5_str = "AID" + md5_str;
            }
            string idhex = _id.ToString("X2");
            _id++;
            return md5_str  + "00" + idhex;
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

        public static string ByteArrayToString(byte[] bytearray)
        {
            return BitConverter.ToString(bytearray).Replace("-", " ");
        }
        public static string ToBase64(byte[] bytearray)
        {
            return Convert.ToBase64String(bytearray);
        }
        public static double UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return timeSpan.TotalSeconds;
        }

        public static int UnixTimeNow_Int()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (int)(timeSpan.TotalSeconds);
        }

        public static string ClearString(string data)
        {
            return data.Replace("\b","").Replace("\f", "").Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace("\\", "");
        }
        public static int ValuesBetween(int value, int minInput,int maxInput,int minOutput,int maxOutput)
        {
            return (maxOutput - minOutput) * ((value - minInput) / (maxInput - minInput)) + minOutput;
        }

        public static int GetRandomInt(int min = 0,int max = 100)
        {
            Random random = new();
            return random.Next(min,max);
        }

        public static int GetPrecentDifference(int num1, int num2)
        {
            return (num1 / num2) * 100;
        }
        public static int GetPrecentOf(int num1, int num2)
        {
            return (num1 / 100) * num2;
        }
        public static bool PrecentRandomBool(int percentage)
        { 
            return GetRandomInt() < percentage;
        }
        public static string GetRandomArray(string[] array)
        {
            return array[GetRandomInt(0,array.Length)];
        }
        public static string GetTime()
        {
            return FormatTime(DateTime.Now);
        }
        public static string FormatTime(DateTime time)
        {
            string timestring = time.ToString();
            string[] timesplit = timestring.Split(". ");
            return timesplit[0] + "-" + timesplit[1] + "-" + timesplit[2] + "_" + timesplit[3].Replace(":", "-");
        }

        public static Bots.BotBase GenerateInventory(Bots.BotBase bot)
        {
            Dictionary<string, dynamic> inventoryItemHash = new();
            Dictionary<string, dynamic> itemsByParentHash = new();
            string InventoryID = "";


            foreach (var item in bot.Inventory.Items)
            {
                dynamic itemdynamic = JsonConvert.DeserializeObject<dynamic>(item.ToString());
                if (itemdynamic == null) continue;
                inventoryItemHash.Add(itemdynamic._id, itemdynamic);

                if (itemdynamic._tpl == "55d7217a4bdc2d86028b456d")
                {
                    InventoryID = itemdynamic._id;
                    continue;
                }

                try
                {
                    if (!itemdynamic.ToString().Contains("parentId"))
                    {
                        continue;
                    }
                }
                catch
                {
                    PrintError("Cannot TRY to get item parentID!\n " + itemdynamic.ToString(), "WARNING", "[GenerateInventory]");
                }

                try
                {
                    if (!itemsByParentHash.ContainsKey(itemdynamic.parentId))
                    {
                        itemsByParentHash.Add(itemdynamic.parentId, itemdynamic);
                        continue;
                    }
                }
                catch
                {
                    PrintError("Cannot TRY itemsByParentHash NOT has parentID!\n " + itemdynamic.ToString(), "WARNING", "[GenerateInventory]");
                }
                try
                {
                    itemsByParentHash.Add(itemdynamic.parentId, itemdynamic);
                }
                catch
                {
                    PrintError("Cannot TRY to add parentID, to itemsByParentHash!\n " + itemdynamic.ToString(), "WARNING", "[GenerateInventory]");
                }
            }
            string newID = CreateNewProfileID();
            inventoryItemHash[InventoryID]._id = newID;
            bot.Inventory.Equipment = newID;

            if (itemsByParentHash.ContainsKey(InventoryID))
            {
                foreach (dynamic item in itemsByParentHash[InventoryID])
                {
                    item.parentId = newID;
                }
            }
            return bot;
        }
        public static List<Other.AmmoItems> SplitStack(Other.AmmoItems item)
        {
            List<Other.AmmoItems> listitem = new();
            if (item.upd == null)
            {
                listitem.Add(item);
                return listitem;
            }
            var maxStack = DatabaseController.DataBase.Items[item._tpl].Props.StackMaxSize;
            var count = item.upd.StackObjectsCount;

            if (count <= maxStack)
            {
                listitem.Add(item);
                return listitem;
            }

            while (count != 0)
            {
                
                long longcount = long.Parse(count.ToString());
                long longmaxStack = long.Parse(maxStack.ToString());
                long amount = Math.Min(longcount, longmaxStack);
                var newStack = item;

                newStack._id = CreateNewProfileID();
                newStack.upd.StackObjectsCount = (int)amount;
                count -= (int)amount;
                listitem.Add(newStack);
            }
            return listitem;
        }
        public static int Clamp(int value, int min, int max)
        { 
            return Math.Min(Math.Max(value, min), max);
        }
    }
}
