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
            byte[] crc_0 = new byte[] { 0x78, 0xda, 0xab, 0x56 ,0x4a ,0x2e ,0x4a ,0x56 ,0xb2 ,0x32 ,0xa8 ,0x05 ,0x00 ,0x0e ,0xcf ,0x02 ,0xdf };
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