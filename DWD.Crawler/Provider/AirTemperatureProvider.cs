﻿using System.Collections.Generic;
using System.Linq;
using DWD.Crawler.Contract;
using DWD.Crawler.Contract.Provider;
using DWD.Crawler.Model;
using DWD.Crawler.Parser;

namespace DWD.Crawler.Provider {
    public class AirTemperatureProvider : RemoteProviderBase<AirTemperature>, IAirTemperatureProvider {
        private const string UrlPattern = "ftp://ftp-cdc.dwd.de/pub/CDC/observations_germany/climate/hourly/air_temperature/recent/stundenwerte_TU_[STATION_ID]_akt.zip";

        private readonly IEnumerable<Station> _stationList;
        private AirTemperatureParser _parser;

        public AirTemperatureProvider() : this(new StationProvider()) {}

        public AirTemperatureProvider(IStationProvider stationProvider) {
            _stationList = stationProvider.GetAll();
        }

        public IEnumerable<AirTemperature> GetByStationId(int stationId) {
            return Get(GenerateUrl(stationId));
        }

        public IEnumerable<AirTemperature> GetByStationName(string stationName) {
            var station = _stationList.FirstOrDefault(x => x.Name == stationName);

            if (station == null) {
                return null;
            }

            return GetByStationId(station.StationId);
        }

        protected string GenerateUrl(int stationId) {
            return UrlPattern.Replace("[STATION_ID]", stationId.ToString("D5"));
        }

        protected override IParser<AirTemperature> GetParser() {
            return _parser ?? (_parser = new AirTemperatureParser(_stationList));
        }

        protected override bool ShouldUnzipFile(string fileName) {
            return fileName.StartsWith("produkt_temp_Terminwerte_");
        }
    }
}