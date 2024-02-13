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
using static JsonLib.Classes.Response.RandomisedBotLevel;
using static StressTester.StaticExt;

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

            /*
            var send_req = clientEx.SendRequest(MakePOSTResponse("/client/game/start", "", UserId));
            send_req.Wait();
            var res = send_req.Result;
            Console.WriteLine(res.Status + " " + res.StatusPhrase);
            Thread.Sleep(1000);
            */


            
            var tasks = GetTarkovTasks(UserId, name);
            Console.WriteLine(tasks.Count);
            foreach (var item in tasks)
            {
                Console.WriteLine(item.Url + " started");
                var result = clientEx.SendRequest(item);
                result.Wait();
                var res = result.Result;
                Console.WriteLine(res.Status + " " + item.Url);
                Thread.Sleep(1000);
                Console.ReadLine();
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


        public static List<HttpRequest> GetTarkovTasks(string UserId, string UserName)
        {
            List<HttpRequest> ret =
            [
                MakePOSTResponse("/client/game/start", "", UserId),
                MakePOSTResponse("/client/menu/locale/en", "", UserId),
                MakePOSTResponse("/client/game/version/validate", "", UserId),
                MakePOSTResponse("/client/languages", "", UserId),
                MakePOSTResponse("/client/game/config", "", UserId),
                MakePOSTResponse("/client/items", "", UserId),
                MakePOSTResponse("/client/customization", "", UserId),
                MakePOSTResponse("/client/globals", "", UserId),
                MakePOSTResponse("/client/trading/api/traderSettings", "", UserId),
                MakePOSTResponse("/client/settings", "", UserId),
                MakePOSTResponse("/client/game/profile/list", "", UserId),
                MakePOSTResponse("/client/locale/en", "", UserId),
                MakePOSTResponse("/client/account/customization", "", UserId),
                MakePOSTResponse("/client/game/profile/nickname/reserved", "", UserId),
                MakePOSTResponse("/client/game/profile/nickname/validate", JsonConvert.SerializeObject(new Nickname()
                {
                    nickname = UserName
                }), UserId),
                MakePOSTResponse("/client/game/profile/create", JsonConvert.SerializeObject(new Create()
                {
                    HeadId = "5cc084dd14c02e000b0550a3",
                    Side = "Bear",
                    Nickname = UserName,
                    VoiceId = "5fc1221a95572123ae7384a2"
                }), UserId),
                MakePOSTResponse("/client/game/profile/list", "", UserId),
                MakePOSTResponse("/client/game/profile/select", "", UserId),
                MakePOSTResponse("/client/profile/status", "", UserId),
                MakePOSTResponse("/client/weather", "", UserId),
                MakePOSTResponse("/client/locations", "", UserId),
                MakePOSTResponse("/client/handbook/templates", "", UserId),
                MakePOSTResponse("/client/hideout/areas", "", UserId),
                MakePOSTResponse("/client/hideout/qte/list", "", UserId),
                MakePOSTResponse("/client/hideout/settings", "", UserId),
                MakePOSTResponse("/client/hideout/production/recipes", "", UserId),
                MakePOSTResponse("/client/hideout/production/scavcase/recipes", "", UserId),
                MakePOSTResponse("/client/handbook/builds/my/list", "", UserId),
                MakePOSTResponse("/client/notifier/channel/create", "", UserId),
                MakePOSTResponse("/client/profile/status", "", UserId),
                MakePOSTResponse("/client/friend/list", "", UserId),
                MakePOSTResponse("/client/friend/request/list/outbox", "", UserId),
                MakePOSTResponse("/client/friend/request/list/inbox", "", UserId),
                MakePOSTResponse("/client/mail/dialog/list", "", UserId),
                MakePOSTResponse("/client/trading/customization/storage", "", UserId),
                MakePOSTResponse("/client/server/list", "", UserId),
                MakePOSTResponse("/client/match/group/current", "", UserId),
                MakePOSTResponse("/client/quest/list", "", UserId),
                MakePOSTResponse("/client/repeatalbeQuests/activityPeriods", "", UserId),
                MakePOSTResponse("/client/game/logout", "", UserId),
            ];
            return ret;
        }


    }
}
