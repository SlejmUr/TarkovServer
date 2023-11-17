using ServerLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleSupport
{
    internal class BundleManager
    {
        public static List<BundleJSON.Bundle> Bundles = new List<BundleJSON.Bundle>();
        public static void LoadAllBundles()
        { 
            var curDir = Directory.GetCurrentDirectory();
            Debug.PrintInfo(curDir);
            /*
                {CURDIR} is where the Server exe will exist (hopefully?).
                BUNDLES must be in place:
                {CURDIR}/Bundles/MODNAME/bundlename.bundle
                Maybe a json exist in the
                {CURDIR}/Bundles/MODNAME ?
                read that and it contains dependency? name? what it has???
             */
        }
    }
}
