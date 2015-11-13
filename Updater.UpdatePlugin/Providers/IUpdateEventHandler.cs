using System;

namespace Updater.UpdatePlugin.Providers
{
    public interface IUpdateEventHandler
    {
        event Func<bool> HaveUpdates;
        event Action CanContinue;
    }
}