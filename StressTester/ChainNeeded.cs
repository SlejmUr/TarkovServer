using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer;
using Newtonsoft.Json;
using JsonLib.Classes.Request;
using System.Xml.Linq;
using ComponentAce.Compression.Libs.zlib;

namespace StressTester
{
    internal class ChainNeeded
    {
        public class WebAccount
        {
            public string Name { get; set; }
            public string AccountId { get; set; }
        }
        public static void StartThis(HttpsClientEx clientEx)
        {
            if (clientEx.IsConnected)
                clientEx.ReconnectAsync();
            else
                clientEx.ConnectAsync();
            var name = RandomGen.GenerateRandom();
            var pass = RandomGen.GenerateRandom();
            var task = clientEx.SendPostRequest("/webprofile/test",
                JsonConvert.SerializeObject(new Login()
                {
                    username = name,
                    password = pass
                }));
            task.Wait();
            Console.WriteLine("Is test success? " + (task.Result.Body == "test") + " " + task.Result.Body);


            task = clientEx.SendPostRequest("/webprofile/register",
    JsonConvert.SerializeObject(new Login()
    {
        username = name,
        password = pass
    }));
            task.Wait();
            var UserId = task.Result.Body;
            Console.WriteLine($"UserID added: {UserId}");


            var tasks = GetTarkovTasks(clientEx, UserId, name);
            Console.WriteLine(tasks.Count);
            foreach (var item in tasks)
            {
                Console.WriteLine(item.Url + " started");
                if (clientEx.IsConnected)
                    clientEx.ReconnectAsync();
                else
                    clientEx.ConnectAsync();
                Console.WriteLine(clientEx.SendRequest(item).Result.Status + " " + item.Url);
            }
            task = clientEx.SendPostRequest("/webprofile/delete",
    JsonConvert.SerializeObject(new WebAccount()
    {
        Name = name,
        AccountId = UserId
    }));
            task.Wait();
            Console.WriteLine($"UserID deleted: {UserId}, Result: {task.Result.Body}");
            clientEx.Disconnect();
        }


        public static List<HttpRequest> GetTarkovTasks(HttpsClientEx clientEx, string UserId, string UserName)
        {
            List<HttpRequest> ret = new();
            ret.Add(clientEx.MakePOSTResponse("/client/game/start", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/menu/locale/en", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/game/version/validate", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/languages", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/game/config", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/items", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/customization", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/globals", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/trading/api/traderSettings", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/settings", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/game/profile/list", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/locale/en", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/account/customization", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/game/profile/nickname/reserved", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/game/profile/nickname/validate", JsonConvert.SerializeObject(new Nickname()
            {
                nickname = UserName
            }), UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/game/profile/create", JsonConvert.SerializeObject(new Create()
            {
                HeadId = "5cc084dd14c02e000b0550a3",
                Side = "Bear",
                Nickname = UserName,
                VoiceId = "5fc1221a95572123ae7384a2"
            }), UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/game/profile/list", "", UserId)); 
            ret.Add(clientEx.MakePOSTResponse("/client/game/profile/select", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/profile/status", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/weather", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/locations", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/handbook/templates", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/hideout/areas", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/hideout/qte/list", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/hideout/settings", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/hideout/production/recipes", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/hideout/production/scavcase/recipes", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/handbook/builds/my/list", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/notifier/channel/create", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/profile/status", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/friend/list", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/friend/request/list/outbox", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/friend/request/list/inbox", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/mail/dialog/list", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/trading/customization/storage", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/server/list", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/match/group/current", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/quest/list", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/repeatalbeQuests/activityPeriods", "", UserId));
            ret.Add(clientEx.MakePOSTResponse("/client/game/logout", "", UserId));
            return ret;
        }


    }
}
