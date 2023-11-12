using Newtonsoft.Json;
using JsonLib.Classes.Response;
using JsonLib.Classes.Actions;

namespace ServerLib.Controllers
{
    public class MoveActionController
    {
        #region Classes
        public class Id_Count
        {
            public string id;
            public int count;
        }
        public class RepairItem
        {
            [JsonProperty("_id")]
            public string Id;

            [JsonProperty("count")]
            public float Count;
        }
        public class DifferenceHealth
        {
            public readonly Dictionary<int, Part> BodyParts = new(); //EBodyPart
            public float Energy;
            public float Hydration;

            public class Part
            {
                public float Health;
                public List<string> Effects;
            }
        }
        public class BarterJson
        {
            public string _tpl;
            public double count;
            public int level;
            public int side; //EDogtagExchangeSide
            public bool onlyFunctional;
        }
        public class Reward
        {
            public string MessageId;
            public string EventId;
        }
        public class QuestItem
        {
            public string _id;
            public string _tpl;

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string parentId;

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string slotId;

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public object location;

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public object upd;
        }
        public class OwnerInfo
        {
            [JsonProperty("id")]
            public string Id;

            [JsonProperty("type")]
            public int Type; //EOwnerType
        }
        public class UnpackInfo
        {
            [JsonProperty("id")]
            public string Id;
        }
        public class SchemaIdCount : Id_Count
        {
            public int scheme_id;
        }
        public class IdCountItems : Id_Count
        {
            public List<Id_Count> items;

        }
        #endregion

        public static ProfileChanges CreateNew()
        {
            return new()
            { 
            
            
            };    
        }

        public static ProfileChanges MoveItem(string SessionId, ProfileChanges changes)
        {


            return changes;
        }




        /*
        ReadEncyclopedia: string, string[]
        RemoveBuild: string, string
        RestoreHealth: string, string, List<Id_Count>, DifferenceHealth, int
        HideoutQuickTimeEvent: string, List<bool>, string, int
        AddToWishList: string, string
        CustomizationWear: string, string[]
        CustomizationBuy: string, string, List<Id_Count>
        HideoutUpgradeComplete: string, int, int
        TradingConfirm_buy_from_trader: string, string, string, string, int, int, Id_Count[]
        TradingConfirm_sell_to_trader: string, string, string, SchemaIdCount[], int
        HideoutCancelProductionCommand: string, string, int
        HideoutResetProductionsCommand: string, string, int
        Insure: string, string[], string
        HideoutPutItemsInAreaSlots: string, int, Dictionary<int, Id_Count>, int>
        QuestAccept: string, string, string OR string, string
        RepeatableQuestChange: string, string
        QuestComplete: string, string, bool, string OR string, string, bool
        QuestFail: string, string
        QuestHandover: string, string, string, Id_Count[]
        RagFairAddOffer: string, bool, string[], BarterJson[]
        RagFairBuyOffer: string, List<IdCountItems>
        RagFairRemoveOffer: string, string
        RagFairRenewOffer: string, string, bool, int
        RedeemProfileReward: string, Rewards[]
        RemoveFromWishList: string, string
        Repair: string, RepairItem[], string
        TraderRepair: string, string, RepairItem[]
        SaveEquipmentBuild: string, string, string, string, QuestItem[]
        SaveWeaponBuild: string, string, string, string, QuestItem[]
        SellAllFromSavage: string, OwnerInfo, OwnerInfo
        RecordShootingRangePoints: string, int
        HideoutContinuousProductionStart: string, string, int
        HideoutImproveArea: string, string, int, List<Id_Count>, int
        HideoutScavCaseProductionStart: string, string, List<Id_Count>, List<Id_Count>, int
        HideoutSingleProductionStart: string, string, List<Id_Count>, List<Id_Count>, int
        HideoutTakeProduction: string, string, int
        HideoutTakeItemsFromAreaSlots: string, int, int[], int
        HideoutToggleArea: string, int, bool, int
        OpenRandomLootContainer: string, string, UnpackInfo[]
        HideoutUpgrade: string, int, List<Id_Count>, int
         */
    }
}
