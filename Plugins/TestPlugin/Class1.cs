using ModdableWebServer;
using ModdableWebServer.Attributes;
using ModdableWebServer.Helper;
using NetCoreServer;

namespace TestPlugin
{
    public class Class1
    {
        public static async void This()
        {
            await MyBigTask();


            //Console.WriteLine("Function inside a class");
        }

        [HTTP("GET", "/test")]
        public static bool Test(HttpRequest request, ServerStruct serverStruct)
        {
            string resp = "OVERRIDED!";
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("GET", "/test2")]
        public static bool Test2(HttpRequest request, ServerStruct serverStruct)
        {
            string resp = "test2 from a Plugin!";
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }

        public static async Task MyTask(string x)
        {
            await Task.Run(() =>
            {
                if (x == "test")
                {
                    Console.WriteLine("test");
                }
                else
                {
                    Console.WriteLine("yeetteete");
                }


            });

        }

        public static async Task MyBigTask()
        {
            await MyTask("test");
            await MyTask("fdsfs");
        }

    }
}
