using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace DWD.Crawler.Util {
    public static class ZipUtil {
        public static Stream Unzip(Stream zipStream, Func<ZipArchiveEntry, bool> selector) {
            Stream stream;

            // copy zipStream if the stream is non-seekable (see mono bug #30686)
            if (!zipStream.CanSeek) {
                stream = new MemoryStream();
                zipStream.CopyTo(stream);
            }
            else {
                stream = zipStream;
            }

            var unzipped = new MemoryStream();
            var writer = new StreamWriter(unzipped);

            using (var archive = new ZipArchive(stream, ZipArchiveMode.Read)) {
                var entry = archive.Entries.First(selector);
                writer.Write(new StreamReader(entry.Open()).ReadToEnd());
            }

            return unzipped;
        }
    }
}