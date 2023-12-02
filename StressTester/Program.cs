using System;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using NetCoreServer;
using static JsonLib.Classes.ProfileRelated.Profile;

namespace StressTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string address = "127.0.0.1";
            if (args.Length > 0)
                address = args[0];

            // HTTPS server port
            int port = 443;
            if (args.Length > 1)
                port = int.Parse(args[1]);

            Console.WriteLine($"HTTPS server address: {address}");
            Console.WriteLine($"HTTPS server port: {port}");

            Console.WriteLine();
            var context = new SslContext(SslProtocols.Tls12, new X509Certificate2("cert.pfx", "cert"), (sender, certificate, chain, sslPolicyErrors) => true);

            // Create a new HTTPS client
            List<HttpsClientEx> clients = new();
            
            int max = 2;
            for (int i = 0; i <= max; i++)
            {
                var client = new HttpsClientEx(context, address, port); ;
                clients.Add(client);
            }
            foreach (var client in clients)
            {
                Thread x =new(()=> ChainNeeded.StartThis(client));
                x.Start();
            }
            Console.WriteLine("yeet");
            Console.WriteLine("done");
        }
    }
}