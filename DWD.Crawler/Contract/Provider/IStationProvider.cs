using System.Collections.Generic;
using DWD.Crawler.Model;

namespace DWD.Crawler.Contract.Provider {
    public interface IStationProvider {
        IEnumerable<Station> GetAll();
    }
}