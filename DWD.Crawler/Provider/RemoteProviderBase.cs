using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using DWD.Crawler.Contract;
using DWD.Crawler.Util;

namespace DWD.Crawler.Provider {
    /// <summary>
    /// Base class for remote providers. Use this if you need FTP, Unzip and 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RemoteProviderBase<T> : IProvider<T> {
        protected abstract string Url { get; }
        protected abstract IParser<T> GetParser();

        public virtual IEnumerable<T> Get() {
            return Get(Url);
        }

        public virtual IEnumerable<T> Get(string url) {
            IEnumerable<T> list = null;

            using (var responseStream = Download(url)) {
                var fileStream = Unzip(responseStream);
                list = GetParser().Parse(fileStream);
            }

            return list;
        } 

        protected virtual Stream Download(string url) {
            var request = (FtpWebRequest)WebRequest.Create(Url);
            var response = request.GetResponse();

            return response.GetResponseStream();
        }

        protected virtual Stream Unzip(Stream stream) {
            return ZipUtil.Unzip(stream, x => ShouldUnzipFile(x.Name));
        }

        protected virtual bool ShouldUnzipFile(string fileName) {
            return true;
        }
    }
}