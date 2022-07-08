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
            CertHelper.Make(IPAddress.Parse(IP_Address));
            Console.WriteLine("Hello World!");
            Console.WriteLine($"http://{IP_Address}:{Port}/");
            WebServer.MainStart(IP_Address,Port);
        }
    }
}