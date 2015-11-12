using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using Updater.WebApi.Providers;

namespace Updater.WebApi.Api
{
    [Authorization]
    public sealed class UpdateController : ApiController
    {
        private readonly ISourceProvider _sourceProvider;

        public UpdateController(ISourceProvider sourceProvider)
        {
            _sourceProvider = sourceProvider;
        }

        [HttpPost]
        [Route("checkversion")]
        public HttpResponseMessage CheckVersion(CheckVersionInVm vm)
        {
            if (vm == null || String.IsNullOrWhiteSpace(vm.Version))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
            return Request.CreateResponse(HttpStatusCode.OK, new CheckVersionOutVm(
                CompareVersions(vm.Version, _sourceProvider.GetVersion()),
                SystemConfiguration.RefreshTimeout));
        }

        [HttpPost]
        [Route("getfile")]
        public HttpResponseMessage GetFile()
        {
            var stream = _sourceProvider.GetFileStream();

            var response = Request.CreateResponse(HttpStatusCode.OK, new FileVm(GetHash(stream), SystemConfiguration.AppName));
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "updates.zip";
            return response;
        }

        #region  Helpers

        private bool CompareVersions(string clientVersion, string serverVersion)
        {
            var clientV = new Version(clientVersion);
            var serverV = new Version(serverVersion);

            return clientV.CompareTo(serverV) < 0;
            /*
             clientV < serverV = -1
             clientV = serverV = 0
             clientV > serverV = 1
             */
        }

        private string GetHash(Stream stream)
        {
            MD5 md5 = MD5.Create();
            try
            {
                stream.Position = 0;
                return Encoding.UTF8.GetString(md5.ComputeHash(stream));
            }
            finally
            {
                md5.Dispose();
                stream.Position = 0;
            }
        }

        #endregion
    }
}