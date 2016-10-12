using System;
using System.Reflection;
using Devspace.Trader.Common.Automators;

namespace Devspace.Commons.Loader {
    public class SimpleAssemblyLoader : IFactory<string>  {
        Assembly _assembly;
        
        public SimpleAssemblyLoader(string path) {
            _assembly = Assembly.Load(AssemblyName.GetAssemblyName(path));
        }
        public type Instantiate< type>(string typeidentifier) where type: class {
            return _assembly.CreateInstance(typeidentifier) as type;
        }
    }
        
    public class SimpleAssemblyLoaderFactory {
        public static IFactory<string> Instantiate( string path) {
            return new SimpleAssemblyLoader( path);
        }
    }
}
