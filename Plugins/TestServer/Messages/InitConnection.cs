using ModdableWebServer;
using ModdableWebServer.Helper;
using ServerLib.Controllers;
using ServerLib.Web;
using Newtonsoft.Json;

namespace TestServer.Messages
{
    public class InitConnection
    {
        public static void Work(BinaryReader binaryReader, WebSocketStruct socketStruct, string id)
        {
            var Location = binaryReader.ReadString();
            Console.WriteLine($"[TS.Messages.InitConnection] Unity Server ({id}) sent InitConnection, wants to host Map: {Location}");
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new(memoryStream);
            binaryWriter.Write((byte)MessageId.InitConnectionRsp);
            bool loadResult = ServerController.RequestLoadMap(Location);
            binaryWriter.Write(loadResult);
            if (loadResult)
            {
                var compressed = ResponseControl.CompressRsp(ServerController.GetMap(Location));
                binaryWriter.Write((byte)0);   //location
                binaryWriter.Write(compressed.Length);
                binaryWriter.Write(compressed);
                //Get random loot
                binaryWriter.Write((byte)1);   //random loot
                binaryWriter.Write(0);   //location

                //get random searching loot.
                binaryWriter.Write((byte)2);   //random loot
                binaryWriter.Write(0);   //location


                var weather = DatabaseController.DataBase.Weather["sun"];
                compressed = ResponseControl.CompressRsp($"[{JsonConvert.SerializeObject(weather)}]");
                binaryWriter.Write((byte)3);   //location
                binaryWriter.Write(compressed.Length);
                binaryWriter.Write(compressed);
            }
            binaryWriter.Flush();
            binaryWriter.Close();
            binaryWriter.Dispose();
            socketStruct.SendWebSocketByteArray(memoryStream.ToArray());
        }
    }
}
