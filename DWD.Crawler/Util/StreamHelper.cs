using System.IO;

namespace DWD.Crawler.Util {
    public static class StreamHelper {
        public static void Reset(this Stream stream) {
            if (stream.CanSeek) {
                stream.Seek(0, SeekOrigin.Begin);
            }
        }
    }
}