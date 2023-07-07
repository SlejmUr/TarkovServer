using EFT;
using NetCoreServer;
using ServerLib.Web;
using System.Security.Cryptography;
using System.Text;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Utilities
{
    public class Utils
    {
        #region Session Stuff
        internal static int ReqId = 0;
        public static bool SendUnityResponse(HttpsBackendSession session, string resp)
        {
            var url = session.LastRequest().Url.Replace("/","_");
            if (url.Contains("?"))
                url = url.Replace("?","_");

            if (url.Contains("="))
                url = url.Replace("=", "_");

            string SessionId = GetSessionId(session.Headers);
            File.WriteAllText("ServerResponses/" + ReqId + "_" + SessionId + url + ".json", resp); 
            ReqId++;
            return SendUnityResponse(session, ResponseControl.CompressRsp(resp));
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
            if (HttpHeaders.ContainsKey("X-WSSE"))
            {
                var Cookie = HttpHeaders["X-WSSE"];
                var SessionId = Cookie.Split("=")[1].Split(" ")[0];
                return SessionId;
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
                sb.Append(hash[i].ToString("x2"));
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

        public static string ClearString(string data)
        {
            return data.Replace("\b", "").Replace("\f", "").Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace("\\", "");
        }
    }
}
