using JsonLib.Classes.BotRelated;
using JsonLib.Classes.DatabaseRelated;
using JsonLib.Classes.ItemRelated;
using JsonLib.Classes.ProfileRelated;
using JsonLib.Helpers;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using static JsonLib.Classes.ProfileRelated.Character;

namespace ServerLib.Generators
{
    public class Bot
    {

        public static Character.Base GeneratePlayerScav(string role, string difficulty, Bots.BotType botBase)
        {
            try
            {
                var chbase = JsonHelper.ToCharacterBaseAsString(DatabaseController.DataBase.Bot.Base);
                ArgumentNullException.ThrowIfNull(chbase);
                chbase.Info.Settings.BotDifficulty = difficulty;
                chbase.Info.Settings.Role = role;
                chbase.Info.Side = "Savage";
                BotGenerationDetails botGeneration = new()
                {
                    IsPmc = false,
                    Side = "Savage",
                    Role = role,
                    PlayerLevel = 0,
                    BotCountToGenerate = 1,
                    BotRelativeLevelDeltaMax = 0,
                    IsPlayerScav = true,
                    BotDifficulty = difficulty
                };
                chbase = GenerateBot(chbase, botBase, botGeneration);
                return chbase;

            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
                throw;
            }

        }


        public static Character.Base GenerateBot(Character.Base bot, Bots.BotType type, BotGenerationDetails botGeneration)
        {
            try
            {
                var name = MathHelper.GetRandomArray(type.firstName) + MathHelper.GetRandomArray(type.lastName);
                int lvl = 0;
                bot.Info.Nickname = name;
                bot.Info.Experience = lvl;
                bot.Info.Level = lvl;
                bot.Info.Settings.Experience = MathHelper.GetRandomDoubleInt(type.experience.reward.Min, type.experience.reward.Max);
                bot.Info.Voice = MathHelper.GetRandomArray(type.appearance.voice);
                bot.Health = GenerateHealth(type.health, botGeneration.IsPlayerScav);
                bot.Skills = GenerateSkills(type.skills);
                bot.Customization.Head = MathHelper.GetRandomArray(type.appearance.head);
                bot.Customization.Body = MathHelper.GetRandomArray(type.appearance.body.Keys.ToList());
                bot.Customization.Feet = MathHelper.GetRandomArray(type.appearance.feet.Keys.ToList());
                bot.Customization.Hands = MathHelper.GetRandomArray(type.appearance.hands);
                bot.Inventory = GenerateInventoryBasic();

                bot = GenerateNewID(bot);

                bot = GenerateInventoryId(bot);

                return bot;

            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
                throw;
            }

        }

        public static Character.Base GenerateNewID(Character.Base bot)
        {
            var ID = AIDHelper.CreateNewID();
            bot.Id = ID;
            bot.Aid = AIDHelper.ToAID(ID);
            return bot;
        }

        public static Skills GenerateSkills(DictSkills botskills)
        {
            return new()
            {
                Common = GenerateSkill(botskills.Common, true),
                Mastering = GenerateSkill(botskills.Mastering, false),
                Points = 0
            };
        }

        public static List<BaseSkill> GenerateSkill(Dictionary<string, BaseSkill> botskills, bool IsCommon)
        {
            if (botskills == null || botskills.Count == 0)
                return new();

            List<BaseSkill> skills = new();

            foreach (var item in botskills.Keys)
            {
                var skill = botskills[item];
                if (skill == null)
                    continue;

                BaseSkill baseSkill = new()
                {
                    Id = item,
                    Progress = MathHelper.GetRandomDoubleInt(skill.min, skill.max)
                };

                if (IsCommon)
                {
                    baseSkill.PointsEarnedDuringSession = 0;
                    baseSkill.LastAccess = 0;
                }
                skills.Add(baseSkill);
            }

            return skills;
        }

