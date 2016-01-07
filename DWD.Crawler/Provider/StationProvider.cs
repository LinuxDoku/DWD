using System.Collections.Generic;
using DWD.Crawler.Contract;
using DWD.Crawler.Contract.Provider;
using DWD.Crawler.Model;
using DWD.Crawler.Parser;

namespace DWD.Crawler.Provider {
    public class StationProvider : RemoteProviderBase<Station>, IStationProvider {
        private const string Url = "ftp://ftp-cdc.dwd.de/pub/CDC/observations_germany/climate/hourly/air_temperature/recent/TU_Stundenwerte_Beschreibung_Stationen.txt";

        public IEnumerable<Station> GetAll() => Get(Url);

        protected override IParser<Station> GetParser() => new StationParser();
    }
}