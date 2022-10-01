using Newtonsoft.Json;
using ServerLib.Json;
using ServerLib.Web;
using static ServerLib.Json.Database;

namespace ServerLib.Controllers
{
    public class TraderController
    {
        public static traders GetTrader(string TraderId)
        {
            return DatabaseController.DataBase.Traders[TraderId];
        }
        public static traders.assort GetAssortByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Traders[TraderId].Assort;
        }
        public static Traders.Base GetBaseByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Traders[TraderId].Base;
        }
        public static List<Traders.Suits> GetSuitsByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Traders[TraderId].Suits;
        }
        public static List<string> GetCategoriesByTrader(string TraderId)
        {
            return DatabaseController.DataBase.Traders[TraderId].Categories;
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

        public static void Test()
        {
            Other.TPLCOUNT x = new();
            List<Other.TPLCOUNT> tplcount = new();
            List<List<Other.TPLCOUNT>> tpl2 = new();
            Dictionary<string,List<List<Other.TPLCOUNT>>> tpl3 = new();

            for (int i = 0; i < 5;i++)
            {
                x.Tpl = Utilities.Utils.CreateNewID();
                x.Count = Utilities.Utils.GetRandomInt();
                Console.WriteLine(JsonConvert.SerializeObject(x));
                tplcount.Add(x);
                x = new();
            }
            Console.WriteLine(JsonConvert.SerializeObject(tplcount));
            tpl2.Add(tplcount); 
            Console.WriteLine(JsonConvert.SerializeObject(tpl2));
            tpl3.Add(Utilities.Utils.CreateNewID(), tpl2);
            Console.WriteLine(JsonConvert.SerializeObject(tpl3));
        }
    }
}
