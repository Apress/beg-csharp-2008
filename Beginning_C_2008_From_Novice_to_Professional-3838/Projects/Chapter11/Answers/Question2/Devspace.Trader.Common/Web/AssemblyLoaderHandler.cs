using System;
using System.Web;
using Devspace.Trader.Common.Automators;
using Devspace.Trader.Common.Loader;
using Devspace.Trader.Common.Tracer;

namespace Devspace.Trader.Common.Web
{
    class AssemblyLoaderHandler : IResolver {
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
        
        MultipleLoaderHandler _loader = new MultipleLoaderHandler();
        
        protected String[] TokenizeURL( HttpRequest request) {
            string path = request.Path;
            if( Debug) {
                GenerateOutput.Write( "DynamicRedirectHandler.TokenizeURL", path);
            }
            return path.Split( '/');
        }
        
        public void FactoryLoader( IFactory< string> factory) {
            _loader.AddFactory( factory);
        }
        public void ProcessRequest(HttpApplication app) {
            string[] tokens = TokenizeURL( app.Context.Request);

            for( int c1 = 0; c1 < tokens.Length; c1 ++) {
                if (tokens[c1] == "ntservices") {

                    IHttpHandler handler = null;
                    string toSearch = tokens[c1 + 1] + "." + tokens[c1 + 2];
                    _loader.Debug = Debug;
                    handler = _loader.InstantiateType<IHttpHandler>(toSearch, false);
                    if (handler != null) {
                        if (handler.IsReusable) {
                            _loader.AddToCache(toSearch, handler);
                        }
                        handler.ProcessRequest(app.Context);
                        app.CompleteRequest();
                    }
                }
            }
        }
    }
    
}
