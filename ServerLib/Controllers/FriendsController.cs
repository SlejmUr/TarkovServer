using ServerLib.Handlers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using System.Linq;

namespace ServerLib.Controllers
{
    public class FriendsController
    {

        static FriendsController()
        {
            ProfileAddons = new();
            ProfileAddonsDict = new();
            GetAddonList();
            Debug.PrintInfo("Initialization Done!", "Friends");
        }

        public static Dictionary<string, ProfileAddon> ProfileAddonsDict;
        public static List<ProfileAddon> ProfileAddons;
        public static void GetAddonList()
        {
            ProfileController.ReloadProfiles();
            foreach (var profile in ProfileController.ProfilesDict)
            {
                //  Need Delete then Readd because it can be used
                if (ProfileAddonsDict.ContainsKey(profile.Key))
                    ProfileAddons.Remove(profile.Value.ProfileAddon);

                if (profile.Value.ProfileAddon == null)
                {
                    profile.Value.ProfileAddon = new()
                    {
                        Permission = Json.Enums.EPerms.User,
                        FriendRequestInbox = new(),
                        FriendRequestOutbox = new(),
                        Friends = new()
                        {
                            Friends = new() { },
                            Ignore = new(),
                            InIgnoreList = new()
                        }
                    };
                    SaveHandler.SaveAddon(profile.Key, profile.Value.ProfileAddon);
                }
                if (profile.Value.ProfileAddon.Friends == null)
                {
                    profile.Value.ProfileAddon.Friends = new()
                    {
                        Friends = new() { },
                        Ignore = new(),
                        InIgnoreList = new()
                    };
                    SaveHandler.SaveAddon(profile.Key, profile.Value.ProfileAddon);
                }
                
                ProfileAddonsDict.TryAdd(profile.Key, profile.Value.ProfileAddon);
                if (!ProfileAddons.Contains(profile.Value.ProfileAddon))
                    ProfileAddons.Add(profile.Value.ProfileAddon);
            }
        }

        public static FriendList GetFriendList(string SessionId)
        {
            GetAddonList();
            var account = ProfileAddonsDict[SessionId];
            return account.Friends;
        }

        /// <summary>
        /// Add Friend to Account
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="FriendId">Friend SessionId/AccountId</param>
        public static void AddFriend(string SessionId, string FriendId)
        {
            GetAddonList();
            var account = ProfileAddonsDict[SessionId];
            var friend = ProfileAddonsDict[FriendId];
            var account_pmc = CharacterController.GetPmcCharacter(SessionId);
            var friend_pmc = CharacterController.GetPmcCharacter(FriendId);

            account.Friends.Friends.Add(friend_pmc);
            friend.Friends.Friends.Add(account_pmc);

            Handlers.SaveHandler.SaveAddon(SessionId, account);
            Handlers.SaveHandler.SaveAddon(FriendId, friend);
        }

        public static void MuteFriend(string SessionId, string FriendId)
        {
            GetAddonList();
            var account = ProfileAddonsDict[SessionId];
            var friend = ProfileAddonsDict[FriendId];

            account.Friends.Ignore.Add(FriendId);
            friend.Friends.InIgnoreList.Add(SessionId);

            Handlers.SaveHandler.SaveAddon(SessionId, account);
            Handlers.SaveHandler.SaveAddon(FriendId, friend);
        }

        public static void UnMuteFriend(string SessionId, string FriendId)
        {
            GetAddonList();
            var account = ProfileAddonsDict[SessionId];
            var friend = ProfileAddonsDict[FriendId];

            account.Friends.Ignore.Remove(FriendId);
            friend.Friends.InIgnoreList.Remove(SessionId);

            Handlers.SaveHandler.SaveAddon(SessionId, account);
            Handlers.SaveHandler.SaveAddon(FriendId, friend);
        }

        /// <summary>
        /// Remove Friend from Account
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="FriendId">Friend SessionId/AccountId</param>
        public static void RemoveFriend(string SessionId, string FriendId)
        {
            GetAddonList();
            var account = ProfileAddonsDict[SessionId];
            var friend = ProfileAddonsDict[FriendId];

            account.Friends.Friends.RemoveAll(x => x.Id == FriendId);
            friend.Friends.Friends.RemoveAll(x => x.Id == SessionId);

            Handlers.SaveHandler.SaveAddon(SessionId, account);
            Handlers.SaveHandler.SaveAddon(FriendId, friend);
        }

