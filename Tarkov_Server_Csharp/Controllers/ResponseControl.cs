using ComponentAce.Compression.Libs.zlib;
using Ionic.Zlib;

namespace Tarkov_Server_Csharp.Web
{
    public class ResponseControl
    {

        public static string GetBody(string Data, int errorcode = 0, string errormsg = "null")
        {
            var Stuff =  "{\"err\":"+ errorcode + ",\"errmsg\":"+ errormsg + ",\"data\":" + Data + "}";
            return Stuff;
        }
        public static string NullResponse()
        {
            return GetBody(null);
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
            return ZlibStream.UncompressString(data);
        }
    }
}