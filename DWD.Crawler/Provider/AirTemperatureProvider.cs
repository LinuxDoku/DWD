using System.Collections.Generic;
using System.Net;
using DWD.Crawler.Contract;
using DWD.Crawler.Model;
using DWD.Crawler.Parser;
using DWD.Crawler.Util;

namespace DWD.Crawler.Provider {
    public class AirTemperatureProvider : IRemoteProvider<AirTemperature> {
        protected const string Url = "ftp://ftp-cdc.dwd.de/pub/CDC/observations_germany/climate/hourly/air_temperature/recent/stundenwerte_TU_03621_akt.zip";

        private readonly IProvider<Station> _stationProvider;
        private AirTemperatureParser _parser;

        public AirTemperatureProvider() : this(new StationProvider()) {}

        public AirTemperatureProvider(IProvider<Station> stationProvider) {
            _stationProvider = stationProvider;
        }

        public IParser<AirTemperature> GetParser() {
            if (_parser == null) {
                _parser = new AirTemperatureParser(_stationProvider);
            }
            return _parser;
        }

        public IEnumerable<AirTemperature> Get() {
            var request = (FtpWebRequest)WebRequest.Create(Url);
            var response = request.GetResponse();
            var fileStream = ZipUtil.Unzip(response.GetResponseStream(), x => x.Name.StartsWith("produkt_temp_Terminwerte_"));

            var temperatures = GetParser().Parse(fileStream);
            response.Close();

            return temperatures;
        }
    }
}