using ModdableWebServer.Attributes;
using ModdableWebServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    internal class WS_Server
    {
        [WS("/socket_server/{id}")]
        public static void WS_Server_Socket(WebSocketStruct socketStruct)
        {
            var id = socketStruct.Request.Parameters["id"];
            Console.WriteLine("websocket hit!");
            if (socketStruct.IsConnected)
            {
                /*
                if (!SocketUsers.ContainsKey(id))
                {
                    SocketUsers.Add(id, socketStruct);
                }*/
                if (socketStruct.WSRequest != null)
                {
                    WS_MessageController.Work(socketStruct, id);
                }
            }
            else if (!socketStruct.IsConnecting)
            {
                //SocketUsers.Remove(id);
            }
        }
    }
}
