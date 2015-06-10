using System.IO;
using DWD.Crawler.Contract;
using DWD.Crawler.Model;
using DWD.Crawler.Parser;

namespace DWD.Crawler.Provider {
    public class StationProvider : RemoteProviderBase<Station> {
        private readonly string _url = "ftp://ftp-cdc.dwd.de/pub/CDC/observations_germany/climate/hourly/air_temperature/recent/TU_Stundenwerte_Beschreibung_Stationen.txt";

        protected override string Url {
            get { return _url; }
        }

        protected override IParser<Station> GetParser() {
            return new StationParser();
        }

        protected override Stream Unzip(Stream stream) {
            // the txt is not zipped
            return stream;
        }

        protected override bool ShouldUnzipFile(string fileName) {
            return true;
        }
    }
}