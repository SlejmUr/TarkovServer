using Newtonsoft.Json;
using JsonLib.Classes.Response;
using JsonLib.Classes.Actions;
using JsonLib.Classes.ProfileRelated;
using JsonLib.Classes.ItemRelated;
using ServerLib.Utilities;
using ServerLib.Handlers;
using Newtonsoft.Json.Linq;
using JsonLib.Helpers;
using System;

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
        
        public static Dictionary<string, Func<string,ProfileChanges, JObject, ProfileChanges>> ItemActions = new()
        {
            { "Move", MoveItem },
            { "Fold", FoldItem }
        };

        public static ProfileChanges CreateNew()
        {
            return new()
            {
                profileChanges = new(),
                warnings = new()
            };
        }

        public static ProfileChanges MoveItem(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.Move moveAction = action.ToObject<Inventory.Move>();
            if (changes.warnings.Count > 0)
                return changes;

            var ownerInventoryAction = GetOwnerInventoryAction(SessionId, moveAction);
            if (!ownerInventoryAction.IsSameInventory)
            {
                var itemIdsToMove = InventoryController.GetInventoryItemFamilyTreeIDs(ownerInventoryAction.From, moveAction.item);
                foreach (var itemId in itemIdsToMove)
                {
                    var item = ownerInventoryAction.From.Find(x => x.Id == itemId);
                    if (item == null)
                    {
                        Debug.PrintWarn($"Unable to find item to move: {itemId}");
                        continue;
                    }
                    var FromItemSave = item;
                    if (itemId == moveAction.item)
                    {
                        item.ParentId = moveAction.to.id;
                        item.SlotId = moveAction.to.container;
                        if (moveAction.to.location != null)
                        {
                            JsonLib.Converters.Location location = new();
                            int rot = 0;
                            if (moveAction.to.location.r == "Vertical")
                                rot = 1;
                            location.ItemLocation = new()
                            {
                                IsSearched = moveAction.to.location.isSearched,
                                R = rot,
                                X = moveAction.to.location.x,
                                Y = moveAction.to.location.y
                            };
                            item.Location = location;
                        }
                        else
                        {
                            item.Location = null;
                        }
                        ownerInventoryAction.To.Add(item);
                        ownerInventoryAction.From.Remove(FromItemSave);
                    }

                    CharacterController.TryGetCharacter(ownerInventoryAction.FromId, out var FromChar);
                    FromChar.Inventory.Items = ownerInventoryAction.From;
                    string id = CharacterController.GetCharacterSessionId(FromChar);
                    if (id == string.Empty)
                        Debug.PrintError("From Character Id is not good");
                    if (CharacterController.IsCharacterScav(FromChar))
                        SaveHandler.Save(id, "Scav", SaveHandler.GetScavPath(id), JsonHelper.FromCharacterBase(FromChar));
                    else
                        SaveHandler.SaveCharacter(id, FromChar);
                    CharacterController.TryGetCharacter(ownerInventoryAction.ToId, out var ToChar);
                    ToChar.Inventory.Items = ownerInventoryAction.To;
                    if (CharacterController.IsCharacterScav(ToChar))
                        SaveHandler.Save(SessionId, "Scav", SaveHandler.GetScavPath(SessionId), JsonHelper.FromCharacterBase(ToChar));
                    else
                        SaveHandler.SaveCharacter(SessionId, ToChar);

                }
            }
            else
            {
                var item = ownerInventoryAction.From.Find(x => x.Id == moveAction.item);
                if (item == null)
                {
                    changes = AddWarning(changes, $"Unable to move item: {moveAction.item}, cannot find in inventory");
                    return changes;
                }
                if (item.SlotId.Contains("camore_") && moveAction.to.container == "cartridges")
                    return changes;
                item.ParentId = moveAction.to.id;
                item.SlotId = moveAction.to.container;
                if (moveAction.to.location != null)
                {
                    JsonLib.Converters.Location location = new();
                    int rot = 0;
                    if (moveAction.to.location.r == "Vertical")
                        rot = 1;
                    location.ItemLocation = new()
                    {
                        IsSearched = moveAction.to.location.isSearched,
                        R = rot,
                        X = moveAction.to.location.x,
                        Y = moveAction.to.location.y
                    };
                    item.Location = location;
                }
                else
                {
                    item.Location = null;
                }
                CharacterController.TryGetCharacter(ownerInventoryAction.FromId, out var FromChar);
                FromChar.Inventory.Items = ownerInventoryAction.From;
                if (CharacterController.IsCharacterScav(FromChar))
                    SaveHandler.Save(SessionId, "Scav", SaveHandler.GetScavPath(SessionId), JsonHelper.FromCharacterBase(FromChar));
                else
                    SaveHandler.SaveCharacter(SessionId, FromChar);
            }
            return changes;
        }

        public static ProfileChanges FoldItem(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.Fold foldAction = action.ToObject<Inventory.Fold>();
            bool IsScav = false;
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (foldAction.fromOwner != null && foldAction.fromOwner.type.ToLower() == "profile")
            {
                character = CharacterController.GetScavCharacter(SessionId);
                IsScav = true;
            }
            var item = character.Inventory.Items.Find(x => x.Id == foldAction.item);

            item.Upd.Foldable.Folded = foldAction.value;

            if (!IsScav)
                SaveHandler.SaveCharacter(SessionId, character);
            else
            {
                SaveHandler.Save(SessionId, "Scav", SaveHandler.GetScavPath(SessionId), JsonHelper.FromCharacterBase(character));
            }
            return changes;
        }



        public static ProfileChanges AddWarning(ProfileChanges changes, string message, string Code = "0")
        {
            changes.warnings.Add(new()
            {
                index = 0,
                errmsg = message,
                code = Code
            });
            return changes;
        }

        public class OwnerInventoryAction
        {
            public List<Item.Base> From;
            public string FromId;
            public List<Item.Base> To;
            public string ToId;
            public bool IsSameInventory;
            public bool IsMail;

        }


        public static OwnerInventoryAction GetOwnerInventoryAction(string SessionId, BaseInteraction interaction)
        {
            var pmc = CharacterController.GetPmcCharacter(SessionId);
            var scav = CharacterController.GetScavCharacter(SessionId);
            List<Item.Base> From = pmc.Inventory.Items;
            string FromId = pmc.Id;
            List<Item.Base> To = pmc.Inventory.Items;
            string ToId = pmc.Id;
            string fromType = "pmc";
            string toType = "pmc";
            if (interaction.fromOwner != null)
            {
                if (interaction.fromOwner.id == scav.Id)
                {
                    FromId = scav.Id;
                    From = scav.Inventory.Items;
                    fromType = "scav";
                }
                if (interaction.fromOwner.type.ToLower() == "mail")
                {
                    FromId = "mail";
                    //From = Get item from dialog
                    fromType = "mail";
                }
                if (CharacterController.TryGetCharacter(SessionId, out var charbase))
                {
                    From = charbase.Inventory.Items;
                    FromId = charbase.Id;
                    fromType = "otherCharacter";
                }
            }
            if (interaction.toOwner != null)
            {
                if (interaction.toOwner.id == scav.Id)
                {
                    To = scav.Inventory.Items;
                    ToId = scav.Id;
                    toType = "scav";
                }
            }

            return new()
            { 
                To = To,
                From = From,
                IsSameInventory = (fromType == toType),
                IsMail = (fromType == "mail"),
                ToId = ToId,
                FromId = FromId
            };
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
