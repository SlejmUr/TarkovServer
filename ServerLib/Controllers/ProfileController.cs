using Newtonsoft.Json;
using ServerLib.Handlers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;

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
        public static void Init()
        {
            ReloadProfiles();
            Debug.PrintInfo("Initialization Done!", "[Profile]");
        }

        public static void ReloadProfiles()
        {
            Profiles.AddRange(ConvertFromJET());
            Profiles.AddRange(ConvertFromAkiProfile());
            Profiles.AddRange(ConvertFromProfile());
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
                    @base = pbase;
                }
                if (File.Exists($"{dir}/others.json"))
                {
                    var others = JsonConvert.DeserializeObject<ProfileAddon>(File.ReadAllText($"{dir}/others.json"));
                    @base.ProfileAddon = others;
                }
                if (File.Exists($"{dir}/account.json"))
                {
                    var account = JsonConvert.DeserializeObject<Profile.Info>(File.ReadAllText($"{dir}/account.json"));
                    @base.Info = account;
                }
                if (File.Exists($"{dir}/character.json"))
                {
                    var character = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText($"{dir}/character.json"));
                    @base.Characters.Pmc = character;
                }
                if (File.Exists($"{dir}/scav.json"))
                {
                    var scav = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText($"{dir}/scav.json"));
                    @base.Characters.Scav = scav;
                }
                if (File.Exists($"{dir}/storage.json"))
                {
                    var storage = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText($"{dir}/storage.json"));
                    @base.Suits = storage;
                }
                if (File.Exists($"{dir}/dialog.json"))
                {
                    var dialog = JsonConvert.DeserializeObject<Dictionary<string, Profile.Dialogue>>(File.ReadAllText($"{dir}/dialog.json"));
                    @base.Dialogues = dialog;
                }
                if (!ProfilesDict.ContainsKey(@base.Info.Id))
                {
                    ProfilesDict.Add(@base.Info.Id,@base);
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
            string[] dirs = Directory.GetFiles("user/profiles");
            foreach (string dir in dirs)
            {
                if (dir.Contains(".json"))
                {
                    var account = JsonConvert.DeserializeObject<Profile.Base>(File.ReadAllText(dir));
                    ret.Add(account);
                    if (!ProfilesDict.ContainsKey(account.Info.Id))
                    {
                        Debug.PrintInfo("ConvertFromAkiProfile!");
                        ProfilesDict.Add(account.Info.Id, account);
                    }
                }

            }
            return ret;
        }

        /// <summary>
        /// Convert JET type of versions of profile
        /// </summary>
        public static List<Profile.Base> ConvertFromJET()
        {
            List<Profile.Base> ret = new();
            string[] dirs = Directory.GetDirectories("user/profiles");
            foreach (string dir in dirs)
            {
                Profile.Base @base = new();
                if (File.Exists($"{dir}/account.json"))
                {
                    var account = JsonConvert.DeserializeObject<Profile.Info>(File.ReadAllText($"{dir}/account.json"));
                    if (account.Edition == null | string.IsNullOrEmpty(account.Edition))
                        continue;
                    @base.Info = account;
                }
                if (File.Exists($"{dir}/character.json"))
                {
                    var character = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText($"{dir}/character.json"));
                    @base.Characters = new()
                    { 
                        Scav = character,
                        Pmc = character
                    };
                }
                if (File.Exists($"{dir}/storage.json"))
                {
                    var storage = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText($"{dir}/storage.json"));
                    @base.Suits = storage;
                }
                if (File.Exists($"{dir}/dialog.json"))
                {
                    var dialog = JsonConvert.DeserializeObject<Dictionary<string, Profile.Dialogue>>(File.ReadAllText($"{dir}/dialog.json"));
                    @base.Dialogues = dialog;
                }
                if (!ProfilesDict.ContainsKey(@base.Info.Id))
                {
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




        /// <summary>
        /// Save Profiles as JET tpye of Profile
        /// </summary>
        public static void SaveAsJET()
        {
            foreach (var dict in ProfilesDict)
            {
                var Id = dict.Key;
                SaveHandler.Save(Id, "Account", SaveHandler.GetAccountPath(Id), JsonConvert.SerializeObject(dict.Value.Info));
                SaveHandler.Save(Id, "Character", SaveHandler.GetCharacterPath(Id), JsonConvert.SerializeObject(dict.Value.Characters.Pmc));
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
                SaveHandler.Save(Id, "Aki", SaveHandler.GetAkiPath(Id), JsonConvert.SerializeObject(dict.Value), true);
            }
        }

        public static void SaveAsProfile()
        {
            foreach (var dict in ProfilesDict)
            {
                var Id = dict.Key;
                Profile.Base newBase = dict.Value;
                SaveHandler.Save(Id, "Account", SaveHandler.GetAccountPath(Id), JsonConvert.SerializeObject(newBase.Info));
                SaveHandler.Save(Id, "Character", SaveHandler.GetCharacterPath(Id), JsonConvert.SerializeObject(newBase.Characters.Pmc));
                SaveHandler.Save(Id, "Dialog", SaveHandler.GetDialogPath(Id), JsonConvert.SerializeObject(newBase.Dialogues));
                SaveHandler.Save(Id, "Storage", SaveHandler.GetStoragePath(Id), JsonConvert.SerializeObject(newBase.Suits));
                SaveHandler.Save(Id, "Scav", SaveHandler.GetScavPath(Id), JsonConvert.SerializeObject(newBase.Characters.Scav));
                SaveHandler.Save(Id, "Others", SaveHandler.GetOthersPath(Id), JsonConvert.SerializeObject(newBase.ProfileAddon));
                newBase.Info = new();
                newBase.Characters = new();
                newBase.Dialogues = new();
                newBase.Suits = new();
                newBase.ProfileAddon = new();
                SaveHandler.Save(Id, "Profile", SaveHandler.GetOthersPath(Id), JsonConvert.SerializeObject(newBase));
            }
        }
    }
}
