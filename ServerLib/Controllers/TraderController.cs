using EFT.UI.Ragfair;
using Newtonsoft.Json;
using ServerLib.Json;
using ServerLib.Utilities;
using static ServerLib.Json.Database.trader;
using static ServerLib.Json.Traders;

namespace ServerLib.Controllers
{
    public class TraderController
    {
        public static List<string> NotSellable = new() { "5449016a4bdc2d6f028b456f", "569668774bdc2da2298b4568", "5696686a4bdc2da3298b456a",
                "602543c13fee350cd564d032", "55d7217a4bdc2d86028b456d", "627a4e6b255f7527fb05a0f6",
                "5811ce772459770e9e5f9532", "5963866b86f7747bfa1c4462", "5963866286f7747bf429b572" , "557ffd194bdc2d28148b457f" };
        public static traders.assort GetAssortByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Trader.Traders["assort_" + TraderId].Assort;
        }
        public static Traders.Base GetBaseByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Trader.Traders["base_" + TraderId].Base;
        }
        public static List<TraderSuits> GetSuitsByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Trader.Traders["suits_" + TraderId].Suits;
        }
        public static List<string> GetCategoriesByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Trader.Traders["categories_" + TraderId].Categories;
        }
        public static void SetAssortByTrader(string TraderId, traders.assort assort)
        {
            DatabaseController.DataBase.Trader.Traders["assort_" + TraderId].Assort = assort;
        }
        public static Character.Item? GetAssortItemByID(string TraderId, string ItemId)
        {
            return GetAssortByTrader(TraderId).Items.Find(item => item.Id == ItemId);
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
            return GetCurrency(GetBaseByTrader(TraderId).Currency);
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
                { "5c0647fdd443bc2504c2d371","Jaeger" }

            };
            return names[TraderId];
        }
        public static List<Base> GetTradersInfo()
        {
            List<Base> TraderBase = new List<Base>();

            foreach (var trader in DatabaseController.DataBase.Trader.Traders)
            {
                if (!trader.Key.ToLower().Contains("ragfair"))
                {
                    if (trader.Value.Base.Avatar.Contains("jpg"))
                    {
                        trader.Value.Base.Avatar.Replace("jpg", "png");
                    }
                    TraderBase.Add(trader.Value.Base);
                }
            }
            return TraderBase;
        }

        public static traders.assort GenerateAssort(string TraderId, int currentTime)
        {
            traders.assort traderassort = GetAssortByTrader(TraderId);
            traders.assort output = traderassort;
            if (traderassort.NextResupply <= currentTime)
            {
                var refl = ConfigController.Configs.Gameplay.Trading.RefreshTimeInMinutes;
                output.NextResupply = currentTime + refl * 60;
                SetAssortByTrader(TraderId, output);
            }
            return output;
        }

        public static void RemoveItemFromAssortAfterBuy(string TraderId, Json.Other.ItemMove item)
        {
            var assort = GetAssortByTrader(TraderId);
            var foundItem = GetAssortItemByID(TraderId, item.ItemId);
            if (foundItem != null)
            {
                if (foundItem.Upd.BuyRestrictionMax != null)
                {
                    foundItem.Upd.BuyRestrictionCurrent += item.Count;
                }
                if (foundItem.Upd.StackObjectsCount - item.Count > 0)
                {
                    foundItem.Upd.StackObjectsCount -= item.Count;
                }
                else
                {
                    assort.Items.Remove(foundItem);
                    SetAssortByTrader(TraderId, assort);
                }
            }
        }

        public static traders.assort GenerateFilteredAssort(string SessionId, string TraderId)
        {
            traders.assort traderassort = GetAssortByTrader(TraderId);
            traders.assort output = new();
            output.NextResupply = traderassort.NextResupply;
            if (TraderId == "ragfair")
            {
                output.Items = traderassort.Items;
                output.BarterScheme = traderassort.BarterScheme;
                output.LoyalLevelItems = traderassort.LoyalLevelItems;
            }
            else
            {
                var loyalty = CharacterController.GetLoyality(SessionId, TraderId) + 1;
                foreach (var item in traderassort.Items)
                {
                    if (traderassort.LoyalLevelItems[item.Id] <= loyalty)
                    {
                        output.Items.ToList().Add(item);
                        if (traderassort.BarterScheme.TryGetValue(item.Id, out var barter_id))
                        {
                            output.BarterScheme[item.Id] = barter_id;
                        }
                        if (traderassort.LoyalLevelItems.TryGetValue(item.Id, out var loyal_id))
                        {
                            output.LoyalLevelItems[item.Id] = loyal_id;
                        }
                    }
                }
            }
            return output;
        }

        public static string GetPurchasesData(string SessionId, string TraderId)
        {
            Json.Other.TPLCOUNT tplCount = new();
            Dictionary<string, List<List<Json.Other.TPLCOUNT>>> output = new();


            var character = CharacterController.GetCharacter(SessionId);
            var traderBase = GetBaseByTrader(TraderId);
            var currency = GetCurrency(traderBase.Currency);
            var loyality = CharacterController.GetLoyality(SessionId, TraderId);
            var buyCoef = traderBase.LoyaltyLevels[loyality].BuyPriceCoef / 100;

            foreach (var item in character.Inventory.Items)
            {
                if (!NotSellable.Contains(item.Tpl))
                {

                    var Itemprice = DatabaseController.DataBase.Others.ItemPrices[item.Tpl];
                    var itemStackCount = 1;
                    if (item.Upd != null && item.Upd.StackObjectsCount != null)
                    {
                        itemStackCount = (int)item.Upd.StackObjectsCount;
                    }
                    Itemprice = Itemprice - Itemprice * buyCoef * itemStackCount;

                    if (item.Upd != null)
                    {
                        if (item.Upd.MedKit != null && item.Upd.MedKit.HpResource > 0)
                        {
                            Itemprice *= (int)(item.Upd.MedKit.HpResource / DatabaseController.DataBase.Others.Items[item.Tpl].Props.MaxHpResource);
                        }
                        if (item.Upd.Repairable != null)
                        {
                            Itemprice *= item.Upd.Repairable.Durability / item.Upd.Repairable.MaxDurability;
                        }
                    }
                    if (currency != "5449016a4bdc2d6f028b456f")
                    {
                        Itemprice = (int)(Itemprice / DatabaseController.DataBase.Others.ItemPrices[currency]);
                    }


                    if (traderBase.Discount > 0)
                    {
                        Itemprice -= (traderBase.Discount / 100) * Itemprice;
                    }

                    tplCount.Tpl = currency;
                    tplCount.Count = Itemprice;
                    output.Add(item.Id, new() { new() { tplCount } });
                    tplCount = new();
                }
            }
            return JsonConvert.SerializeObject(output);
        }

        public static bool ItemInPurchaseCategories(string TraderId, Character.Item item)
        {
            var categories = DatabaseController.DataBase.Templates.Categories;
            var items = DatabaseController.DataBase.Templates.Items;

            var traderbase = GetBaseByTrader(TraderId);

            foreach (var purchaseCategorie in traderbase.SellCategory)
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

        public static List<RagfairOffer> GetRagfairOffers(string TraderId)
        {
            List<RagfairOffer> convertedOffers = new();
            var offerIntID = 1;
            var assort = GetAssortByTrader(TraderId);
            foreach (var item in assort.Items)
            {
                if (item.SlotId == "hideout")
                {
                    Offer.Merchant merchant = new()
                    {
                        Id = TraderId,
                        MemberType = EMemberCategory.Trader
                    };
                    RagfairOffer offer = new();
                    if (DatabaseController.DataBase.Others.ChildlessList.Contains(item.Id))
                    {
                        offer.Item = item;
                    }
                    var itembarter = assort.BarterScheme[item.Id][0];
                    offer.Id = Utils.CreateNewID();
                    offer.IntId = offerIntID;
                    offer.ItemsCost = (int)itembarter[0].Count;
                    offer.RequirementsCost = (int)itembarter[0].Count;
                    offer.SummaryCost = (int)itembarter[0].Count;
                    offer.User = merchant;
                    offer.SellInOnePiece = false;
                    offer.Locked = false;
                    offer.Requirements = itembarter;
                    offer.LoyaltyLevel = (int)assort.LoyalLevelItems[item.Id];
                    offer.StartTime = DateTime.MinValue;
                    offer.EndTime = DateTime.MaxValue;
                    offer.UnlimitedCount = item.Upd.UnlimitedCount;

                    if (item.Upd.BuyRestrictionMax != null)
                    {
                        offer.BuyRestrictionMax = (int)item.Upd.BuyRestrictionMax;
                        offer.BuyRestrictionCurrent = (int)item.Upd.BuyRestrictionCurrent;
                    }
                    else
                    {

                    }
                    convertedOffers.Add(offer);
                    offerIntID++;
                }
            }
            return convertedOffers;
        }

        public static int GetResupply(string TraderId)
        {
            var currentTime = Time.UnixTimeNow_Int();
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
            var currentTime = Time.UnixTimeNow_Int();
            if (!DatabaseController.DataBase.Others.Resupply.TryGetValue(TraderId, out var supplyTime))
            {
                return UpdateResupply(TraderId) <= currentTime;
            }
            return supplyTime <= currentTime;
        }

        public static Traders.Customization? GetCustomizationByTraderOfferId(string offerId)
        {
            foreach (var trader in GetTradersKey())
            {
                foreach (var suits in GetSuitsByTrader(trader))
                {
                    if (suits._id == offerId)
                    {
                        var item = CustomizationController.GetCustomization(suits.suiteId);
                        return new()
                        {
                            TraderID = trader,
                            Suite = item
                        };
                    }
                }
            }
            return null;
        }

        public static List<Barter>? GetBarterSchemeById(string ItemId, traders.assort traderAssort)
        {
            if (traderAssort.BarterScheme != null)
            {
                return traderAssort.BarterScheme[ItemId][0];
            }
            return null;
        }

        public static long GetItemLoyalLevelById(string ItemId, traders.assort traderAssort)
        {
            if (traderAssort.LoyalLevelItems != null)
            {
                return traderAssort.LoyalLevelItems[ItemId];
            }
            return 0;
        }

        public static bool IsFence(string TraderId)
        {
            return GetBaseByTrader(TraderId).Id == "579dc571d53a0658a154fbec";
        }

        public static bool IsRagfair(string TraderId)
        {
            return GetBaseByTrader(TraderId).Id == "ragfair";
        }
    }
}
