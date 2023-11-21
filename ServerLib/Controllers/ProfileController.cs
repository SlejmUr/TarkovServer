﻿using JsonLib;
using JsonLib.Classes.ProfileRelated;
using JsonLib.Helpers;
using Newtonsoft.Json;
using ServerLib.Handlers;
using ServerLib.Utilities;
using static JsonLib.Classes.Configurations.CustomConfig;

namespace ServerLib.Controllers
{
    public class ProfileController
    {
        static ProfileController()
        {
            Profiles = new();
            Profiles.Clear();
            ProfilesDict = new();
            ProfilesDict.Clear();
        }

        public static List<Profile.Base> Profiles;
        public static Dictionary<string, Profile.Base> ProfilesDict;
        public static List<string> AlreadyConverted;
        public static void Init()
        {
            if (File.Exists("user/converteds.txt"))
            {
                AlreadyConverted = File.ReadAllLines("user/converteds.txt").ToList();
            }
            else
            {
                AlreadyConverted = new();
            }
            ConvertAllProfile();
            ReloadProfiles();
            Debug.PrintInfo("Initialization Done!", "Profile");
        }

        public static void ReloadProfiles()
        {
            Profiles.AddRange(ConvertFromProfile());
        }

        public static void ConvertAllProfile()
        {
            //Profiles.AddRange(ConvertFromJET());
            Profiles.AddRange(ConvertFromAkiProfile());
            SaveAsProfile();
            File.WriteAllLines("user/converteds.txt", AlreadyConverted);
            ProfilesDict.Clear();
            Profiles.Clear();
        }

        /// <summary>
        /// Convert Our version of profile
        /// </summary>
        public static List<Profile.Base> ConvertFromProfile()
        {
            /*
             So we doing the funny!
             we split the profile json into multiple smaller ones. Like Ori MTGA/JET/AE
             account => Profile.Info
             character => Profile.characters.pmc | Backward compatibility to MTGA
             storage => Profile.suits
             dialog => Profile.dialogs
             
             new ones:
             scav => Profile.characters.scav
             others => not inside anywhere else
             */

            List<Profile.Base> ret = new();
            string[] dirs = Directory.GetDirectories("user/profiles");
            foreach (string dir in dirs)
            {
                Profile.Base @base = new()
                {
                    Characters = new()
                };
                if (File.Exists($"{dir}/profile.json"))
                {
                    var pbase = JsonConvert.DeserializeObject<Profile.Base>(File.ReadAllText($"{dir}/profile.json"));
                    ArgumentNullException.ThrowIfNull(pbase);
                    @base = pbase;
                }
                if (File.Exists($"{dir}/others.json"))
                {
                    var others = JsonConvert.DeserializeObject<ProfileAddon>(File.ReadAllText($"{dir}/others.json"));
                    ArgumentNullException.ThrowIfNull(others);
                    @base.ProfileAddon = others;
                }
                if (File.Exists($"{dir}/account.json"))
                {
                    var account = JsonConvert.DeserializeObject<Profile.Info>(File.ReadAllText($"{dir}/account.json"));
                    ArgumentNullException.ThrowIfNull(account);
                    @base.Info = account;
                }
                if (File.Exists($"{dir}/character.json"))
                {
                    var character = JsonHelper.ToCharacterBase($"{dir}/character.json");
                    ArgumentNullException.ThrowIfNull(character);
                    @base.Characters.Pmc = character;
                }
                if (File.Exists($"{dir}/scav.json"))
                {
                    var scav = JsonHelper.ToCharacterBase($"{dir}/scav.json");
                    ArgumentNullException.ThrowIfNull(scav);
                    @base.Characters.Scav = scav;
                }
                if (File.Exists($"{dir}/storage.json"))
                {
                    var storage = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText($"{dir}/storage.json"));
                    ArgumentNullException.ThrowIfNull(storage);
                    @base.Suits = storage;
                }
                if (File.Exists($"{dir}/dialog.json"))
                {
                    var dialog = JsonConvert.DeserializeObject<Dictionary<string, Profile.Dialogue>>(File.ReadAllText($"{dir}/dialog.json"));
                    ArgumentNullException.ThrowIfNull(dialog);
                    @base.Dialogues = dialog;
                }
                if (string.IsNullOrEmpty(@base.Info.Id))    //this means we have no accountId that we could use.
                    continue;
                if (!ProfilesDict.ContainsKey(@base.Info.Id))
                {
                    Debug.PrintDebug($"Profile Added {@base.Info.Id}", "ConvertFromProfile");
                    ProfilesDict.Add(@base.Info.Id, @base);
                }
                ret.Add(@base);
            }

            return ret;
        }


        /// <summary>
        /// Convert AKI version of profile
        /// </summary>
        public static List<Profile.Base> ConvertFromAkiProfile()
        {
            List<Profile.Base> ret = new();
            string[] dirs = Directory.GetFiles("user/profiles", "*.json", SearchOption.TopDirectoryOnly);
            foreach (string dir in dirs)
            {
                var account = JsonConvert.DeserializeObject<Profile.Base>(File.ReadAllText(dir), new JsonConverter[] { Converters.ItemLocationConverter.Singleton });
                ArgumentNullException.ThrowIfNull(account);
                ret.Add(account);
                if (!ProfilesDict.ContainsKey(account.Info.Id))
                {
                    Debug.PrintDebug($"Profile Added {account.Info.Id}", "ConvertFromAkiProfile");
                    ProfilesDict.Add(account.Info.Id, account);
                }
            }
            return ret;
        }

