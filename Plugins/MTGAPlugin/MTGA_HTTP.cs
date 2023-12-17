using ModdableWebServer.Attributes;
using ModdableWebServer;
using NetCoreServer;
using ServerLib.Utilities.Helpers;
using Newtonsoft.Json;
using static MTGAPlugin.JSON;

namespace MTGAPlugin
{
    internal class MTGA_HTTP
    {
        [HTTP("GET", "/getBrandName")]
        public static bool GetBundeList(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            return ServerHelper.SendUnityResponse(request, serverStruct, JsonConvert.SerializeObject(new ResponseBrandName() { Name = "MTGA-CS" }));
        }

        //  /client/mhafSettings
        //  /multiplayer/server/exists | ServerExistsPacket
        //  /multiplayer/server/create | ServerCreatePacket
        //  /multiplayer/server/getPlayerList | PlayersOnServerList
        //  /multiplayer/server/setSpawn | SpawnPositionPacket
        //  /multiplayer/server/getSpawn/{serverid}  | SpawnPositionPacket
        //  /multiplayer/server/config | MPGameConfig
        //  /multiplayer/server/setWeather | WeatherPacket
        //  /sp/airdrop/config | AirdropConfigModel
        //  /client/location/getAirdropLoot | AirdropLootResultModel
        //  /sp/config/bots/difficulty | DifficultyClass | RequestBotDifficulty
        //  /player/health/sync | 
        //  /raid/profile/save | string

    }
}
