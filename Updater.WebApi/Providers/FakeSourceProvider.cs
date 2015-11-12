using System;
using System.IO;
using System.Linq;

namespace Updater.WebApi.Providers
{
    public class FakeSourceProvider : ISourceProvider
    {
        private const string SourcePath = @"E:\temp\";
        private const string SearchPattern = @"*.zip";

        public string GetVersion()
        {
            var fileName = GetFileName();
            if (String.IsNullOrWhiteSpace(fileName))
            {
                return null;
            }

            return PackageNameProvider.GetVersion(fileName);
        }

        public Stream GetFileStream()
        {
            var fileName = GetFileName();
            return new FileStream(fileName, FileMode.Open);
        }

        private string GetFileName()
        {
            return Directory.GetFiles(SourcePath, SearchPattern).OrderByDescending(x => x).FirstOrDefault();
        }
    }
}