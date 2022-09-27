using Newtonsoft.Json;
using ServerLib.Web;

namespace ServerLib.Controllers
{
    public class TraderController
    {
        public static List<string> GetTradersInfo()
        {
            List<string> TraderBase = new List<string>();

            foreach (var trader in DatabaseController.DataBase.Traders)
            {
                if (!trader.Key.ToLower().Contains("ragfair"))
                {
                    TraderBase.Add(trader.Value.Base);
                }
            }
            string resp = ResponseControl.GetBody(JsonConvert.SerializeObject(TraderBase));
            return TraderBase;
        }

    }
}
