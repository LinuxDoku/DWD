using System.Collections.Generic;
using System.IO;
using System.Net;
using DWD.Crawler.Contract;
using DWD.Crawler.Util;

namespace DWD.Crawler.Provider {
    /// <summary>
    /// Base class for remote providers. Use this if you need FTP, Unzip and 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RemoteProviderBase<T> {
        protected abstract IParser<T> GetParser();

        protected virtual IEnumerable<T> Get(string url) {
            IEnumerable<T> list = null;

            using (var responseStream = Download(url)) {
                var stream = responseStream;

                if (HasArchiveFileEnding(url)) {
                    stream = Unzip(responseStream);
                }

                list = GetParser().Parse(stream);
            }

            return list;
        } 

        protected virtual Stream Download(string url) {
            var request = (FtpWebRequest)WebRequest.Create(url);
            var response = request.GetResponse();

            return response.GetResponseStream();
        }

        protected virtual Stream Unzip(Stream stream) {
            return ZipUtil.Unzip(stream, x => ShouldUnzipFile(x.Name));
        }

        protected virtual bool ShouldUnzipFile(string fileName) {
            return true;
        }

        protected virtual bool HasArchiveFileEnding(string url) {
            return url.EndsWith(".zip");
        }
    }
}