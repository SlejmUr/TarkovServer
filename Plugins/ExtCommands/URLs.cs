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
            var rsp = JWTHandler.CreateAuthToken("yeet","Secret");
            session.SendResponse(session.Response.MakeGetResponse(rsp));
            return true;
        }

        [HTTP("POST", "/extcommands/use")]
        public static bool ExtCommandsPost(HttpRequest request, HttpsBackendSession session)
        {
            Console.WriteLine($"Command: {request.Body}");

            if (session.Headers.TryGetValue("Auth", out string authtoken) && JWTHandler.Validate(authtoken))
            {
                var json = JsonConvert.DeserializeObject<jwt_json>(JWTHandler.GetJWTJson(authtoken));
                if (json.Perms == ServerLib.Json.EPerms.Blocked)
                {
                    session.SendResponse(session.Response.MakeGetResponse("You are Banned!"));
                    return true;
                }
                if (CommandsController.CommandsPermission.TryGetValue(request.Body.Split(" ")[0], out var permission))
                {
                    if (permission >= json.Perms)
                    {
                        CommandsController.Run(request.Body);
                        session.SendResponse(session.Response.MakeGetResponse("Success!"));
                        return true;
                    }            
                }
            }
            session.SendResponse(session.Response.MakeGetResponse("Something not right..."));
            return true;
        }
    }
}
