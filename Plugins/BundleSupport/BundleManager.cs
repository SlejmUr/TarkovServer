using Newtonsoft.Json;
using ServerLib.Controllers;
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
        public static void LoadAllBundles(object nothing)
        { 
            var curDir = Directory.GetCurrentDirectory();
            Debug.PrintInfo(curDir);
            string bundlePath = Path.Combine(curDir, "Bundles");
            if (!Directory.Exists(bundlePath))
                return;

            var moredir = Directory.GetDirectories(bundlePath);
            foreach (var modname in moredir)
            {
                Debug.PrintInfo(modname);
                if (!File.Exists("bundles.json"))
                    break;

                var bundleManifest = JsonConvert.DeserializeObject<BundleJSON.BundleManifest>(File.ReadAllText("bundles.json"));

                var files = Directory.GetFiles(modname, "*.bundle", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    Debug.PrintInfo(file);
                    //BundleJSON.Bundle bundle = new(modname.Replace(bundlePath + "\\",""), );
                }
            }
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
