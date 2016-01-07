using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DWD.Crawler.Contract;
using DWD.Crawler.Model;
using DWD.Crawler.Util;

namespace DWD.Crawler.Parser {
    /// <summary>
    /// Parse the raw station data to station models.
    /// </summary>
    public class StationParser : IParser<Station> {
        /** example data:

        Stations_id von_datum bis_datum Stationshoehe geoBreite geoLaenge Stationsname Bundesland
        ----------- --------- --------- ------------- --------- --------- ----------------------------------------- ----------
                  3 19500401 20110331            202     50.7827    6.0941 Aachen                                   Nordrhein-Westfalen                                                                         
                 44 20070401 20160105             44     52.9335    8.2370 Großenkneten                             Niedersachsen
        
        **/

        public IEnumerable<Station> Parse(Stream contentStream) {
            contentStream.Reset();
            var stations = new List<Station>();
            var reader = new StreamReader(contentStream);
            var buffer = "";
            var lineCounter = 0;

            while (!reader.EndOfStream && (buffer = reader.ReadLine()) != null) {
                if (buffer.Length <= 1) {
                    break;
                }
           
                if (lineCounter > 1) {
                    stations.Add(CreateFromLine(buffer));
                }

                lineCounter++;

            }

            return stations;
        }

        protected Station CreateFromLine(string line) {
            return new Station {
                StationId = int.Parse(line.Substring(0, 11).Trim()),
                GeoLatitude = decimal.Parse(line.Substring(46, 10).Trim(), CultureInfo.InvariantCulture),
                GeoLongitude = decimal.Parse(line.Substring(56, 10).Trim(), CultureInfo.InvariantCulture),
                Name = line.Substring(66, 41).Trim(),
                State = line.Substring(108, line.Length - 108).Trim()
            };
        }
    }
}