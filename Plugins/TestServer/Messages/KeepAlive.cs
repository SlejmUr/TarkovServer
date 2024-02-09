using ModdableWebServer;
using ModdableWebServer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer.Messages
{
    public class KeepAlive
    {
        public static void Work(BinaryReader binaryReader, WebSocketStruct socketStruct, string id)
        {
            var ServerSendTime = binaryReader.ReadInt64();
            Console.WriteLine($"[TS.Messages.KeepAlive] Unity Server ({id}) sent KeepAlive with the current time: {DateTimeOffset.FromUnixTimeMilliseconds(ServerSendTime).ToString("O")}");
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new(memoryStream);
            binaryWriter.Write((byte)MessageId.KeepAlive);
            binaryWriter.Write((long)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            binaryWriter.Flush();
            binaryWriter.Close();
            binaryWriter.Dispose();
            socketStruct.SendWebSocketByteArray(memoryStream.ToArray());
        }
    }
}
