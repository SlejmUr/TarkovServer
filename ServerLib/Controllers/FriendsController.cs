using ServerLib.Utilities;
using ServerLib.Json;
using Newtonsoft.Json;

namespace ServerLib.Controllers
{
    public class FriendsController
    {
        //Todo:
        //Add/Remove/List Friends, Using account.json | Need AID

        public static List<CharacterOBJ> GetFriends(string sessionId)
        {
            List<CharacterOBJ> friends = new();

            var account = AccountController.FindAccount(sessionId);
            var all_account = AccountController.GetAccounts();
            if (account == null)
            {
                Utils.PrintError("No Account found as ID: " + sessionId);
                return null;
            }

            if (account.Friends.Length == 0)
            {
                return friends;
            }
            else
            {
                foreach (var friend_id in account.Friends)
                {
                    var acc = all_account.Find(x=>x._id == friend_id);
                    if (acc != null)
                    {
                        friends.Add(acc);
                    }
                    else
                    {
                        Utils.PrintError("Unable to find friend's account by its Id"+ friend_id);
                    }
                }
            }
            return friends;
        }
        public static List<string> GetFriendsID(string sessionId)
        {
            List<string> friends = new();
            var account = AccountController.FindAccount(sessionId);
            if (account == null)
            {
                Utils.PrintError("No Account found as ID: " + sessionId);
                return null;
            }

            if (account.Friends.Length != 0)
            {
                friends = account.Friends.ToList();
            }

            return friends;
        }

        public static bool IsBothFriend(string sessionId, string FriendId,bool ForceAdd = false)
        {
            var account = AccountController.FindAccount(sessionId);
            if (account == null)
            {
                Utils.PrintError("No Account found as ID: " + sessionId);
                return false;
            }

            var friend = AccountController.FindAccount(FriendId);
            if (friend == null)
            {
                Utils.PrintError("No Account found as ID: " + friend);
                return false;
            }

            if (ForceAdd)
            {
                var af = account.Friends.ToList();
                var ff = friend.Friends.ToList();

                af.Add(FriendId);
                ff.Add(sessionId);
                account.Friends = af.ToArray();
                friend.Friends = ff.ToArray();

                Handlers.SaveHandler.SaveAccount(sessionId, account);
                Handlers.SaveHandler.SaveAccount(FriendId, friend);
                Utils.PrintDebug("Both Friend added to each other (forced)");
            }


            if (account.Friends.Contains(FriendId))
            {
                if (friend.Friends.Contains(sessionId))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsFriend(string sessionId, string FriendId)
        {
            var account = AccountController.FindAccount(sessionId);
            if (account == null)
            {
                Utils.PrintError("No Account found as ID: " + sessionId);
                return false;
            }

            if (account.Friends.Contains(FriendId))
            {
                return true;
            }
            return false;
        }

        public static void AddFriend(string sessionId, string FriendId)
        {
            var account = AccountController.FindAccount(sessionId);
            if (account == null)
            {
                Utils.PrintError("No Account found as ID: " + sessionId);
                return;
            }

            var friend = AccountController.FindAccount(FriendId);
            if (friend == null)
            {
                Utils.PrintError("No Account found as ID: " + friend);
                return;
            }
            /*
            var af = account.Friends.ToList();
            var ff = friend.Friends.ToList();

            af.Add(FriendId);
            ff.Add(sessionId);
            account.Friends = af.ToArray();
            friend.Friends = ff.ToArray();
            */
            account.Friends.ToList().Add(FriendId);
            friend.Friends.ToList().Add(sessionId);

            Handlers.SaveHandler.SaveAccount(sessionId, account);
            Handlers.SaveHandler.SaveAccount(FriendId, friend);

        }


        public static Other.FriendRequester MakeRequest(string ID ,string FromID,string ToID)
        {
            Other.FriendRequester requester = new();
            requester.Id = ID;
            requester.Date = Utils.UnixTimeNow_Int();
            requester.From = FromID;
            requester.To = ToID;
            requester.Profile = FromID;
            return requester;
        }


        public static void _Test(string id,string id2)
        {
            List<Other.FriendRequester> friendRequesters = new();
            Other.FriendRequester requester = new();
            requester.Id = Utils.CreateNewID();
            requester.Date = Utils.UnixTimeNow_Int();
            requester.From = id;
            requester.To = id2;
            requester.Profile = id;

            friendRequesters.Add(requester);

            var xxx = friendRequesters.ToArray();
            foreach (var x in xxx)
            {
                Console.WriteLine(JsonConvert.SerializeObject(x));
            }
            
        }
    }
}
