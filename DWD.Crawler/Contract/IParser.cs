using System.Collections.Generic;
using System.IO;

namespace DWD.Crawler.Contract {
    public interface IParser<T> {
        IEnumerable<T> Parse(Stream contentStream);
    }
}