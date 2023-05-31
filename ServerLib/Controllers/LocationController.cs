using ServerLib.Json.Classes;
using Newtonsoft.Json;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class LocationController
    {
        public static Locations.Base GetAllLocation()
        {
            try
            {
                var lbase = JsonConvert.DeserializeObject<Locations.Base>(DatabaseController.DataBase.Location.Base);
                if (lbase == null)
                    Debug.PrintWarn("No Location Base!", "GetAllLocation");

                foreach (var loc in DatabaseController.DataBase.Location.Locations)
                {
                    if (!loc.Key.Contains("_base"))
                        continue;

                    var locbase = JsonConvert.DeserializeObject<Location.Base>(loc.Value);
                    if (locbase == null)
                    {
                        Debug.PrintWarn("No Location Value!", "GetAllLocation");
                    }
                    locbase.Loot = new();
                    lbase.locations.Add(locbase._Id, locbase);
                }
                return lbase;
            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
            }
            return null;


        }
    }
}
