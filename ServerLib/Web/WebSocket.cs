using System.Text;
using WatsonWebsocket;

namespace ServerLib.Web
{
    public class WebSocket
    {
        static WatsonWsServer wsServer;
        public static string IpPort = "ws://127.0.0.1:444/";
        public static List<string> ConnectedIps = new();
        public static Dictionary<string, string> ConnectedSessions = new();
        public static void Start(string ip, int port)
        {
            IpPort = $"ws://{ip}:{port}";
            Console.WriteLine("WebSocket Server started on ws://" + ip + ":" + port);
            wsServer = new WatsonWsServer(ip, port, false);
            wsServer.ClientConnected += ClientConnected;
            wsServer.ClientDisconnected += ClientDisconnected;
            wsServer.MessageReceived += MessageReceived;
            wsServer.Start();
        }

        public static void Stop()
        {
            wsServer.Stop();
            wsServer.Dispose();
        }

        public static bool SendToClient(string ipPort, string text)
        {
            if (wsServer.IsClientConnected(ipPort))
            {
                bool isSuccess = wsServer.SendAsync(ipPort, text).Result;
                return isSuccess;
            }
            return false;
        }
        public static bool SendToClient(string ipPort, byte[] bytes)
        {
            if (wsServer.IsClientConnected(ipPort))
            {
                bool isSuccess = wsServer.SendAsync(ipPort, bytes).Result;
                return isSuccess;
            }
            return false;
        }

        static void ClientConnected(object sender, ClientConnectedEventArgs args)
        {
            ConnectedIps.Add(args.IpPort);
            string SessionId = args.HttpRequest.Url.OriginalString.Split("socket/")[1];
            ConnectedSessions.Add(SessionId, args.IpPort);
            Console.WriteLine("Client connected: " + args.IpPort + " " + SessionId);
        }

        static void ClientDisconnected(object sender, ClientDisconnectedEventArgs args)
        {
            if (ConnectedSessions.ContainsValue(args.IpPort))
            {
                var Session = ConnectedSessions.Where(x => x.Value == args.IpPort).FirstOrDefault().Key;
                ConnectedSessions.Remove(Session);
            }
            ConnectedIps.Remove(args.IpPort);
            Console.WriteLine("Client disconnected: " + args.IpPort);
        }

        static void MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            Console.WriteLine(args.MessageType);
            Console.WriteLine("Message received from " + args.IpPort + ": " + Encoding.UTF8.GetString(args.Data));
        }
    }
}
