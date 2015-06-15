using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace DWD.Crawler.Util {
    public static class ZipUtil {
        public static Stream Unzip(Stream zipStream, Func<ZipArchiveEntry, bool> selector) {
			var streamCopy = new MemoryStream();
			zipStream.CopyTo (streamCopy);
            var unzipped = new MemoryStream();
            var writer = new StreamWriter(unzipped);

			using (var archive = new ZipArchive(streamCopy, ZipArchiveMode.Read)) {
                var entry = archive.Entries.First(selector);
                writer.Write(new StreamReader(entry.Open()).ReadToEnd());
            }

            return unzipped;
        }
    }
}