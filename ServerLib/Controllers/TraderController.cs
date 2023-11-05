using Newtonsoft.Json;
using ServerLib.Json.Classes;
using ServerLib.Utilities.Helpers;
using static ServerLib.Json.Classes.Trader;

namespace ServerLib.Controllers
{
    public class TraderController
    {
        public static List<string> NotSellable = new() { "5449016a4bdc2d6f028b456f", "569668774bdc2da2298b4568", "5696686a4bdc2da3298b456a",
                "602543c13fee350cd564d032", "55d7217a4bdc2d86028b456d", "627a4e6b255f7527fb05a0f6",
                "5811ce772459770e9e5f9532", "5963866b86f7747bfa1c4462", "5963866286f7747bf429b572" , "557ffd194bdc2d28148b457f" };
        public static TraderAssort GetAssortByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Trader.Traders[TraderId].assort;
        }
        public static TraderBase GetBaseByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Trader.Traders[TraderId].traderbase;
        }
        public static List<Suit> GetSuitsByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Trader.Traders[TraderId].suits;
        }

        public static void SetAssortByTrader(string TraderId, TraderAssort assort)
        {
            DatabaseController.DataBase.Trader.Traders[TraderId].assort = assort;
        }
        public static Item.Base? GetAssortItemByID(string TraderId, string ItemId)
        {
            return GetAssortByTrader(TraderId).items.Find(item => item.Id == ItemId);
        }
        public static List<string> GetTradersKey()
        {
            List<string> output = new();
            foreach (var trader in DatabaseController.DataBase.Trader.Traders)
            {
                output.Add(trader.Key);
            }
            return output;
        }
        public static string GetCurrency(string Currency)
        {
            switch (Currency)
            {
                case "EUR":
                    return "569668774bdc2da2298b4568";
                case "USD":
                    return "5696686a4bdc2da3298b456a";
                default:
                    return "5449016a4bdc2d6f028b456f";
            }
        }
        public static string GetCurrencyFromTrader(string TraderId)
        {
            return GetCurrency(GetBaseByTrader(TraderId).currency);
        }
        public static string GetTraderName(string TraderId)
        {
            Dictionary<string, string> names = new()
            {
                { "54cb50c76803fa8b248b4571","Prapor" },
                { "54cb57776803fa99248b456e","Therapist" },
                { "579dc571d53a0658a154fbec","Fence" },
                { "58330581ace78e27b8b10cee","Skier" },
                { "5935c25fb3acc3127c3d8cd9","Peacekeeper" },
                { "5a7c2eca46aef81a7ca2145d","Mechanic" },
                { "5ac3b934156ae10c4430e83c","Ragman" },
                { "5c0647fdd443bc2504c2d371","Jaeger" },
                { "638f541a29ffd1183d187f57", "caretaker" }

            };
            return names[TraderId];
        }
        public static List<TraderBase> GetTradersInfo()
        {
            List<TraderBase> TraderBase = new();

            foreach (var trader in DatabaseController.DataBase.Trader.Traders)
            {
                if (!trader.Key.ToLower().Contains("ragfair"))
                {
                    if (trader.Value.traderbase.avatar.Contains("jpg"))
                    {
                        trader.Value.traderbase.avatar = trader.Value.traderbase.avatar.Replace("jpg", "png");
                    }
                    TraderBase.Add(trader.Value.traderbase);
                }
            }
            return TraderBase;
        }

        public static TraderAssort GenerateAssort(string TraderId, int currentTime)
        {
            TraderAssort traderassort = GetAssortByTrader(TraderId);
            TraderAssort output = traderassort;
            if (traderassort.nextResupply <= currentTime)
            {
                var refl = ConfigController.Configs.Gameplay.Trading.RefreshTimeInMinutes;
                output.nextResupply = currentTime + refl * 60;
                SetAssortByTrader(TraderId, output);
            }
            return output;
        }

        public static TraderAssort GenerateFilteredAssort(string SessionId, string TraderId)
        {
            TraderAssort traderassort = GetAssortByTrader(TraderId);
            TraderAssort output = new();
            output.nextResupply = traderassort.nextResupply;
            if (TraderId == "ragfair")
            {
                output.items = traderassort.items;
                output.barter_scheme = traderassort.barter_scheme;
                output.loyal_level_items = traderassort.loyal_level_items;
            }
            else
            {
                var loyalty = CharacterController.GetLoyality(SessionId, TraderId) + 1;
                foreach (var item in traderassort.items)
                {
                    if (traderassort.loyal_level_items[item.Id] <= loyalty)
                    {
                        output.items.Add(item);
                        if (traderassort.loyal_level_items.TryGetValue(item.Id, out var loyal_id))
                        {
                            output.loyal_level_items[item.Id] = loyal_id;
                        }
                    }
                }
            }
            return output;
        }

        public static bool ItemInPurchaseCategories(string TraderId, Item.Base item)
        {
            var categories = DatabaseController.DataBase.Others.Templates.Categories;
            var items = DatabaseController.DataBase.Others.Templates.Items;

            var traderbase = GetBaseByTrader(TraderId);

            foreach (var purchaseCategorie in traderbase.sell_category)
            {
                var traderCategories = categories.Where(x => x.Id == purchaseCategorie).ToList();

                foreach (var traderCategorie in traderCategories)
                {
                    if (!string.IsNullOrEmpty(traderCategorie.ParentId))
                    {
                        var subCategories = categories.Where(categorie => categorie.ParentId == traderCategorie.Id).ToList();
                        foreach (var subCategorie in subCategories)
                        {
                            // Retrieve the item from the templates database since it contains the parentId (category)
                            var itemData = items.Where(dbItem => dbItem.Id == item.Tpl).ToList()[0];
                            if (itemData != null)
                            {
                                if (subCategorie.Id == itemData.ParentId)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    else
                    {
                        var itemData = items.Where(dbItem => dbItem.Id == item.Tpl).ToList()[0];
                        if (itemData != null)
                        {
                            if (traderCategorie.Id == itemData.ParentId)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }


        public static int GetResupply(string TraderId)
        {
            var currentTime = TimeHelper.UnixTimeNow_Int();
            if (DatabaseController.DataBase.Others.Resupply.TryGetValue(TraderId, out var supplyTime) || supplyTime <= currentTime)
            {
                return supplyTime;
            }
            else
            {
                var time = ConfigController.Configs.Gameplay.Trading.RefreshTimeInMinutes * 60;
                currentTime += time;
                DatabaseController.DataBase.Others.Resupply.Add(TraderId, currentTime);
                return currentTime;
            }
        }

        public static int UpdateResupply(string TraderId)
        {
            var resuptime = GetResupply(TraderId);
            File.WriteAllText("Files/others/resupply.json", JsonConvert.SerializeObject(DatabaseController.DataBase.Others.Resupply));
            return resuptime;
        }

        public static bool CheckResupply(string TraderId)
        {
            var currentTime = TimeHelper.UnixTimeNow_Int();
            if (!DatabaseController.DataBase.Others.Resupply.TryGetValue(TraderId, out var supplyTime))
            {
                return UpdateResupply(TraderId) <= currentTime;
            }
            return supplyTime <= currentTime;
        }




        public static int GetItemLoyalLevelById(string ItemId, TraderAssort traderAssort)
        {
            if (traderAssort.loyal_level_items != null)
            {
                return traderAssort.loyal_level_items[ItemId];
            }
            return 0;
        }

        public static bool IsFence(string TraderId)
        {
            return GetBaseByTrader(TraderId)._id == "579dc571d53a0658a154fbec";
        }

        public static bool IsRagfair(string TraderId)
        {
            return GetBaseByTrader(TraderId)._id == "ragfair";
        }
    }
}
