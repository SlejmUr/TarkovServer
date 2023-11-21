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
using static ServerLib.Controllers.MoveActionController;

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
            { "Fold", FoldItem },
            { "Remove", RemoveItem },
            { "Split", SplitItem },
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
                            item.Location = new() { ItemLocation = moveAction.to.location.FromActionLocation() };
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
                        SaveHandler.SaveScav(SessionId, FromChar);
                    else
                        SaveHandler.SaveCharacter(id, FromChar);
                    CharacterController.TryGetCharacter(ownerInventoryAction.ToId, out var ToChar);
                    ToChar.Inventory.Items = ownerInventoryAction.To;
                    if (CharacterController.IsCharacterScav(ToChar))
                        SaveHandler.SaveScav(SessionId, ToChar);
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
                    item.Location = new() { ItemLocation = moveAction.to.location.FromActionLocation() };
                }
                else
                {
                    item.Location = null;
                }
                CharacterController.TryGetCharacter(ownerInventoryAction.FromId, out var FromChar);
                FromChar.Inventory.Items = ownerInventoryAction.From;
                if (CharacterController.IsCharacterScav(FromChar))
                    SaveHandler.SaveScav(SessionId, FromChar);
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
                SaveHandler.SaveScav(SessionId, character);
            return changes;
        }

        public static ProfileChanges RemoveItem(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.Remove removeAction = action.ToObject<Inventory.Remove>();
            bool IsScav = false;
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (removeAction.fromOwner != null && removeAction.fromOwner.type.ToLower() == "profile")
            {
                character = CharacterController.GetScavCharacter(SessionId);
                IsScav = true;
            }
            if (changes.profileChanges.TryGetValue(SessionId, out var profileChange))
            {
                if (profileChange.items == null)
                    profileChange.items = new()
                    {
                        del = new()
                    };
                if (profileChange.items.del == null)
                {
                    profileChange.items.del = new()
                    {
                        new()
                        {
                        _id = removeAction.item
                        }
                    };
                }
                else
                {
                    profileChange.items.del.Add(new()
                    {
                        _id = removeAction.item
                    });
                }

            }
            else
            {
                changes.profileChanges.Add(SessionId, new()
                {
                    items = new()
                    { 
                        del = new()
                        { 
                            new()
                            { 
                                _id = removeAction.item
                            }
                        }
                    }
                });
            }

            var toRemoveItems = InventoryController.GetInventoryItemFamilyTreeIDs(character.Inventory.Items, removeAction.item);

            foreach (var item in toRemoveItems)
            {
                int indx = character.Inventory.Items.FindIndex(0, x => x.Id == item);
                if (indx == -1)
                    Debug.PrintWarn($"Unable to remove item with Id: {item} as it was not found in inventory {character.Id}");
                else
                    character.Inventory.Items.RemoveAt(indx);

                indx = character.InsuredItems.FindIndex(0, x=>x.itemId == item);
                if (indx != -1)
                    character.InsuredItems.RemoveAt(indx);
            }

            if (!IsScav)
                SaveHandler.SaveCharacter(SessionId, character);
            else
                SaveHandler.SaveScav(SessionId, character);

            return changes;
        }

        public static ProfileChanges SplitItem(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.Split splitAction = action.ToObject<Inventory.Split>();

            var ownerInventory = GetOwnerInventoryAction(SessionId, splitAction);
            var item = ownerInventory.From.Where(x => x.Id == splitAction.item).FirstOrDefault();
            if (item == null)
            {
                return AddWarning(changes, $"Unable to split stack as source item: {splitAction.item} cannot be found");
            }
            var udp = item.Upd;
            udp.StackObjectsCount = splitAction.count;
            item.Upd.StackObjectsCount -= splitAction.count;
            if (!changes.profileChanges.TryGetValue(SessionId, out var profileChange))
            {
                changes.profileChanges.Add(SessionId, new()
                {
                    items = new()
                    {
                        New = new()
                    }
                });
            }
            else
            {
                if (profileChange.items != null)
                    profileChange.items = new();
                if (profileChange.items.New == null)
                    profileChange.items.New = new();
            }
            changes.profileChanges[SessionId].items.New.Add(new()
            { 
                _id = splitAction.item,
                _tpl = item.Tpl,
                upd = udp
            });
            ownerInventory.To.Add(new()
            { 
                Id = splitAction.item,
                Tpl = item.Tpl,
                Upd = udp,
                Location = new() { ItemLocation = splitAction.container.location.FromActionLocation() },
                ParentId = splitAction.container.id,
                SlotId = splitAction.container.container,
            });

            //Todo: make a save with these

            CharacterController.TryGetCharacter(ownerInventory.FromId, out var FromChar);
            FromChar.Inventory.Items = ownerInventory.From;
            string id = CharacterController.GetCharacterSessionId(FromChar);
            if (id == string.Empty)
                Debug.PrintError("From Character Id is not good");
            if (CharacterController.IsCharacterScav(FromChar))
                SaveHandler.SaveScav(SessionId, FromChar);
            else
                SaveHandler.SaveCharacter(id, FromChar);
            CharacterController.TryGetCharacter(ownerInventory.ToId, out var ToChar);
            ToChar.Inventory.Items = ownerInventory.To;
            if (CharacterController.IsCharacterScav(ToChar))
                SaveHandler.SaveScav(SessionId, ToChar);
            else
                SaveHandler.SaveCharacter(SessionId, ToChar);
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