        public static Health GenerateHealth(Bots.Health botHealth, bool IsPlayerScav)
        {
            Bots.BodyPart bodyPart = (IsPlayerScav)
            ? botHealth.BodyParts[0]
            : RandomHelper.GetArrayValue(botHealth.BodyParts);

            return new Health()
            {
                UpdateTime = TimeHelper.UnixTimeNow_Int(),
                Energy = new()
                {
                    Current = MathHelper.GetRandomDoubleInt(botHealth.Energy.Min, botHealth.Energy.Max),
                    Maximum = botHealth.Energy.Max
                },
                Hydration = new()
                {
                    Current = MathHelper.GetRandomDoubleInt(botHealth.Hydration.Min, botHealth.Hydration.Max),
                    Maximum = botHealth.Hydration.Max
                },
                Temperature = new()
                {
                    Current = MathHelper.GetRandomDoubleInt(botHealth.Temperature.Min, botHealth.Temperature.Max),
                    Maximum = botHealth.Temperature.Max
                },
                BodyParts = new()
                {
                    Chest = new()
                    {
                        Health = new()
                        {
                            Current = MathHelper.GetRandomDoubleInt(bodyPart.Chest.Min, bodyPart.Chest.Max),
                            Maximum = Math.Round(bodyPart.Chest.Max)
                        }
                    },
                    Stomach = new()
                    {
                        Health = new()
                        {
                            Current = MathHelper.GetRandomDoubleInt(bodyPart.Stomach.Min, bodyPart.Stomach.Max),
                            Maximum = Math.Round(bodyPart.Stomach.Max)
                        }
                    },
                    Head = new()
                    {
                        Health = new()
                        {
                            Current = MathHelper.GetRandomDoubleInt(bodyPart.Head.Min, bodyPart.Head.Max),
                            Maximum = Math.Round(bodyPart.Head.Max)
                        }
                    },
                    LeftArm = new()
                    {
                        Health = new()
                        {
                            Current = MathHelper.GetRandomDoubleInt(bodyPart.LeftArm.Min, bodyPart.LeftArm.Max),
                            Maximum = Math.Round(bodyPart.LeftArm.Max)
                        }
                    },
                    LeftLeg = new()
                    {
                        Health = new()
                        {
                            Current = MathHelper.GetRandomDoubleInt(bodyPart.LeftLeg.Min, bodyPart.LeftLeg.Max),
                            Maximum = Math.Round(bodyPart.LeftLeg.Max)
                        }
                    },
                    RightArm = new()
                    {
                        Health = new()
                        {
                            Current = MathHelper.GetRandomDoubleInt(bodyPart.RightArm.Min, bodyPart.RightArm.Max),
                            Maximum = Math.Round(bodyPart.RightArm.Max)
                        }
                    },
                    RightLeg = new()
                    {
                        Health = new()
                        {
                            Current = MathHelper.GetRandomDoubleInt(bodyPart.RightLeg.Min, bodyPart.RightLeg.Max),
                            Maximum = Math.Round(bodyPart.RightLeg.Max)
                        }
                    }
                }
            };
        }

        public static Base GenerateInventoryId(Base bot)
        {
            try
            {
                Dictionary<string, Item.Base> inventoryItemHash = new();
                Dictionary<string, Item.Base[]> itemsByParentHash = new();
                string InventoryID = "";

                if (bot.Inventory.Items.Count == 0)
                    return bot;

                foreach (var item in bot.Inventory.Items)
                {
                    inventoryItemHash.Add(item.Id, item);

                    if (item.Tpl == "55d7217a4bdc2d86028b456d")
                    {
                        InventoryID = item.Id;
                        continue;
                    }
                    if (string.IsNullOrEmpty(item.ParentId))
                    {
                        continue;
                    }

                    if (!itemsByParentHash.ContainsKey(item.ParentId))
                    {
                        itemsByParentHash.Add(item.ParentId, new Item.Base[] { item });
                        continue;
                    }
                    itemsByParentHash[item.ParentId].Append(item);
                }
                string newID = AIDHelper.CreateNewID();
                if (inventoryItemHash.ContainsKey(InventoryID))
                {
                    inventoryItemHash[InventoryID].Id = newID;
                    bot.Inventory.Equipment = newID;
                }

                if (itemsByParentHash.ContainsKey(InventoryID))
                {
                    foreach (var item in itemsByParentHash[InventoryID])
                    {
                        item.ParentId = newID;
                    }
                }
                return bot;

            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
                throw;
            }

        }

        public static Inventory GenerateInventoryBasic()
        {
            try
            {
                string SortingTable = AIDHelper.CreateNewID();
                string Equipment = AIDHelper.CreateNewID();
                string Stash = AIDHelper.CreateNewID();
                string QuestRaidItems = AIDHelper.CreateNewID();
                string QuestStashItems = AIDHelper.CreateNewID();
                return new()
                { 
                    SortingTable = SortingTable,
                    Equipment = Equipment,
                    Stash = Stash,
                    QuestRaidItems = QuestRaidItems,
                    QuestStashItems = QuestStashItems,
                    FastPanel = new(),
                    Items = new()
                    { 
                        new()
                        { 
                            Id = SortingTable,
                            Tpl = "602543c13fee350cd564d032"
                        },
                        new()
                        {
                            Id = Equipment,
                            Tpl = "55d7217a4bdc2d86028b456d"
                        },
                        new()
                        {
                            Id = Stash,
                            Tpl = "566abbc34bdc2d92178b4576"
                        },
                        new()
                        {
                            Id = QuestRaidItems,
                            Tpl = "5963866286f7747bf429b572"
                        },
                        new()
                        {
                            Id = QuestStashItems,
                            Tpl = "5963866b86f7747bfa1c4462"
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
                throw;
            }
        }

        public static Base GenerateDogtag(Base bot)
        {
            Item.Base item = new();
            item.Id = AIDHelper.CreateNewID();
            item.Tpl = bot.Info.Side == "Usec" ? "59f32c3b86f77472a31742f0" : "59f32bb586f774757e1e8442";
            item.ParentId = bot.Inventory.Equipment;
            item.SlotId = "Dogtag";
            Item._Dogtag dogtag = new();
            dogtag.AccountId = bot.Aid.ToString();
            dogtag.ProfileId = bot.Id;
            dogtag.Nickname = bot.Info.Nickname;
            dogtag.Side = bot.Info.Side;
            dogtag.Level = bot.Info.Level;
            dogtag.Time = TimeHelper.GetTime();
            dogtag.Status = "Killed by ";
            dogtag.KillerAccountId = "Unknown";
            dogtag.KillerProfileId = "Unknown";
            dogtag.KillerName = "Unknown";
            dogtag.WeaponName = "Unknown";
            item.Upd.Dogtag = dogtag;
            bot.Inventory.Items.Add(item);
            return bot;
        }
    }
}
