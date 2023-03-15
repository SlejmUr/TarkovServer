using ServerLib.Json;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class FriendsController
    {
        /// <summary>
        /// Get Friends CharacterOBJ
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>List of CharactherOBJ</returns>
        public static List<CharacterOBJ> GetFriends(string SessionId)
        {
            List<CharacterOBJ> friends = new();

            var account = AccountController.FindAccount(SessionId);
            var all_account = AccountController.GetAccounts();

            if (account.Friends.Length == 0)
            {
                return friends;
            }
            else
            {
                foreach (var friend_id in account.Friends)
                {
                    var acc = all_account.Find(x => x._id == friend_id);
                    if (acc != null)
                    {
                        friends.Add(acc);
                    }
                    else
                    {
                        Debug.PrintError("Unable to find friend's account by its Id" + friend_id);
                    }
                }
            }
            return friends;
        }

        /// <summary>
        /// Get Friends IDs
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>List of IDs</returns>
        public static List<string> GetFriendsID(string SessionId)
        {
            List<string> friends = new();
            var account = AccountController.FindAccount(SessionId);

            if (account.Friends.Length != 0)
            {
                friends = account.Friends.ToList();
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
            var account = AccountController.FindAccount(SessionId);
            var friend = AccountController.FindAccount(FriendId);

            account.Friends.ToList().Add(FriendId);
            friend.Friends.ToList().Add(SessionId);

            Handlers.SaveHandler.SaveAccount(SessionId, account);
            Handlers.SaveHandler.SaveAccount(FriendId, friend);
        }

        /// <summary>
        /// Remove Friend from Account
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="FriendId">Friend SessionId/AccountId</param>
        public static void RemoveFriend(string SessionId, string FriendId)
        {
            var account = AccountController.FindAccount(SessionId);
            var friend = AccountController.FindAccount(FriendId);

            account.Friends.ToList().Remove(FriendId);
            friend.Friends.ToList().Remove(SessionId);

            Handlers.SaveHandler.SaveAccount(SessionId, account);
            Handlers.SaveHandler.SaveAccount(FriendId, friend);
        }

        /// <summary>
        /// Make and send Request to Friend
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="addId">Friend SessionId/AccountId</param>
        /// <returns>RequestId</returns>
        public static string AddRequest(string SessionId, string addId)
        {
            var account = AccountController.FindAccount(SessionId);
            var friend = AccountController.FindAccount(addId);

            var rId = Utils.CreateNewID();

            var reqFrom = MakeRequest(rId, SessionId, addId);
            var reqTo = MakeRequest(rId, addId, SessionId);

            account.FriendRequestOutbox.ToList().Add(reqFrom);
            friend.FriendRequestInbox.ToList().Add(reqTo);

            Handlers.SaveHandler.SaveAccount(SessionId, account);
            Handlers.SaveHandler.SaveAccount(addId, friend);

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
            var acc = AccountController.FindAccount(SessionId);
            var InBox = GetFriendsInbox(SessionId);
            var OutBox = GetFriendsOutbox(SessionId);

            var InRequest = InBox.Where(x => x.Id == removeId).FirstOrDefault();
            InBox.Remove(InRequest);
            var OutRequest = OutBox.Where(x => x.Id == removeId).FirstOrDefault();
            OutBox.Remove(OutRequest);

            acc.FriendRequestInbox = InBox.ToArray();
            acc.FriendRequestInbox = OutBox.ToArray();

            Handlers.SaveHandler.SaveAccount(SessionId, acc);

            return removeId;
        }

        /// <summary>
        /// Accept all Friend Request
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void AcceptAll(string SessionId)
        {
            List<Json.Other.FriendRequester> empty = new();
            List<string> addedAccounts = new();

            var acc = AccountController.FindAccount(SessionId);

            foreach (var friends in acc.FriendRequestInbox)
            {
                AddFriend(SessionId, friends.To);
                addedAccounts.Add(friends.To);
            }

            acc.FriendRequestInbox = empty.ToArray();
            Handlers.SaveHandler.SaveAccount(SessionId, acc);
        }

        /// <summary>
        /// Make a new Friend Request
        /// </summary>
        /// <param name="ID">RequestId</param>
        /// <param name="FromID">From SessionId/AccountId</param>
        /// <param name="ToID">To SessionId/AccountId</param>
        /// <returns>New Friend Request</returns>
        public static Json.Other.FriendRequester MakeRequest(string ID, string FromID, string ToID)
        {
            Json.Other.FriendRequester requester = new();
            requester.Id = ID;
            requester.Date = Utils.UnixTimeNow_Int();
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
        public static List<Json.Other.FriendRequester> GetFriendsInbox(string SessionId)
        {
            var account = AccountController.FindAccount(SessionId);
            var ouput = account.FriendRequestInbox.ToList();
            return ouput;
        }

        /// <summary>
        /// Get Friend Request Outbox
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>List of Friend Request</returns>
        public static List<Json.Other.FriendRequester> GetFriendsOutbox(string SessionId)
        {
            var account = AccountController.FindAccount(SessionId);
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
            var account = AccountController.FindAccount(SessionId);
            var friend = AccountController.FindAccount(FriendId);

            if (account.Friends.Contains(FriendId))
            {
                if (friend.Friends.Contains(SessionId))
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
            var account = AccountController.FindAccount(SessionId);

            if (account.Friends.Contains(FriendId))
            {
                return true;
            }
            return false;
        }
    }
}
