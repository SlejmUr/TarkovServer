using NetCoreServer;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

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
        public static bool Test(HttpRequest request, HttpsBackendSession session)
        {
            string resp = "OVERRIDED!";
            session.SendResponse(session.Response.MakeGetResponse(resp));
            return true;
        }

        [HTTP("GET", "/test2")]
        public static bool Test2(HttpRequest request, HttpsBackendSession session)
        {
            string resp = "test2 from a Plugin!";
            session.SendResponse(session.Response.MakeGetResponse(resp));
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
