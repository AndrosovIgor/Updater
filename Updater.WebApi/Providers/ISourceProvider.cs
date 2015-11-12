using System.IO;

namespace Updater.WebApi.Providers
{
    public interface ISourceProvider
    {
        string GetVersion();
        Stream GetFileStream();
    }
}