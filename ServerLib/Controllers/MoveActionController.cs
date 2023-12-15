using Newtonsoft.Json;
using JsonLib.Classes.Response;
using JsonLib.Classes.Actions;
using JsonLib.Classes.ProfileRelated;
using JsonLib.Classes.ItemRelated;
using ServerLib.Utilities;
using ServerLib.Handlers;
using Newtonsoft.Json.Linq;
using JsonLib.Helpers;

namespace ServerLib.Controllers
{
    public class MoveActionController
    {
        
        public static Dictionary<string, Func<string,ProfileChanges, JObject, ProfileChanges>> ItemActions = new()
        {
            { "Move", MoveItem },
            { "Fold", FoldItem },
            { "Remove", RemoveItem },
            { "Split", SplitItem },
            { "Examine", ExamineItem },
            { "Swap",  SwapItem },
            { "Transfer", TransferItem },
            { "ReadEncyclopedia", ReadEncyclopedia },
            { "Bind", BindItem },
            { "Tag", TagItem },
            { "Toggle", ToggleItem },
            { "ApplyInventoryChanges", ApplyInventory },
            { "template", Template },
        };

        public static ProfileChanges CreateNew()
        {
            return new()
            {
                profileChanges = new(),
                warnings = new()
            };
        }

        public static ProfileChanges Template(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.Examine examineAction = action.ToObject<Inventory.Examine>();
            bool IsScav = false;
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (examineAction.fromOwner != null && examineAction.fromOwner.type.ToLower() == "profile")
            {
                character = CharacterController.GetScavCharacter(SessionId);
                IsScav = true;
            }


            if (!IsScav)
                SaveHandler.SaveCharacter(SessionId, character);
            else
                SaveHandler.SaveScav(SessionId, character);
            return changes;
        }

