using System.Collections.Generic;
using System.IO;
using System.Linq;
using DWD.Crawler.Contract;
using DWD.Crawler.Model;
using DWD.Crawler.Util;

namespace DWD.Crawler.Parser {
    public class AirTemperatureParser : ParserBase, IParser<AirTemperature> {
        private readonly IEnumerable<Station> _stationList;
        public AirTemperatureParser(IEnumerable<Station> stationList) {
            _stationList = stationList;
        }

        public IEnumerable<AirTemperature> Parse(Stream contentStream) {
            contentStream.Reset();
            var reader = new StreamReader(contentStream);
            var temperatures = new List<AirTemperature>();
            string buffer = "";

            while ((buffer = reader.ReadLine()) != null) {
                var temperature = ParseLine(buffer);
                if (temperature != null) {
                    temperatures.Add(temperature);
                }
            }

            return temperatures;
        }

        protected AirTemperature ParseLine(string line) {
            var splitted = line.Split(';');
            if (!splitted.Any() || splitted[0] == "STATIONS_ID" || splitted.Length < 6) {
                return null;
            }

            var temperature = new AirTemperature {
                Station = _stationList.First(x => x.StationId == int.Parse(splitted[0])),
                MeasuredAt = ParseDate(splitted[1]),
                Temperature = ParseDecimal(splitted[4].Trim()),
                RelativeHumidity = ParseDecimal(splitted[5].Trim())
            };

            return temperature;
        }
    }
}