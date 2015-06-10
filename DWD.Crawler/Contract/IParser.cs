using System.Collections.Generic;
using System.IO;

namespace DWD.Crawler.Contract {
    /// <summary>
    /// The parser converts the received data to concrete models.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IParser<T> {
        /// <summary>
        /// Parse the received stream line by line to a list of the type T.
        /// </summary>
        /// <param name="contentStream"></param>
        /// <returns></returns>
        IEnumerable<T> Parse(Stream contentStream);
    }
}