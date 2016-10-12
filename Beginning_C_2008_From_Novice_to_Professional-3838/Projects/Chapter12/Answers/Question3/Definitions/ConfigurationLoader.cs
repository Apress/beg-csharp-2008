using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Definitions {
    // What you need to realize is that the configuration information
    // that expected to load Impl1, and Impl2 are now delegated to the
    // appropriate implementations assembly. Thus the old code that
    // expected to use those configuration items still works.
    // The posed question is an example where you need to update the 
    // entire infrastructure to use a new infrastructure, but you don't
    // want to rewrite all of the old code
    public class ConfigurationLoader {
        private static ConfigurationLoader _instance = new ConfigurationLoader();

        DynamicDirectoryLoader _adaptedImplementation;

        public static ConfigurationLoader Instance {
            get {
                return _instance;
            }
        }
        public void Load() {
            _adaptedImplementation = DynamicDirectoryLoader.Instance;
        }
        public RequestedType Instantiate<RequestedType>(string identifier) {
            return _adaptedImplementation.Instantiate<RequestedType>(identifier);
        }
        public RequestedType InstantiateStrongType<RequestedType>(string identifier) {
            return _adaptedImplementation.Instantiate<RequestedType>(identifier);
        }
        public void LoadCustomSection() {
            Load();
        }
    }
}
