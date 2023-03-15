using Newtonsoft.Json;
using System;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var character = JsonConvert.DeserializeObject<ChatShared.ChatRoomMember>(File.ReadAllText("user\\profiles\\AID9b38399c1e9c5bc056387382\\character.json"));

            if (character == null)
            {
                Console.WriteLine("sad");
            }
            else
            {
                Console.WriteLine(JsonConvert.SerializeObject(character));
                ChatShared.UpdatableChatMember member = new("");
                member.UpdateFromChatMember(character);
                Console.WriteLine(JsonConvert.SerializeObject(member));

            }

        }
    }
}