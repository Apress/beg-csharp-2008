using System.Web;
using Devspace.Trader.Common.Automators;

namespace Devspace.Trader.Common.Web
{
    public interface IResolver: IDebug {
        void ProcessRequest( HttpApplication app);
        void FactoryLoader( IFactory< string> factory);
    }
}
