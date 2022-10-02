using Newtonsoft.Json;
using ServerLib.Json;
using ServerLib.Web;
using static ServerLib.Json.Database;

namespace ServerLib.Controllers
{
    public class TraderController
    {
        public static List<string> NotSellable = new() { "5449016a4bdc2d6f028b456f", "569668774bdc2da2298b4568", "5696686a4bdc2da3298b456a",
                "602543c13fee350cd564d032", "55d7217a4bdc2d86028b456d", "627a4e6b255f7527fb05a0f6",
                "5811ce772459770e9e5f9532", "5963866b86f7747bfa1c4462", "5963866286f7747bf429b572" , "557ffd194bdc2d28148b457f" };
        public static traders.assort GetAssortByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Traders["assort_" + TraderId].Assort;
        }
        public static Traders.Base GetBaseByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Traders["base_" + TraderId].Base;
        }
        public static List<Traders.Suits> GetSuitsByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Traders["suits_" + TraderId].Suits;
        }
        public static List<string> GetCategoriesByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Traders["categories_" + TraderId].Categories;
        }
        public static List<string> GetTradersKey()
        {
            List<string> output = new();
            foreach (var trader in DatabaseController.DataBase.Traders)
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
            string Currency = GetBaseByTrader(TraderId).Currency;
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

        public static List<string> GetTradersInfo()
        {
            List<string> TraderBase = new List<string>();

            foreach (var trader in DatabaseController.DataBase.Traders)
            {
                if (!trader.Key.ToLower().Contains("ragfair"))
                {
                    TraderBase.Add(JsonConvert.SerializeObject(trader.Value.Base));
                }
            }
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(TraderBase));
            return TraderBase;
        }


        public static traders.assort GenerateAssort(string SessionId,string TraderId)
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


            var loyalty  = CharacterController.GetLoyality(SessionId, TraderId) + 1;
            foreach (var item in traderassort.Items) {
                if (traderassort.LoyalLevelItems[item.Id] <= loyalty)
                {
                    output.Items.Add(item);
                    if (traderassort.BarterScheme[item.Id] != null)
                    {
                        output.BarterScheme[item.Id] = traderassort.BarterScheme[item.Id];
                    }
                    if (traderassort.LoyalLevelItems[item.Id] != null)
                    {
                        output.LoyalLevelItems[item.Id] = traderassort.LoyalLevelItems[item.Id];
                    }
                }
            }
            return output;
        }


        public static string GetPurchasesData(string SessionId, string TraderId)
        {
            Other.TPLCOUNT tplCount = new();
            Dictionary<string, List<List<Other.TPLCOUNT>>> output = new();


            var character = CharacterController.GetCharacter(SessionId); 
            var traderBase = GetBaseByTrader(TraderId);
            var currency = GetCurrency(traderBase.Currency);
            var loyality = CharacterController.GetLoyality(SessionId, TraderId);
            var buyCoef = traderBase.LoyaltyLevels[loyality].BuyPriceCoef / 100;

            foreach (var item in character.Inventory.Items)
            {
                if (!NotSellable.Contains(item.Tpl))
                {

                    var Itemprice = DatabaseController.DataBase.ItemPrices[item.Tpl];
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
                            Itemprice *= (int)(item.Upd.MedKit.HpResource / DatabaseController.DataBase.Items[item.Tpl].Props.MaxHpResource);
                        }
                        if (item.Upd.Repairable != null)
                        {
                            Itemprice *= item.Upd.Repairable.Durability / item.Upd.Repairable.MaxDurability;
                        }
                    }
                    if (currency != "5449016a4bdc2d6f028b456f")
                    {
                        Itemprice = (int)(Itemprice / DatabaseController.DataBase.ItemPrices[currency]);
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

    }
}
