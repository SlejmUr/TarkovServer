using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    internal class ServerController
    {
        // Map stuff
        public static bool RequestLoadMap(string map)
        {
            if (File.Exists($"TestServer/{map}.json"))  //Interactibles
            {
                return true;
            }
            return false;
        }

        public static string GetMap(string map)
        {
            return File.ReadAllText($"TestServer/{map}.json");
        }
    }
}
