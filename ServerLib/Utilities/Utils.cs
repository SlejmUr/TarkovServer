using NetCoreServer;
using ServerLib.Controllers;
using System.Security.Cryptography;
using System.Text;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Utilities
{
    public class Utils
    {
        #region Parameter url stuff
        public static bool Match(string url, string pattern, out Dictionary<string, string> vals)
        {
            vals = new();
            if (String.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));
            if (String.IsNullOrEmpty(pattern)) throw new ArgumentNullException(nameof(pattern));

            vals = new Dictionary<string, string>();
            string[] urlParts = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string[] patternParts = pattern.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (urlParts.Length != patternParts.Length) return false;

            for (int i = 0; i < urlParts.Length; i++)
            {
                string paramName = ExtractParameter(patternParts[i]);

                if (String.IsNullOrEmpty(paramName))
                {
                    // no pattern
                    if (!urlParts[i].Equals(patternParts[i]))
                    {
                        vals = new();
                        return false;
                    }
                }
                else
                {
                    vals.Add(
                        paramName.Replace("{", "").Replace("}", ""),
                        urlParts[i]);
                }
            }
            return true;
        }

        private static string ExtractParameter(string pattern)
        {
            if (String.IsNullOrEmpty(pattern)) throw new ArgumentNullException(nameof(pattern));

            if (pattern.Contains("{"))
            {
                if (pattern.Contains("}"))
                {
                    int indexStart = pattern.IndexOf('{');
                    int indexEnd = pattern.LastIndexOf('}');
                    if ((indexEnd - 1) > indexStart)
                    {
                        return pattern.Substring(indexStart, (indexEnd - indexStart + 1));
                    }
                }
            }

            return null;
        }
        #endregion
        #region Session Stuff
        public static bool SendUnityResponse(HttpsBackendSession session, string resp)
        {
            var rsp = session.Response.MakeGetResponse(resp, "application/json");
            rsp = rsp.SetHeader("Content-Type", "application/json");
            rsp = rsp.SetHeader("Content-Encoding", "deflate");
            session.SendResponse(rsp);
            return true;
        }

        public static bool SendUnityResponse(HttpsBackendSession session, byte[] resp)
        {
            var rsp = session.Response.MakeGetResponse(resp, "application/json");
            rsp = rsp.SetHeader("Content-Type", "application/json");
            rsp = rsp.SetHeader("Content-Encoding", "deflate");
            session.SendResponse(rsp);
            return true;
        }
        public static void PrintRequest(HttpRequest req, HttpsBackendSession session)
        {
            Dictionary<string, string> Headers = new();
            for (int i = 0; i < req.Headers; i++)
            {
                var headerpart = req.Header(i);
                Headers.Add(headerpart.Item1, headerpart.Item2);
            }
            string time = DateTime.UtcNow.ToString();
            string fullurl = req.Url;
            string from_ip = session.Socket.RemoteEndPoint.ToString();
            string SessionId = GetSessionId(Headers);
            Console.WriteLine("[" + time + "] " + from_ip + " | " + SessionId + " = " + fullurl);
        }
        public static string GetSessionId(Dictionary<string, string> HttpHeaders)
        {
            if (HttpHeaders.ContainsKey("Cookie"))
            {
                var Cookie = HttpHeaders["Cookie"];
                var SessionId = Cookie.Split("=")[1];
                return SessionId;
            }
            return "";
        }
        public static string GetVersion(Dictionary<string, string> HttpHeaders)
        {
            if (HttpHeaders.ContainsKey("App-Version"))
            {
                var AppVersion = HttpHeaders["App-Version"];
                var Version = AppVersion.Replace("EFT Client ", "");
                return Version;
            }
            return "";
        }
        #endregion

        private static int _id = 100;
        public static string CreateNewID(string prefix = "")
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
                md5_str = prefix + md5_str;
            }
            string idhex = _id.ToString("X2");
            _id++;
            return md5_str + "00" + idhex;
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
            return data.Replace("\b", "").Replace("\f", "").Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace("\\", "");
        }
        public static int ValuesBetween(int value, int minInput, int maxInput, int minOutput, int maxOutput)
        {
            return (maxOutput - minOutput) * ((value - minInput) / (maxInput - minInput)) + minOutput;
        }

        public static int GetRandomInt(int min = 0, int max = 100)
        {
            Random random = new();
            return random.Next(min, max);
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
            return array[GetRandomInt(0, array.Length)];
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

        public static List<Json.Other.AmmoItems> SplitStack(Json.Other.AmmoItems item)
        {
            List<Json.Other.AmmoItems> listitem = new();
            if (item.upd == null)
            {
                listitem.Add(item);
                return listitem;
            }
            var maxStack = DatabaseController.DataBase.Others.Items[item._tpl].Props.StackMaxSize;
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

                newStack._id = CreateNewID();
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
