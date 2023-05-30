using EFT;
using NetCoreServer;
using ServerLib.Web;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Utilities
{
    public class Utils
    {
        #region Session Stuff
        public static bool SendUnityResponse(HttpsBackendSession session, string resp)
        {
            var url = session.LastRequest().Url.Replace("/","_");
            string SessionId = GetSessionId(session.Headers);
            if (!Directory.Exists("ServerResponses")) { Directory.CreateDirectory("ServerResponses"); }
            File.WriteAllText("ServerResponses/" + SessionId + url + ".json", resp);
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
        public static string CreateNewID(string prefix = "")
        {
            MongoID mongo = new(true);
            var ret = mongo.Next().ToString();
            if (prefix != "")
            {
                ret = prefix + ret;
            }
            return ret;
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
