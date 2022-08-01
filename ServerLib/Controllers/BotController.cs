using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServerLib.Json;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class BotController
    {

        public static string GetNewBotProfile(string JsonInfo, string SessionId)
        {
            Console.WriteLine(JsonInfo + "\n" + SessionId);
            return "{}";
        }

        public static Bots.BotBase GenerateDogtag(Bots.BotBase bot)
        {
            Character.Item item = new();
            item.Id = Utils.CreateNewProfileID();
            item.Tpl = bot.Info.Side == "Usec" ? "59f32c3b86f77472a31742f0" : "59f32bb586f774757e1e8442";
            item.ParentId = bot.Inventory.Equipment;
            item.SlotId = "Dogtag";
            Character.Dogtag dogtag = new();
            dogtag.AccountId = bot.Aid.ToString();
            dogtag.ProfileId = bot.Id;
            dogtag.Nickname = bot.Info.Nickname;
            dogtag.Side = bot.Info.Side;
            dogtag.Level = bot.Info.Level;
            dogtag.Time = Utils.GetTime();
            dogtag.Status = "Killed by ";
            dogtag.KillerAccountId = "Unknown";
            dogtag.KillerProfileId = "Unknown";
            dogtag.KillerName = "Unknown";
            dogtag.WeaponName = "Unknown";
            item.Upd.Dogtag = dogtag;
            bot.Inventory.Items.Add(item);
            return bot;
        }

        public static string GetBotDifficulty(string type,string difficulty)
        {
            switch (type)
            {
                case "core":
                    return DatabaseController.DataBase.Core.BotCore;
                default:
                    switch (difficulty)
                    {
                        case "Custom":
                            return DatabaseController.DataBase.Bots[type].Difficulty.Custom;
                        case "Easy":
                            return DatabaseController.DataBase.Bots[type].Difficulty.Easy;
                        case "Hard":
                            return DatabaseController.DataBase.Bots[type].Difficulty.Hard;
                        case "Impossible":
                            return DatabaseController.DataBase.Bots[type].Difficulty.Impossible;
                        default:
                            return DatabaseController.DataBase.Bots[type].Difficulty.Normal;
                    }
                    
            
            }
        
        }

        public static string GenerateBotName(string role)
        {
            return Utils.GetRandomArray(JsonConvert.DeserializeObject<string[]>(DatabaseController.DataBase.Bots[role].BotNames));
        }


    }
}
