using ComponentAce.Compression.Libs.zlib;
using JsonLib.Classes.Websocket;

namespace ServerLib.Web
{
    public class ResponseControl
    {
        public static string NoBody(string Data)
        {
            return ClearString(Data);
        }
        public static string GetBody(string Data, int errorcode = 0, string errormsg = "null")
        {
            var Stuff = "{\"err\":" + errorcode + ",\"errmsg\":" + errormsg + ",\"data\":" + Data + "}";
            return Stuff;
        }
        public static string GetBodyCRC(string Data, int errorcode = 0, string errormsg = "null", uint crc = 0)
        {
            var Stuff = "{\"err\":" + errorcode + ",\"errmsg\":" + errormsg + ",\"data\":" + Data + ",\"crc\":" + crc + "}";
            return Stuff;
        }
        public static string NullResponse()
        {
            return GetBody("null");
        }
        public static string EmptyArrayResponse()
        {
            return GetBody("[]");
        }
        public static byte[] CompressRsp(string data)
        {
            return SimpleZlib.CompressToBytes(data, 6);
        }
        public static string DeCompressReq(byte[] data)
        {
            return SimpleZlib.Decompress(data);
        }

        public static string ClearString(string data)
        {
            return data.Replace("\b", "").Replace("\f", "").Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace("\\", "");
        }

        public static NotifierChannel GetNotifier(string SessionId)
        {
            NotifierChannel notifier = new()
            {
                server = ServerLib.ip_port,
                channel_id = SessionId,
                url = "",
                notifierServer = ServerLib.IP + "/notifierServer/" + SessionId,
                ws = ServerManager.IpPort_WS + SessionId
            };

            return notifier;
        }
    }
}