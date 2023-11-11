using JsonLib.Classes.LocationRelated;
using JsonLib.Classes.Request;
using Newtonsoft.Json;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Controllers
{
    public class LocationController
    {
        public static Locations.Base GetAllLocation()
        {
            var lbase = JsonConvert.DeserializeObject<Locations.Base>(DatabaseController.DataBase.Location.Base);
            if (lbase == null)
            {
                Debug.PrintWarn("lbase == null!!!", "GetAllLocation");
            }
            lbase.locations = new();
            foreach (var loc in DatabaseController.DataBase.Location.Locations)
            {
                if (!loc.Key.Contains("_base"))
                {
                    //Debug.PrintDebug($"Skipping: {loc.Key}");
                    continue;
                }
                    

                var locbase = JsonConvert.DeserializeObject<Location.Base>(loc.Value);
                if (locbase == null)
                {
                    Debug.PrintWarn("No Location Value!", "GetAllLocation");
                    continue;
                }
                locbase.UnixDateTime = TimeHelper.UnixTimeNow_Int();
                locbase.Loot = new();
                lbase.locations.Add(locbase._Id, locbase);
            }
            return lbase;
        }

        public static Location.Base GetLocationLoot(GetLocation location)
        {
            Debug.PrintInfo($"Generating loot for location {location.locationId}", "GetLocationLoot");
            var LocationBase = JsonConvert.DeserializeObject<Location.Base>(DatabaseController.DataBase.Location.Locations[location.locationId + "_base"]);
            ArgumentNullException.ThrowIfNull(LocationBase);
            //var LocationLoot = JsonConvert.DeserializeObject<LooseLoot.Base>(DatabaseController.DataBase.Location.Locations[location.locationId + "_looseLoot"]);
            LocationBase.UnixDateTime = TimeHelper.UnixTimeNow_Int();

            var staticWeapons = DatabaseController.DataBase.Loot.staticContainers[location.locationId].staticWeapons;
            foreach (var item in staticWeapons)
            {
                LocationBase.Loot.Add(item);
            }
            return LocationBase;
        }
    }
}
