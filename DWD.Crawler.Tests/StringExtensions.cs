using System.IO;
using System.Text;

namespace DWD.Crawler.Tests {
    public static class StringExtensions {
        public static Stream ToStream(this string @string) {
            return new MemoryStream(Encoding.UTF8.GetBytes(@string));
        }
    }
}