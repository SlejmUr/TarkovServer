using Ionic.Zlib;
using System.Net;

namespace Tarkov_Server_Csharp
{
    internal class Program
    {
        static string IP_Address = "26.48.71.165"; //Or use Localhost
        static int Port = 7777;
        public static string ip_port = $"https://{IP_Address}:{Port}";
        static void Main(string[] args)
        {
            /*
            byte[] crc_0 = new byte[] { 0x78, 0x9c, 0xab, 0x56, 0x4a, 0x2d, 0x2a, 0x52, 0xb2, 0x32, 0xd0, 0x01, 0xd1, 0xb9, 0xc5, 0xe9, 0x4a, 0x56, 0x79, 0xa5, 0x39, 0x39, 0x3a, 0x4a, 0x29, 0x89, 0x25, 0x89, 0x4a, 0x56, 0xd5, 0x4a, 0xa5, 0x25, 0xc9, 0xf1, 0x25, 0x99, 0xb9, 0xa9, 0x4a, 0x56, 0x86, 0x66, 0xa6, 0xe6, 0x26, 0x16, 0xe6, 0xe6, 0x06, 0xc6, 0x7a, 0x66, 0xa6, 0x96, 0xb5, 0xb5, 0x00, 0x25, 0x27, 0x11, 0xdb };
            string Uncompressed = ZlibStream.UncompressString(crc_0);
            Console.WriteLine(Uncompressed);
            var compressed =ZlibStream.CompressString(Uncompressed);
            Console.WriteLine(Utils.ByteArrayToString(compressed));
            */
            CertHelper.Make(IPAddress.Parse(IP_Address));
            Console.WriteLine("Hello World!");
            Console.WriteLine($"http://{IP_Address}:{Port}/");
            WebServer webServer = new WebServer();
            webServer.MainStart(IP_Address,Port);
        }
    }
}