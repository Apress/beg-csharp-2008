using System;

namespace Definitions {
    
    public interface IFactory< IdentifierType> {
        Type Instantiate< Type>(IdentifierType identifier) where Type: class;
    }

    public class DynamicFactory {
        IFactory<string> _loader = null;
        IFactory<string> _factory = null;
        
        public DynamicFactory(IFactory<string> loader) {
            _loader = loader;
            _factory = _loader.Instantiate<IFactory<string>>("Devspace.Factory");
        }
        public type Instantiate< type>(string typeidentifier) where type: class {
            return _factory.Instantiate< type>(typeidentifier);
        }
    }
}
