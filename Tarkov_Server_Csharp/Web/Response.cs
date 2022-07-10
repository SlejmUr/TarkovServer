using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarkov_Server_Csharp.Web
{
    internal class Response
    {

        public static string GetBody(string Data, int errorcode = 0, string errormsg = "null")
        {
            var Stuff =  "{\"err\":"+ errorcode + ",\"errmsg\":"+ errormsg + ",\"data\":" + Data + "}";
            return Stuff;
        }
        public static string NullResponse()
        {
            return GetBody(null);
        }
        public static string EmptyArrayResponse()
        {
            return GetBody("[]");
        }
    }
}
