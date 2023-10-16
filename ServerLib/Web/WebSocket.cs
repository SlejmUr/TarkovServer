using System.Reflection;
using ModdableWebServer;
using ModdableWebServer.Attributes;
using ModdableWebServer.Helper;
using ModdableWebServer.Servers;
using NetCoreServer;

namespace ServerLib.Web
{
    public class WebSocket
    {
        public static string IpPort = "ws://127.0.0.1:444/";
        public static string IP = "127.0.0.1:444";
        static WSS_Server? WSS_Server = null;
        static WS_Server? WS_Server = null;
        public static void Start(string ip, int port, bool ssl = true)
        {
            if (ssl)
            {
                var cert = Utilities.Helpers.CertHelper.GetCert();
                SslContext context = new(System.Security.Authentication.SslProtocols.Tls12, cert);
                WSS_Server = new(context, ip, port);
                WSS_Server.WS_AttributeToMethods.Merge(Assembly.GetAssembly(typeof(WebSocket)));
                WSS_Server.Start();
            }
            else 
            {
                WS_Server = new(ip, port);
                WS_Server.WS_AttributeToMethods.Merge(Assembly.GetAssembly(typeof(WebSocket)));
                WS_Server.Start();
            }
            IpPort = ssl ? $"wss://{ip}:{port}/socket/" : $"ws://{ip}:{port}/socket/";
            IP = $"{ip}:{port}";
            Console.WriteLine("WebSocket Server started on " + IpPort);
        }

        public static void Stop()
        {
            if (WS_Server != null)
            {
                WS_Server.Stop();
                WS_Server = null;
            }
            if (WSS_Server != null)
            {
                WSS_Server.Stop();
                WSS_Server = null;
            }
        }

        [WS("/socket/{id}")]
        public static void WSControl(WebSocketStruct webSocket)
        {
            Console.WriteLine("websocket hit!");
        }
    }
}
