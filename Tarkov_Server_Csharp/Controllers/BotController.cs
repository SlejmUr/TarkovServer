using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tarkov_Server_Csharp.Controllers
{
    internal class BotController
    {

        public static string GetNewBotProfile(string JsonInfo,string SessionId)
        {
            Console.WriteLine(JsonInfo + "\n" + SessionId);
            return "{}";
        }

        //TODO:
        // Figure out how is the bot parsed! (Create new JsonD for BOT?)
    }
}
