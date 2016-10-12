namespace Devspace.Trader.Common.Web
{
    public class ResolverFactory {
        private static IResolver resolver = new AssemblyLoaderHandler();
        
        public static IResolver GetResolver() {
            return resolver;
        }
    }
}
