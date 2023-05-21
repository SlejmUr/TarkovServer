using ServerLib.Json.Classes;
using Newtonsoft.Json;

namespace ServerLib.Controllers
{
    public class LocationController
    {
        public static Locations.Base GetAllLocation()
        {
            var lbase = JsonConvert.DeserializeObject<Locations.Base>(DatabaseController.DataBase.Location.Base);

            foreach (var loc in DatabaseController.DataBase.Location.Locations)
            {
                if (!loc.Key.Contains("_base"))
                    continue;

                var locbase = JsonConvert.DeserializeObject<Location.Base>(loc.Value);
                locbase.Loot = new();
                lbase.locations.Add(locbase._Id, locbase);
            }
            return lbase;       
        }
    }
}
