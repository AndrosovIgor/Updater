using System;
using System.IO;

namespace Updater.UpdatePlugin.Providers
{
    public interface ISourceProvider
    {
        bool UpdatesAvailable();
        event Action HaveUpdates;
        Stream GetPackage();
    }
}