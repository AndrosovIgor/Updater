namespace Updater.WebApi.Api
{
    public sealed class FileVm
    {
        public FileVm(string hash, string appName)
        {
            Hash = hash;
            AppName = appName;
        }

        public string Hash { get; set; }
        public string AppName { get; set; }
    }
}