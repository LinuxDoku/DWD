using System.Collections.Generic;
using DWD.Crawler.Model;

namespace DWD.Crawler.Contract.Provider {
    public interface IAirTemperatureProvider {
        IEnumerable<AirTemperature> GetByStationId(int stationId);
        IEnumerable<AirTemperature> GetByStationName(string stationName);
    }
}