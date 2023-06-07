using System.Net.Sockets;
using System.Text;
using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;

namespace ServerLib.Web
{
    public class WebSocket
    {
        public static string IpPort = "ws://127.0.0.1:444/";
        public static string IP = "127.0.0.1:444";
        public static List<string> ConnectedIps = new();
        public static Dictionary<Guid, string> GuidIP = new();
        public static Dictionary<string, Guid> IPToGuid = new();
        public static Dictionary<string, string> ConnectedSessions = new();
        public static EventHandler<byte[]> MessageReceivedEvent = null;
        static TarkovServer SocketServer;
        public static void Start(string ip, int port, bool ssl = true)
        {
            if (ssl)
            {
                Debug.PrintWarn("Currently WSS not supperted! Using WS");
            }
            //IpPort = ssl ? $"wss://{ip}:{port}/socket/" : $"ws://{ip}:{port}/socket/";
            IpPort = $"ws://{ip}:{port}/";
            IP = $"{ip}:{port}";
            SocketServer = new(ip, port);
            SocketServer.Start();
            Console.WriteLine("WebSocket Server started on " + IpPort);
        }
        public static void Stop()
        {
            if (SocketServer != null)
            {
                SocketServer.Stop();
                SocketServer.Dispose();
            }
        }

        public static TarkovServer? GetServer()
        {
            if (SocketServer != null && !SocketServer.IsDisposed)
            {
                return SocketServer;
            }
            return null;
        }

        public class TarkovSession : WsSession
        {
            public TarkovSession(WsServer server) : base(server) { }

            public override void OnWsConnected(HttpRequest request)
            {
                Console.WriteLine($"WebSocket session with Id {Id} connected!");
                Debug.PrintDebug(request.ToString());
                Debug.PrintDebug(request.Url);
                //Server.Multicast(JsonConvert.SerializeObject(NotificationController.DefaultNotification(), Formatting.Indented));
            }

            public override void OnWsDisconnected()
            {
                Console.WriteLine($"WebSocket session with Id {Id} disconnected!");
            }

            public override void OnWsReceived(byte[] buffer, long offset, long size)
            {
                try
                {
                    string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
                    Console.WriteLine("Incoming: " + message);
                }
                catch
                {
                    Console.WriteLine("Incoming: " + BitConverter.ToString(buffer));
                }

            }

            protected override void OnError(SocketError error)
            {
                Console.WriteLine($"WebSocket session caught an error with code {error}");
            }
        }

        public class TarkovServer : WsServer
        {
            public TarkovServer(string address, int port) : base(address, port) { }

            protected override TcpSession CreateSession() { return new TarkovSession(this); }

            protected override void OnError(SocketError error)
            {
                Console.WriteLine($"Tarkov WebSocket server caught an error with code {error}");
            }
        }
    }
}
