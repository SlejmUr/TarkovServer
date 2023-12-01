using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer;
using Newtonsoft.Json;
using JsonLib.Classes.Request;

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




            task = clientEx.SendPostRequest("/webprofile/delete",
    JsonConvert.SerializeObject(new WebAccount()
    {
        Name = name,
        AccountId = UserId
    }));
            task.Wait();
            Console.WriteLine($"UserID deleted: {UserId}, Result: {task.Result.Body}");
        }


        public static List<Task<HttpResponse>> GetTarkovTasks()
        {
            List<Task<HttpResponse>> ret = new();












            return ret;
        }
    }
}
