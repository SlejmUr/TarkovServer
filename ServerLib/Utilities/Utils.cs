using EFT;
using ModdableWebServer;
using ModdableWebServer.Helper;
using NetCoreServer;
using ServerLib.Web;

namespace ServerLib.Utilities
{
    public class Utils
    {
        #region Session Stuff
        internal static int ReqId = 0;
        public static bool SendUnityResponse(HttpRequest req, ServerStruct serverStruct, string resp)
        {
            var url = req.Url.Replace("/","_");
            string SessionId = GetSessionId(serverStruct.Headers);
            File.WriteAllText("ServerResponses/" + ReqId + "_" + SessionId + url + ".json", resp); 
            ReqId++;
            return SendUnityResponse(serverStruct, ResponseControl.CompressRsp(resp));
        }

        public static bool SendUnityResponse(ServerStruct serverStruct, byte[] resp)
        {
            serverStruct.Response.MakeGetResponse(resp, "application/json");
            serverStruct.SendResponse();
            Debug.PrintDebug("WE SENT UNITY RESPONSE!");
            return true;
        }

        public static void PrintRequest(HttpRequest req, ServerStruct serverStruct)
        {
            string time = DateTime.UtcNow.ToString();
            string fullurl = req.Url;
            string from_ip = GetFromIP(serverStruct);
            string SessionId = GetSessionId(serverStruct.Headers);
            Console.WriteLine("[" + time + "] " + from_ip + " | " + SessionId + " = " + fullurl);
        }


        public static string GetFromIP(ServerStruct serverStruct)
        {
            switch (serverStruct.Enum)
            {
                case ServerEnum.HTTP:
                    return serverStruct.HTTP_Session.Socket.RemoteEndPoint.ToString();
                case ServerEnum.HTTPS:
                    return serverStruct.HTTPS_Session.Socket.RemoteEndPoint.ToString();
                case ServerEnum.WS:
                    return serverStruct.WS_Session.Socket.RemoteEndPoint.ToString();
                case ServerEnum.WSS:
                    return serverStruct.WSS_Session.Socket.RemoteEndPoint.ToString();
                default:
                    return "NoIP";
            }
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
