using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Definitions {
    public sealed class DynamicDirectoryLoader {
        private static DynamicDirectoryLoader _instance;

        private string _path;
        private string[] _pluginEntries;

        private class PreLoadedAssemblies {
            public Assembly LoadedAssembly;
            public ISupportedTypes SupportedTypes;
        }

        private List<PreLoadedAssemblies> _preLoadedAssemblies = new List<PreLoadedAssemblies>();

        public string PluginPath {
            get {
                return _path;
            }
        }

        // Constructor is made private so that only 
        // the class can instantiate itself
        private DynamicDirectoryLoader() {
            string rootPath = ConfigurationManager.AppSettings["rootPath"];

            _path = rootPath;
            _pluginEntries = Directory.GetFileSystemEntries(_path, "*.dll");
            foreach (string path in _pluginEntries) {
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(path);
                Assembly assembly = Assembly.Load(assemblyName);
                ISupportedTypes supportedTypes = (assembly.CreateInstance("ReferenceSupportedTypes"))
                    as ISupportedTypes;

                _preLoadedAssemblies.Add(new PreLoadedAssemblies {
                    LoadedAssembly = assembly,
                    SupportedTypes = supportedTypes
                });
            }
        }
        public static DynamicDirectoryLoader Instance {
            get {
                Monitor.Enter(typeof(DynamicDirectoryLoader));
                if (_instance == null) {
                    _instance = new DynamicDirectoryLoader();
                }
                Monitor.Exit(typeof(DynamicDirectoryLoader));
                return _instance;
            }
        }
        public RequestedType Instantiate<RequestedType>(string @class) {
            foreach (PreLoadedAssemblies preLoadedAssembly in _preLoadedAssemblies) {
                Object @object;

                @object = preLoadedAssembly.LoadedAssembly.CreateInstance(@class);
                if (@object != null) {
                    RequestedType retval;
                    try {
                        retval = (RequestedType)@object;
                        return retval;
                    }
                    catch (Exception e) {
                        ;
                    }
                }
                else if (preLoadedAssembly.SupportedTypes != null) {
                    if (preLoadedAssembly.SupportedTypes.IsTypeSupported(@class)) {
                        return preLoadedAssembly.SupportedTypes.Instantiate<RequestedType>(@class);
                    }
                }
            }
            return default(RequestedType);
        }
    }
}