        /// <summary>
        /// Make and send Request to Friend
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="addId">Friend SessionId/AccountId</param>
        /// <returns>RequestId</returns>
        public static string AddRequest(string SessionId, string addId)
        {
            GetAddonList();
            var account = ProfileAddonsDict[SessionId];
            var friend = ProfileAddonsDict[addId];

            var rId = Utils.CreateNewID();

            var reqFrom = MakeRequest(rId, SessionId, addId);
            var reqTo = MakeRequest(rId, addId, SessionId);

            account.FriendRequestOutbox.ToList().Add(reqFrom);
            friend.FriendRequestInbox.ToList().Add(reqTo);

            Handlers.SaveHandler.SaveAddon(SessionId, account);
            Handlers.SaveHandler.SaveAddon(addId, friend);

            return rId;
        }

        /// <summary>
        /// Remove a Friend Request by RequestId
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="removeId">RequestId</param>
        /// <returns>RequestId</returns>
        public static void RemoveRequest(string SessionId, string removeId)
        {
            GetAddonList();
            var acc = ProfileAddonsDict[SessionId];
            var InBox = GetFriendsInbox(SessionId);
            var OutBox = GetFriendsOutbox(SessionId);

            var InRequest = InBox.Where(x => x.Id == removeId).FirstOrDefault();
            InBox.Remove(InRequest);
            var OutRequest = OutBox.Where(x => x.Id == removeId).FirstOrDefault();
            OutBox.Remove(OutRequest);

            acc.FriendRequestInbox = InBox;
            acc.FriendRequestInbox = OutBox;

            Handlers.SaveHandler.SaveAddon(SessionId, acc);
            //TODO: do the same with other account!

        }

        /// <summary>
        /// Accept all Friend Request
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void AcceptAll(string SessionId)
        {
            GetAddonList();
            List<FriendRequester> empty = new();
            List<string> addedAccounts = new();

            var acc = ProfileAddonsDict[SessionId];

            foreach (var friends in acc.FriendRequestInbox)
            {
                AddFriend(SessionId, friends.To);
                addedAccounts.Add(friends.To);
            }

            acc.FriendRequestInbox = empty;
            Handlers.SaveHandler.SaveAddon(SessionId, acc);
        }

        /// <summary>
        /// Make a new Friend Request
        /// </summary>
        /// <param name="ID">RequestId</param>
        /// <param name="FromID">From SessionId/AccountId</param>
        /// <param name="ToID">To SessionId/AccountId</param>
        /// <returns>New Friend Request</returns>
        public static FriendRequester MakeRequest(string ID, string FromID, string ToID)
        {
            FriendRequester requester = new();
            requester.Id = ID;
            requester.Date = TimeHelper.UnixTimeNow_Int();
            requester.From = FromID;
            requester.To = ToID;
            requester.Profile = CharacterController.GetMiniCharacter(FromID);
            return requester;
        }

        /// <summary>
        /// Get Friend Request Inbox
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>List of Friend Request</returns>
        public static List<FriendRequester> GetFriendsInbox(string SessionId)
        {
            GetAddonList();
            var account = ProfileAddonsDict[SessionId];
            var ouput = account.FriendRequestInbox.ToList();
            return ouput;
        }

        /// <summary>
        /// Get Friend Request Outbox
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>List of Friend Request</returns>
        public static List<FriendRequester> GetFriendsOutbox(string SessionId)
        {
            GetAddonList();
            var account = ProfileAddonsDict[SessionId];
            var ouput = account.FriendRequestOutbox.ToList();
            return ouput;
        }

        /// <summary>
        /// Check if Both are Friends
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="FriendId">SessionId/AccountId</param>
        /// <returns>True | False</returns>
        public static bool IsBothFriend(string SessionId, string FriendId)
        {
            GetAddonList();
            var account = ProfileAddonsDict[SessionId];
            var friend = ProfileAddonsDict[FriendId];
            if (account.Friends.Friends.Where(x => x.Id == FriendId || x.Aid == FriendId).Any())
            {
                if (friend.Friends.Friends.Where(x => x.Id == SessionId || x.Aid == SessionId).Any())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check if is a Friend
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="FriendId">List of Friend Request</param>
        /// <returns>True | False</returns>
        public static bool IsFriend(string SessionId, string FriendId)
        {
            GetAddonList();
            var account = ProfileAddonsDict[SessionId];

            if (account.Friends.Friends.Where(x => x.Id == FriendId || x.Aid == FriendId).Any())
            {
                return true;
            }
            return false;
        }
    }
}
