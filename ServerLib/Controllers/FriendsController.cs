using ServerLib.Json.Classes;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Controllers
{
    public class FriendsController
    {

        static FriendsController()
        {
            ProfileAddons = new();
            ProfileAddonsDict = new();
            GetAddonList();
            Debug.PrintInfo("Initialization Done!", "[Friends]");
        }

        public static Dictionary<string, ProfileAddon> ProfileAddonsDict;
        public static List<ProfileAddon> ProfileAddons;
        public static void GetAddonList()
        {
            ProfileController.ReloadProfiles();
            foreach (var profile in ProfileController.Profiles)
            {
                ProfileAddonsDict.TryAdd(profile.Info.Id,profile.ProfileAddon);
                ProfileAddons.Add(profile.ProfileAddon);
            }
        }



        /// <summary>
        /// Get Friends CharacterOBJ
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>List of CharactherOBJ</returns>
        public static List<Character.Base> GetFriends(string SessionId)
        {
            List<Character.Base> friends = new();

            var account = ProfileAddonsDict[SessionId];
            var all_account = CharacterController.Characters.Values.ToList();
            //var all_account = AccountController.GetAccounts();

            if (account.Friends.Friends.Count == 0)
            {
                return friends;
            }
            else
            {
                foreach (var friend in account.Friends.Friends)
                {
                    var acc = all_account.Find(x => x.Id == friend.Aid || x.Id == friend.Aid);
                    if (acc != null)
                    {
                        friends.Add(acc);
                    }
                    else
                    {
                        Debug.PrintError("Unable to find friend's account by its Id" + friend.Id);
                    }
                }
            }
            return friends;
        }

        /// <summary>
        /// Add Friend to Account
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="FriendId">Friend SessionId/AccountId</param>
        public static void AddFriend(string SessionId, string FriendId)
        {
            var account = ProfileAddonsDict[SessionId];
            var friend = ProfileAddonsDict[FriendId];
            var account_pmc = CharacterController.GetPmcCharacter(SessionId);
            var friend_pmc = CharacterController.GetPmcCharacter(FriendId);

            account.Friends.Friends.Add(friend_pmc);
            friend.Friends.Friends.Add(account_pmc);

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
            var account = ProfileAddonsDict[SessionId];
            var friend = ProfileAddonsDict[addId];
            var account_pmc = CharacterController.GetPmcCharacter(SessionId);
            var friend_pmc = CharacterController.GetPmcCharacter(addId);

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
        public static string RemoveRequest(string SessionId, string removeId)
        {
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

            return removeId;
        }

        /// <summary>
        /// Accept all Friend Request
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void AcceptAll(string SessionId)
        {
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
            requester.Profile = FromID;
            return requester;
        }

        /// <summary>
        /// Get Friend Request Inbox
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>List of Friend Request</returns>
        public static List<FriendRequester> GetFriendsInbox(string SessionId)
        {
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
            var account = ProfileAddonsDict[SessionId];

            if (account.Friends.Friends.Where(x => x.Id == FriendId || x.Aid == FriendId).Any())
            {
                return true;
            }
            return false;
        }
    }
}
