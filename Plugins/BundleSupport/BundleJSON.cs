namespace BundleSupport
{
    internal class BundleJSON
    {
        internal class Bundle
        {
            public string Key { get; }
            public string Path { get; set; }
            public string[] DependencyKeys { get; }

            public Bundle(string key, string path, string[] dependencyKeys)
            {
                Key = key;
                Path = path;
                DependencyKeys = dependencyKeys;
            }
        }

        internal class BundleManifest
        {
            public class Bundle
            {
                public string key { get; set; }
                public List<string> dependencyKeys { get; } = new();
            }
            public List<Bundle> manifest = new();
        }
        /*
        {
           "key": "MYMOD/BUNDLE1.bundle",
           "path": "/files/bundle/MYMOD/BUNDLE1.bundle",
           "dependencyKeys": [
              "shaders"
            ]
        }
         */
    }
}
