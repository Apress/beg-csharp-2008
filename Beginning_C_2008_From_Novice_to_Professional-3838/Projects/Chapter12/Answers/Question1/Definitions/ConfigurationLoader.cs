using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace Definitions {
    public class LoaderSection : ConfigurationSection {
        static ConfigurationProperty _propEasyName;
        static ConfigurationProperty _propTypeName;
        static ConfigurationProperty _propAssemblyName;
        static ConfigurationPropertyCollection _properties;

        static LoaderSection() {
            _propEasyName = new ConfigurationProperty(
                                    "easyname", typeof(string),
                                null, ConfigurationPropertyOptions.IsRequired);
            _propTypeName = new ConfigurationProperty(
                                    "typename", typeof(string),
                                null, ConfigurationPropertyOptions.IsRequired);
            _propAssemblyName = new ConfigurationProperty(
                                    "assemblyname", typeof(string),
                                null, ConfigurationPropertyOptions.IsRequired);
            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_propEasyName);
            _properties.Add(_propTypeName);
            _properties.Add(_propAssemblyName);
        }
        [ConfigurationProperty("easyname", IsRequired = true)]
        public string EasyName {
            get {
                return (string)base[_propEasyName];
            }
        }
        [ConfigurationProperty("typename", IsRequired = true)]
        public string TypeName {
            get {
                return (string)base[_propTypeName];
            }
        }
        [ConfigurationProperty("assemblyname", IsRequired = true)]
        public string AssemblyName {
            get {
                return (string)base[_propAssemblyName];
            }
        }

    }

    public class ConfigurationLoader {
        private class ConfigurationInfo {
            public string AssemblyName;
            public string TypeName;
            public string EasyName;
        }
        Dictionary<string, ConfigurationInfo> _availableTypes;

        static ConfigurationLoader _instance;
        static ConfigurationLoader() {
            _instance = new ConfigurationLoader();
        }
        ConfigurationLoader() {
            _availableTypes = new Dictionary<string, ConfigurationInfo>();
        }

        public static ConfigurationLoader Instance {
            get {
                return _instance;
            }
        }

        public void Load() {
            string value = ConfigurationManager.AppSettings["assemblies"];
            string[] values = value.Split(',');
            for (int c1 = 0; c1 < values.Length; c1 += 3) {
                _availableTypes.Add(values[c1],
                    new ConfigurationInfo {
                        EasyName = values[c1],
                        TypeName = values[c1 + 1],
                        AssemblyName = values[c1 + 2]
                    });
            }
        }

        public void LoadCustomSection() {
            LoaderSection loader = ConfigurationManager.GetSection("loader") as LoaderSection;
            if (loader != null) {
                _availableTypes.Add(loader.EasyName,
                    new ConfigurationInfo {
                        EasyName = loader.EasyName,
                        TypeName = loader.TypeName,
                        AssemblyName = loader.AssemblyName
                    });
            }
        }
        public RequestedType Instantiate<RequestedType>(string identifier) {
            if (_availableTypes.ContainsKey(identifier)) {
                ConfigurationInfo info = _availableTypes[identifier];
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(info.AssemblyName);
                Console.WriteLine("assemblyname(" + assemblyName + ")");
                Assembly assembly = Assembly.Load(assemblyName);

                object obj = assembly.CreateInstance(info.TypeName);
                return (RequestedType)obj;
            }
            else {
                throw new ArgumentException("identifier (" + identifier + ") is not a listed type");
            }
        }
        public RequestedType InstantiateStrongType<RequestedType>(string identifier) {
            if (_availableTypes.ContainsKey(identifier)) {
                ConfigurationInfo info = _availableTypes[identifier];
                string value = ConfigurationManager.AppSettings[identifier];
                AssemblyName assemblyName = new AssemblyName(value);
                Console.WriteLine("assemblyname(" + assemblyName + ")");
                Assembly assembly = Assembly.Load(assemblyName);

                object obj = assembly.CreateInstance(info.TypeName);
                return (RequestedType)obj;
            }
            else {
                throw new ArgumentException("identifier (" + identifier + ") is not a listed type");
            }
        }
        public override string ToString() {
            string retval = "";
            foreach (string identifier in _availableTypes.Keys) {
                ConfigurationInfo info = _availableTypes[identifier];
                retval += "{" + info.EasyName + "," + info.TypeName + "," + info.AssemblyName + "}";
            }
            return retval;
        }
    }
}
