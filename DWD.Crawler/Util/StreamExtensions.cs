using System.IO;

namespace DWD.Crawler.Util {
    public static class StreamExtensions {
        public static void Reset(this Stream stream) {
            if (stream.CanSeek) {
                stream.Seek(0, SeekOrigin.Begin);
            }
        }
    }
}