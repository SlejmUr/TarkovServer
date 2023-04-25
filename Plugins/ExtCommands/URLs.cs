using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ExtCommands
{
    public class URLs
    {
        [HTTP("POST", "/extcommands/auth")]
        public static bool ExtCommandsAuth(HttpRequest request, HttpsBackendSession session)
        {
            Console.WriteLine(request.Body);
            List<string> x = new()
            { 
                "yywww",
                "dddddddddddddddddd"
            };
            ServerLib.Json.Classes.Configs.Plugin plugin = new()
            { 
                file = "yeet",
                ignore = false,
                dependencies = x
            };
            var rsp = JsonConvert.SerializeObject(plugin);
            Debug.PrintError(rsp);
            session.SendResponse(session.Response.MakeGetResponse(rsp));
            return true;
        }

        [HTTP("POST", "/extcommands/use")]
        public static bool ExtCommandsPost(HttpRequest request, HttpsBackendSession session)
        {
            Console.WriteLine(request.Body);

            

            session.SendResponse(session.Response.MakeGetResponse(""));
            return true;
        }
    }
}
