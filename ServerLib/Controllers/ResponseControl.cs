using ComponentAce.Compression.Libs.zlib;
using ServerLib.Controllers;

namespace ServerLib.Web
{
    public class ResponseControl
    {
        public static string NoBody(string Data)
        {
            return Utilities.Utils.ClearString(Data);
        }
        public static string GetBody(string Data, int errorcode = 0, string errormsg = "null")
        {
            if (errormsg != "null")
            {
                errormsg = "\""+ errormsg +"\"";
            }
            var Stuff = "{\"err\":" + errorcode + ",\"errmsg\":" + errormsg + ",\"data\":" + Data + "}";
            return Stuff;
        }
        public static string GetBodyCRC(string Data, int errorcode = 0, string errormsg = "null", uint crc = 0)
        {
            var Stuff = "{\"err\":" + errorcode + ",\"errmsg\":" + errormsg + ",\"data\":" + Data + ",\"crc\":" + crc + "}";
            return Stuff;
        }
        public static string BodyWithCheckUserAccess(string SessionId, string Body)
        {
            if (AccountController.IsAccountBanned(SessionId))
            {
                return GetBody("", 205, "You are banned.");
            }
            return GetBody(Body);
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
    }
}