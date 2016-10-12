using Devspace.Trader.Common.Automators;
using System.Collections.Generic;
using System;
using Devspace.Trader.Common.Tracer;

namespace Devspace.Trader.Common.Loader {
    public class MultipleLoaderHandler : IDebug {
        #region Debug
        private bool _debug;
        public bool Debug {
            get {
                return _debug;
            }
            set {
                _debug = value;
            }
        }
        #endregion
        
        List< IFactory< string>> _factoryList = new List< IFactory< string>>();
        IDictionary< string, object> _cachedObjects = new SortedDictionary< string, object>();
        
        public void AddFactory(IFactory< string> factory) {
            _factoryList.Add(factory);
        }
        public Type InstantiateType< Type>( string identifier, bool useCache) where Type: class{
            Type obj;
            if( Debug) {
                GenerateOutput.Write( "MultipleLoaderHandler.InstantiateType", "identifier (" + identifier + ")");
            }
            if( _cachedObjects.ContainsKey( identifier)) {
                if( Debug) {
                    GenerateOutput.Write( "MultipleLoaderHandler.InstantiateType", "Is in cache");
                }
                return _cachedObjects[ identifier] as Type;
            }
            foreach( IFactory< string> factory in _factoryList) {
                obj = factory.Instantiate< Type>( identifier);
                if( obj != null) {
                    if( useCache) {
                        if( Debug) {
                            GenerateOutput.Write( "MultipleLoaderHandler.InstantiateType", "Instantiated and added to cache");
                        }
                        _cachedObjects.Add( identifier, obj);
                    }
                    else if( Debug) {
                        GenerateOutput.Write( "MultipleLoaderHandler.InstantiateType", "Instantiated not added to cache");
                    }
                    return obj;
                }
            }
            throw new NotSupportedException( "Identifier (" + identifier + ") could not be instantiated in the loaded assemblies");
        }
        public void AddToCache( string identifier, object obj) {
            if( ! _cachedObjects.ContainsKey( identifier)) {
                if( Debug) {
                    GenerateOutput.Write( "MultipleLoaderHandler.AddToCache", "Added (" + identifier + ") to cache");
                }
                _cachedObjects.Add( identifier, obj);
            }
        }
    }
}
