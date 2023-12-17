using ModdableWebServer.Attributes;
using ModdableWebServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGAPlugin
{
    internal class MTGA_WS
    {
        [WS("/{id}")]
        public static void WSControl(WebSocketStruct socketStruct)
        {
            var id = socketStruct.Request.Parameters["id"];
            Console.WriteLine("websocket hit!");
            if (socketStruct.IsConnected)
            {
                if (!SocketUsers.ContainsKey(id))
                {
                    SocketUsers.Add(id, socketStruct);
                }
            }
            else if (!socketStruct.IsConnecting)
            {
                SocketUsers.Remove(id);
            }
        }

        public static Dictionary<string, WebSocketStruct> SocketUsers = new();

        public static WebSocketStruct? GetUser(string Id)
        {
            if (SocketUsers.TryGetValue(Id, out var webSocketStruct))
            {
                return webSocketStruct;
            }
            return null;
        }
    }
}