        /// <summary>
        /// Convert JET type of versions of profile
        /// </summary>
        [Obsolete("JET profiles are no longer exist. Might need to edit to make it to ConvertFromMTGA")]
        public static List<Profile.Base> ConvertFromJET()
        {
            List<Profile.Base> ret = new();
            string[] dirs = Directory.GetDirectories("user/profiles");
            foreach (string dir in dirs)
            {
                if (File.Exists($"{dir}/others.json"))
                {
                    continue;
                }
                Profile.Base @base = new();
                if (File.Exists($"{dir}/account.json"))
                {
                    var account = JsonConvert.DeserializeObject<Profile.Info>(File.ReadAllText($"{dir}/account.json"));
                    ArgumentNullException.ThrowIfNull(account);
                    if (account.Edition == null | string.IsNullOrEmpty(account.Edition))
                        continue;
                    @base.Info = account;
                }
                if (File.Exists($"{dir}/character.json"))
                {
                    var character = JsonHelper.ToCharacterBase($"{dir}/character.json");
                    @base.Characters = new()
                    {
                        Scav = character,
                        Pmc = character
                    };
                }
                if (File.Exists($"{dir}/storage.json"))
                {
                    var storage = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText($"{dir}/storage.json"));
                    ArgumentNullException.ThrowIfNull(storage);
                    @base.Suits = storage;
                }
                if (File.Exists($"{dir}/dialog.json"))
                {
                    var dialog = JsonConvert.DeserializeObject<Dictionary<string, Profile.Dialogue>>(File.ReadAllText($"{dir}/dialog.json"));
                    ArgumentNullException.ThrowIfNull(dialog);
                    @base.Dialogues = dialog;
                }
                if (!ProfilesDict.ContainsKey(@base.Info.Id))
                {
                    Debug.PrintDebug($"Profile Added {@base.Info.Id}", "ConvertFromJET");
                    ProfilesDict.Add(@base.Info.Id, @base);
                }
                ret.Add(@base);
            }
            return ret;
        }


        public static Profile.Base? GetProfile(string SessionId)
        {
            ReloadProfiles();
            if (ProfilesDict.TryGetValue(SessionId, out Profile.Base? ret))
            {
                return ret;
            }
            return null;
        }

        public static bool TryGetProfile(string SessionId, out Profile.Base? profile)
        {
            profile = null;
            ReloadProfiles();
            return ProfilesDict.TryGetValue(SessionId, out profile);
        }


        /// <summary>
        /// Save Profiles as JET tpye of Profile
        /// </summary>
        [Obsolete("JET profiles are no longer exist. Might need to edit to make it to SaveAsMTGA")]
        public static void SaveAsJET()
        {
            foreach (var dict in ProfilesDict)
            {
                var Id = dict.Key;
                SaveHandler.Save(Id, "Account", SaveHandler.GetAccountPath(Id), JsonConvert.SerializeObject(dict.Value.Info));
                SaveHandler.Save(Id, "Character", SaveHandler.GetCharacterPath(Id), JsonHelper.FromCharacterBase(dict.Value.Characters.Pmc));
                SaveHandler.Save(Id, "Dialog", SaveHandler.GetDialogPath(Id), JsonConvert.SerializeObject(dict.Value.Dialogues));
                SaveHandler.Save(Id, "Storage", SaveHandler.GetStoragePath(Id), JsonConvert.SerializeObject(dict.Value.Suits));
            }
        }

        /// <summary>
        /// Save Profiles as AKI Profile
        /// </summary>
        public static void SaveAsAki()
        {
            foreach (var dict in ProfilesDict)
            {
                var Id = dict.Key;
                SaveHandler.Save(Id, "Aki", SaveHandler.GetAkiPath(Id), JsonConvert.SerializeObject(dict.Value, new JsonConverter[] { Converters.ItemLocationConverter.Singleton }), true);
            }
        }

        public static void SaveAsProfile()
        {
            foreach (var dict in ProfilesDict)
            {
                var Id = dict.Key;
                Profile.Base newBase = dict.Value;
                SaveHandler.Save(Id, "Account", SaveHandler.GetAccountPath(Id), JsonConvert.SerializeObject(newBase.Info));
                SaveHandler.Save(Id, "Character", SaveHandler.GetCharacterPath(Id), JsonHelper.FromCharacterBase(newBase.Characters.Pmc));
                SaveHandler.Save(Id, "Dialog", SaveHandler.GetDialogPath(Id), JsonConvert.SerializeObject(newBase.Dialogues));
                SaveHandler.Save(Id, "Storage", SaveHandler.GetStoragePath(Id), JsonConvert.SerializeObject(newBase.Suits));
                SaveHandler.Save(Id, "Scav", SaveHandler.GetScavPath(Id), JsonHelper.FromCharacterBase(newBase.Characters.Scav));
                SaveHandler.Save(Id, "Others", SaveHandler.GetOthersPath(Id), JsonConvert.SerializeObject(newBase.ProfileAddon));
                newBase.Info = new();
                newBase.Characters = new();
                newBase.Dialogues = new();
                newBase.Suits = new();
                newBase.ProfileAddon = new();
                SaveHandler.Save(Id, "Profile", SaveHandler.GetOthersPath(Id), JsonConvert.SerializeObject(newBase, new JsonConverter[] { Converters.ItemLocationConverter.Singleton }));
                if (!AlreadyConverted.Contains(Id))
                    AlreadyConverted.Add(Id);
            }
        }
    }
}
