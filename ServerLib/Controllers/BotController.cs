using Newtonsoft.Json;
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
            Bots.Item item = new();
            item.Id = Utils.CreateNewID();
            item.Tpl = bot.Info.Side == "Usec" ? "59f32c3b86f77472a31742f0" : "59f32bb586f774757e1e8442";
            item.ParentId = bot.Inventory.Equipment;
            item.SlotId = "Dogtag";
            Bots.Dogtag dogtag = new();
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

            List<Bots.Item> items = new();
            items.Add(item);
            bot.Inventory.Items = items.ToArray();
            return bot;
        }

        public static string GetBotDifficulty(string type, string difficulty)
        {
            switch (type)
            {
                case "core":
                    return DatabaseController.DataBase.Bot.Settings;
                default:
                    switch (difficulty)
                    {
                        case "Custom":
                            return DatabaseController.DataBase.Bot.Bots[type].Difficulty.Custom;
                        case "Easy":
                            return DatabaseController.DataBase.Bot.Bots[type].Difficulty.Easy;
                        case "Hard":
                            return DatabaseController.DataBase.Bot.Bots[type].Difficulty.Hard;
                        case "Impossible":
                            return DatabaseController.DataBase.Bot.Bots[type].Difficulty.Impossible;
                        default:
                            return DatabaseController.DataBase.Bot.Bots[type].Difficulty.Normal;
                    }
            }
        }

        public static string GenerateBotName(string role)
        {
            return Utils.GetRandomArray(DatabaseController.DataBase.Bot.NamesDict[role].ToArray());
        }

        public static Bots.BotBase GenerateNewID(Bots.BotBase bot)
        {
            var ID = Utils.CreateNewID();
            bot.Id = ID;
            bot.Aid = ID;
            return bot;
        }

        public static List<Bots.BotBase> GenerateBot(Bots.BotGenerate generate, string sessionID)
        {
            //DO botgen
            return new();
        }

        public static Bots.BotBase GenerateInventory(Bots.BotBase bot)
        {
            Dictionary<string, Bots.Item> inventoryItemHash = new();
            Dictionary<string, Bots.Item> itemsByParentHash = new();
            string InventoryID = "";


            foreach (var item in bot.Inventory.Items)
            {
                inventoryItemHash.Add(item.Id, item);

                if (item.Tpl == "55d7217a4bdc2d86028b456d")
                {
                    InventoryID = item.Id;
                    continue;
                }
                if (!string.IsNullOrEmpty(item.ParentId))
                {
                    continue;
                }

                if (!itemsByParentHash.ContainsKey(item.ParentId))
                {
                    itemsByParentHash.Add(item.ParentId, item);
                    continue;
                }
                itemsByParentHash.Add(item.ParentId, item);
            }
            string newID = Utils.CreateNewID();
            inventoryItemHash[InventoryID].Id = newID;
            bot.Inventory.Equipment = newID;

            if (itemsByParentHash.ContainsKey(InventoryID))
            {
                itemsByParentHash[InventoryID].ParentId = newID;
            }
            return bot;
        }

        public static void GenerateLevel(int min, int max, int playerlevel, out int lvl, out int xp)
        {
            dynamic global = JsonConvert.DeserializeObject<dynamic>(DatabaseController.DataBase.Basic.Globals);
            var exptable = global.config.exp.level.exp_table;
            Other.ExpTableClass expTableClass = exptable;

            int maxlvl = Math.Max(max, expTableClass.ExpTable.Count);
            int limit_max = playerlevel + 10;
            int limit_min = playerlevel - 5;
            if (limit_max > maxlvl)
            {
                limit_max = maxlvl;
            }
            if (playerlevel <= 5)
            {
                limit_min = 1;
            }
            xp = 0;

            lvl = Utils.GetRandomInt(limit_min, limit_max);

            for (int i = 0; i < lvl; i++)
            {
                xp += expTableClass.ExpTable[i].Exp;
            }

            if (lvl < expTableClass.ExpTable.Count - 1)
            {
                xp += Utils.GetRandomInt(0, expTableClass.ExpTable[lvl].Exp - 1);
            }

        }
    }
}
