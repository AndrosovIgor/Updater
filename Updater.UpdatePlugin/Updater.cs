using Updater.UpdatePlugin.Providers;

namespace Updater.UpdatePlugin
{
    public sealed class Updater
    {
        public static void Init(
            ISecurityProvider securityProvider,
            bool alwaysCheck,
            IUpdateEventHandler updateEventHandler,
            params ISourceProvider[] sourceProviders)
        {
        }
    }
}