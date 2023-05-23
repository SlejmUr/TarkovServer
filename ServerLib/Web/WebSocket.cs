using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Utilities;
using System.Text;
using WatsonWebsocket;

namespace ServerLib.Web
{
    public class WebSocket
    {
        static WatsonWsServer wsServer;
        public static string IpPort = "wss://127.0.0.1:444/";
        public static string IP = "127.0.0.1:444";
        public static List<string> ConnectedIps = new();
        public static Dictionary<Guid, string> GuidIP = new();
        public static Dictionary<string, Guid> IPToGuid = new();
        public static Dictionary<string, string> ConnectedSessions = new();
        public static EventHandler<MessageReceivedEventArgs> MessageReceivedEvent = null;
        public static void Start(string ip, int port, bool ssl = true)
        {
            IpPort = ssl ? $"wss://{ip}:{port}/socket/" : $"ws://{ip}:{port}/socket/";
            IP = $"{ip}:{port}";
            Console.WriteLine("WebSocket Server started on " + IpPort);
            wsServer = new WatsonWsServer(ip, port, ssl);
            wsServer.Logger = Debug.PrintWebsocket;
            wsServer.AcceptInvalidCertificates = true;
            wsServer.ClientConnected += ClientConnected;
            wsServer.ClientDisconnected += ClientDisconnected;
            wsServer.MessageReceived += MessageReceived;
            wsServer.Start();
        }

        private static void MessageReceived(object? sender, MessageReceivedEventArgs args)
        {
            Console.WriteLine(args.MessageType);
            Console.WriteLine($"Message received from {args.Client.Guid} ({args.Client.Ip}) : " + Encoding.UTF8.GetString(args.Data));
            MessageReceivedEvent?.Invoke(sender, args);
        }

        private static void ClientDisconnected(object? sender, DisconnectionEventArgs args)
        {
            if (ConnectedSessions.ContainsValue(args.Client.IpPort))
            {
                var Session = ConnectedSessions.Where(x => x.Value == args.Client.IpPort).FirstOrDefault().Key;
                ConnectedSessions.Remove(Session);
            }
            ConnectedIps.Remove(args.Client.IpPort);
            GuidIP.Remove(args.Client.Guid);
            IPToGuid.Remove(args.Client.IpPort);
            Console.WriteLine("Client disconnected: " + args.Client.IpPort);
        }

        private static void ClientConnected(object? sender, ConnectionEventArgs args)
        {
            Debug.PrintInfo("ClientConnected");
            Debug.PrintInfo(args.ToString());
            ConnectedIps.Add(args.Client.IpPort);
            GuidIP.Add(args.Client.Guid, args.Client.IpPort);
            IPToGuid.Add(args.Client.IpPort, args.Client.Guid);
            Console.WriteLine("Client Cookies: " + JsonConvert.SerializeObject(args.HttpRequest.Cookies));
            string SessionId = args.HttpRequest.Url.OriginalString.Split("socket/")[1];
            ConnectedSessions.Add(SessionId, args.Client.IpPort);

            Console.WriteLine("Client connected: " + args.Client.IpPort + " " + SessionId);

            SendToClient(args.Client.IpPort, JsonConvert.SerializeObject("{type: \"ping\",eventId: \"ping\"}"));
            Console.WriteLine("Pinged Player " + SessionId);
        }

        public static void Stop()
        {
            if (wsServer != null)
            {
                wsServer.Stop();
                wsServer.Dispose();
            }
        }

        public static bool SendToClient(string ipPort, string text)
        {
            if (IPToGuid.TryGetValue(ipPort, out var guid))
            {
                if (wsServer.IsClientConnected(guid))
                {
                    bool isSuccess = wsServer.SendAsync(guid, text).Result;
                    return isSuccess;
                }
            }
            return false;
        }


        public static bool SendToClient(string ipPort, byte[] bytes)
        {
            if (IPToGuid.TryGetValue(ipPort, out var guid))
            {
                if (wsServer.IsClientConnected(guid))
                {
                    bool isSuccess = wsServer.SendAsync(guid, bytes).Result;
                    return isSuccess;
                }
            }
            return false;
        }
    }
}
