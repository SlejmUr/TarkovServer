using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.ResponseControl;

namespace ServerLib.Responders
{
    public static class Friend
    {

        public static byte[] FriendList(string SessionId)
        {
            object response = null;
            Json.Classes.FriendList friendsList = new Json.Classes.FriendList();
            friendsList.Friends.AddRange(FriendsController.GetFriends(SessionId));
            return CompressRsp(GetBody(JsonConvert.SerializeObject(response)));
        }

    }
}
