using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarkov_Server_Csharp.Controllers
{
    public class DatabaseController
    {
        public static JsonD.Database DataBase = new();
        static void GetDatabase()
        {
            ConfigController.Init();
            LoadCoreData();

            DataBase.Bots = new();
            //DataBase.Bots.Add();
        }

        static void LoadCoreData()
        {
            DataBase.Core = new();
            DataBase.Core.BotBase = File.ReadAllText("Files/base/botBase.json");
            DataBase.Core.BotCore = File.ReadAllText("Files/base/botCore.json");
            DataBase.Core.FleaOffer = File.ReadAllText("Files/base/fleaOffer.json");
            DataBase.Core.MatchMetrics = File.ReadAllText("Files/base/matchMetrics.json");
        }
    }
}