        public static ProfileChanges CreateBasicChanges(ProfileChanges changes, string SessionId)
        {
            changes.profileChanges.Add(SessionId, new()
            { 
                _id = SessionId,
                skills = new(),
                builds = new(),
                health = new(),
                questsStatus = new(),
                improvements = new(),
                items = new()
                { 
                    change = new(),
                    del = new(),
                    New = new()
                },
                production = new(),
                quests = new(),
                ragFairOffers = new(),
                recipeUnlocked = new(),
                repeatableQuests =  new(),
                traderRelations = new()
            });
            return changes;
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

        public static ProfileChanges ExamineItem(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.Examine examineAction = action.ToObject<Inventory.Examine>();
            bool IsScav = false;
            TemplateItem.Base templateItem = null;
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (examineAction.fromOwner != null && examineAction.fromOwner.type.ToLower() == "profile")
            {
                character = CharacterController.GetScavCharacter(SessionId);
                IsScav = true;
            }
            else if (examineAction.fromOwner != null && examineAction.fromOwner.type.ToLower() != "profile")
            {
                switch (examineAction.fromOwner.type.ToLower())
                {
                    case "trader":
                        var assortItem = TraderController.GetAssortItemByID(examineAction.fromOwner.id, examineAction.item);
                        templateItem = ItemController.Get(assortItem.Tpl);
                        break;
                    case "hideoutupgrade":
                    case "hideoutproduction":
                    case "scavcase":
                        // the item is a TPL
                        templateItem = ItemController.Get(examineAction.item);
                        break;
                    default:
                        Debug.PrintWarn($"FromOwner.Type is currently not supported. ({examineAction.fromOwner.type.ToLower()})", "ExamineItem.WARN");
                        return changes;
                }

            }
            var item = character.Inventory.Items.Find(x => x.Id == examineAction.item);
            if (item != null && templateItem == null)
            {
                templateItem = ItemController.Get(item.Tpl);
            }

            character.Encyclopedia.Add(templateItem._id,true);
            character.Info.Experience += (int)templateItem._props.ExamineExperience;

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
                profileChange.items.del.Add(new()
                {
                    _id = removeAction.item
                });
            }
            else
            {
                Debug.PrintWarn("ProfileChanges not exist?", "RemoveItem.WARN");
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
            if (changes.profileChanges.TryGetValue(SessionId, out var profileChange))
            {
                profileChange.items.New.Add(new()
                {
                    _id = splitAction.item,
                    _tpl = item.Tpl,
                    upd = udp
                });
            }
            else
            {
                Debug.PrintWarn("ProfileChanges not exist?", "SplitItem.WARN");
            }

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
            OwnerActionSaveProfiles(SessionId, ownerInventory);
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

        public static ProfileChanges SwapItem(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.Swap swapAction = action.ToObject<Inventory.Swap>();
            bool IsScav = false;
            TemplateItem.Base templateItem = null;
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (swapAction.fromOwner != null && swapAction.fromOwner.type.ToLower() == "profile")
            {
                character = CharacterController.GetScavCharacter(SessionId);
                IsScav = true;
            }

            var swapItem = character.Inventory.Items.Find(x=>x.Id == swapAction.item);
            var swapItem2 = character.Inventory.Items.Find(x => x.Id == swapAction.item2);

            if (swapAction.to.location != null)
            {
                swapItem.Location = JsonHelper.FromActionLocation(swapAction.to.location);
            }
            else
            {
                swapItem.Location = null;
            }
            swapItem.ParentId = swapAction.to.id;
            swapItem.SlotId = swapAction.to.container;

            if (swapAction.to2.location != null)
            {
                swapItem2.Location = JsonHelper.FromActionLocation(swapAction.to2.location);
            }
            else
            {
                swapItem2.Location = null;
            }
            swapItem2.ParentId = swapAction.to2.id;
            swapItem2.SlotId = swapAction.to2.container;


            if (!IsScav)
                SaveHandler.SaveCharacter(SessionId, character);
            else
                SaveHandler.SaveScav(SessionId, character);
            return changes;
        }

        public static ProfileChanges TransferItem(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.Transfer transferAction = action.ToObject<Inventory.Transfer>();
            bool IsScav = false;
            TemplateItem.Base templateItem = null;
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (transferAction.fromOwner != null && transferAction.fromOwner.type.ToLower() == "profile")
            {
                character = CharacterController.GetScavCharacter(SessionId);
                IsScav = true;
            }

            var toMerge = character.Inventory.Items.Find(x=>x.Id == transferAction.item);
            var mergeWith = character.Inventory.Items.Find(x => x.Id == transferAction.with);

            toMerge.Upd.StackObjectsCount -= transferAction.count;
            mergeWith.Upd.StackObjectsCount += transferAction.count;


            if (!IsScav)
                SaveHandler.SaveCharacter(SessionId, character);
            else
                SaveHandler.SaveScav(SessionId, character);
            return changes;
        }

        public static ProfileChanges ReadEncyclopedia(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.ReadEncyclopedia readEncyclopedia = action.ToObject<Inventory.ReadEncyclopedia>();
            bool IsScav = false;
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (readEncyclopedia.fromOwner != null && readEncyclopedia.fromOwner.type.ToLower() == "profile")
            {
                character = CharacterController.GetScavCharacter(SessionId);
                IsScav = true;
            }

            foreach (var item in readEncyclopedia.ids)
            {
                character.Encyclopedia.Add(item, true);
            }

            if (!IsScav)
                SaveHandler.SaveCharacter(SessionId, character);
            else
                SaveHandler.SaveScav(SessionId, character);
            return changes;
        }

        public static ProfileChanges BindItem(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.Bind bindAction = action.ToObject<Inventory.Bind>();
            bool IsScav = false;
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (bindAction.fromOwner != null && bindAction.fromOwner.type.ToLower() == "profile")
            {
                character = CharacterController.GetScavCharacter(SessionId);
                IsScav = true;
            }

            if (character.Inventory.FastPanel.ContainsKey(bindAction.index))
            {
                character.Inventory.FastPanel[bindAction.index] = bindAction.item;
            }
            else
            {
                character.Inventory.FastPanel.Add(bindAction.index, bindAction.item);
            }


            if (!IsScav)
                SaveHandler.SaveCharacter(SessionId, character);
            else
                SaveHandler.SaveScav(SessionId, character);
            return changes;
        }

        public static ProfileChanges TagItem(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.Tag tagAction = action.ToObject<Inventory.Tag>();
            bool IsScav = false;
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (tagAction.fromOwner != null && tagAction.fromOwner.type.ToLower() == "profile")
            {
                character = CharacterController.GetScavCharacter(SessionId);
                IsScav = true;
            }

            var item = character.Inventory.Items.Find(x=>x.Id == tagAction.item);

            if (item.Upd == null)
            {
                item.Upd = new()
                {
                    Tag = new()
                    {
                        Color = tagAction.TagColor,
                        Name = tagAction.TagName
                    }
                };
            }
            else if (item.Upd != null && item.Upd.Tag == null)
            {
                item.Upd.Tag = new()
                {
                    Color = tagAction.TagColor,
                    Name = tagAction.TagName
                };
            }
            else
            {
                item.Upd.Tag.Color = tagAction.TagColor;
                item.Upd.Tag.Name = tagAction.TagName;
            }

            if (!IsScav)
                SaveHandler.SaveCharacter(SessionId, character);
            else
                SaveHandler.SaveScav(SessionId, character);
            return changes;
        }

        public static ProfileChanges ToggleItem(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.Toggle toggleAction = action.ToObject<Inventory.Toggle>();
            bool IsScav = false;
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (toggleAction.fromOwner != null && toggleAction.fromOwner.type.ToLower() == "profile")
            {
                character = CharacterController.GetScavCharacter(SessionId);
                IsScav = true;
            }

            var item = character.Inventory.Items.Find(x => x.Id == toggleAction.item);

            if (item.Upd == null)
            {
                item.Upd = new()
                {
                    Togglable = new()
                    {
                        On = toggleAction.value
                    }
                };
            }
            else if (item.Upd != null && item.Upd.Togglable == null)
            {
                item.Upd.Togglable = new()
                {
                    On = toggleAction.value
                };
            }
            else
            {
                item.Upd.Togglable.On = toggleAction.value;
            }

            if (!IsScav)
                SaveHandler.SaveCharacter(SessionId, character);
            else
                SaveHandler.SaveScav(SessionId, character);
            return changes;
        }

        public static ProfileChanges ApplyInventory(string SessionId, ProfileChanges changes, JObject action)
        {
            Inventory.ApplyInventoryChanges inventoryChanges = action.ToObject<Inventory.ApplyInventoryChanges>();
            bool IsScav = false;
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (inventoryChanges.fromOwner != null && inventoryChanges.fromOwner.type.ToLower() == "profile")
            {
                character = CharacterController.GetScavCharacter(SessionId);
                IsScav = true;
            }

            foreach (var item in inventoryChanges.changedItems)
            {
                var invItem = character.Inventory.Items.Find(x=>x.Id == item.Id);
                invItem.ParentId = item.ParentId;
                invItem.SlotId = item.SlotId;
                invItem.Location = item.Location;
            }

            if (!IsScav)
                SaveHandler.SaveCharacter(SessionId, character);
            else
                SaveHandler.SaveScav(SessionId, character);
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

        public static void OwnerActionSaveProfiles(string SessionId, OwnerInventoryAction ownerInventoryAction)
        {
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
