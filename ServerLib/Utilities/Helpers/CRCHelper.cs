using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Utilities.Helpers
{
    public class CRCHelper
    {
        /*
            IDEA based from: nohurry
         
            Check header for if-none-match
            if exist store temp the value.
        
            HASH every static response with CRC32.
            store hash a db or json.

            if stored crc32 same as temp stored response with 304 Response code.
         */

    }
}
