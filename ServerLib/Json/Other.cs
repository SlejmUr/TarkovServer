using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Json
{
    public class Other
    {
        public class AmmoItems
        {
            public string _id { get; set; }
            public string _tpl { get; set; }
            public Upd upd { get; set; }
        }

        public class Upd
        {
            public int StackObjectsCount { get; set; }
        }
    }
}
