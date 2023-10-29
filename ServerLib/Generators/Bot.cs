using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using static ServerLib.Json.Classes.Character;

namespace ServerLib.Generators
{
    internal class Bot
    {
        public class BotGenerationDetails
        {
            public bool IsPmc;
            public string Role;
            public string Side;
            public int PlayerLevel;
            public int BotRelativeLevelDeltaMax;
            public int BotCountToGenerate;
            public string BotDifficulty;
            public bool IsPlayerScav;
        }


        public static Base GeneratePlayerScav(string SessionId, string role, string difficulty, Bots.BotType botBase)
        {
            try
            {
                var chbase = JsonConvert.DeserializeObject<Base>(DatabaseController.DataBase.Bot.Base);
                chbase.Info.Settings.BotDifficulty = difficulty;
                chbase.Info.Settings.Role = role;
                chbase.Info.Side = "Savage";
                BotGenerationDetails botGeneration = new BotGenerationDetails()
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
                chbase = GenerateBot(SessionId, chbase, botBase, botGeneration);
                return chbase;

            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
                return null;
            }

        }


        public static Base GenerateBot(string SessionId, Base bot, Bots.BotType type, BotGenerationDetails botGeneration)
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
                bot.Inventory = JsonConvert.DeserializeObject<Inventory>(File.ReadAllText("Files/bot/basic_inventory.json"));

                bot = GenerateNewID(bot);

                bot = GenerateInventoryId(bot);

                return bot;

            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
                return null;
            }

        }

        public static Base GenerateNewID(Base bot)
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

                if (bot.Inventory.Items == null)
                    return bot;

                foreach (var item in bot.Inventory.Items)
                {
                    inventoryItemHash.Add(item.Id, item);

                    if (item.Tpl == "55d7217a4bdc2d86028b456d")
                    {
                        InventoryID = item.Id;
                        continue;
                    }
                    if (!string.IsNullOrEmpty(item.ParentId))
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
                inventoryItemHash[InventoryID].Id = newID;
                bot.Inventory.Equipment = newID;


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
                return null;
            }

        }
    }
}
