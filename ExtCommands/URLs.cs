using NetCoreServer;
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
           

            session.SendResponse(session.Response.MakeGetResponse(""));
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
