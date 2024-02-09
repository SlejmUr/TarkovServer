using ModdableWebServer;
using TestServer.Messages;

namespace TestServer
{
    public class WS_MessageController
    {
        public static void Work(WebSocketStruct socketStruct, string Id)
        {
            var req = socketStruct.WSRequest!.Value;
            var bytes = req.buffer.Skip((int)req.offset).Take((int)req.size).ToArray();

            BinaryReader binaryReader = new(new MemoryStream(bytes));
            MessageId msgId = (MessageId)binaryReader.ReadByte();
            switch (msgId)
            {
                case MessageId.KeepAlive:
                    KeepAlive.Work(binaryReader, socketStruct, Id);
                    break;
                case MessageId.InitConnection:
                    break;
                case MessageId.NewUserConnected:
                    break;
                case MessageId.UserDisconnected:
                    break;
                case MessageId.SpawnUser:
                    break;
                case MessageId.DespawnUser:
                    break;
                case MessageId.MatchRestarting:
                    break;
                default:
                    break;
            }
            binaryReader.Close();
            binaryReader.Dispose();
        }
    }
}
