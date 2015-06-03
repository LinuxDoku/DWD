using System.Collections.Generic;

namespace DWD.Crawler.Contract {
    public interface IProvider<T> {
        IEnumerable<T> Get();
    }
}