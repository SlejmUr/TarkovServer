using NetCoreServer;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class ResFiles
    {

        [HTTP("GET", "/files/trader/avatar/{avatar}")]
        public static bool GetFilesAvatar(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string avatar = session.HttpParam["avatar"].Replace("jpg", "png");
            byte[] rsp;
            if (!File.Exists($"Files/res/trader/{avatar}"))
            {
                rsp = File.ReadAllBytes($"Files/res/noimage/avatar.png");
            }
            else
            {
                rsp = File.ReadAllBytes($"Files/res/trader/{avatar}");
            }
            session.SendResponse(session.Response.MakeGetResponse(rsp).SetHeader("Content-Type", "image/png"));
            return true;
        }

        [HTTP("GET", "/files/handbook/{handbook}")]
        public static bool GetFilesHandbook(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string handbook = session.HttpParam["handbook"].Replace("jpg", "png");
            byte[] rsp;
            if (!File.Exists($"Files/res/handbook/{handbook}"))
            {
                rsp = File.ReadAllBytes($"Files/res/noimage/handbook.png");
            }
            else
            {
                rsp = File.ReadAllBytes($"Files/res/handbook/{handbook}");
            }
            session.SendResponse(session.Response.MakeGetResponse(rsp).SetHeader("Content-Type", "image/png"));
            return true;
        }

        [HTTP("GET", "/files/Hideout/{Hideout}")]
        public static bool GetFilesHideout(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string Hideout = session.HttpParam["Hideout"].Replace("jpg", "png");
            byte[] rsp;
            if (!File.Exists($"Files/res/hideout/{Hideout}"))
            {
                rsp = File.ReadAllBytes($"Files/res/noimage/hideout.png");
            }
            else
            {
                rsp = File.ReadAllBytes($"Files/res/hideout/{Hideout}");
            }
            session.SendResponse(session.Response.MakeGetResponse(rsp).SetHeader("Content-Type", "image/png"));
            return true;
        }

        [HTTP("GET", "/files/quest/icon/{quest}")]
        public static bool GetFilesQuestIcon(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string quest = session.HttpParam["quest"].Replace("jpg", "png");
            byte[] rsp;
            if (!File.Exists($"Files/res/quest/{quest}"))
            {
                rsp = File.ReadAllBytes($"Files/res/noimage/quest.png");
            }
            else
            {
                rsp = File.ReadAllBytes($"Files/res/quest/{quest}");
            }
            session.SendResponse(session.Response.MakeGetResponse(rsp).SetHeader("Content-Type", "image/png"));
            return true;
        }

    }
}
