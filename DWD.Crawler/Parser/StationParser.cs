using System.Collections.Generic;
using System.IO;
using System.Linq;
using DWD.Crawler.Contract;
using DWD.Crawler.Model;
using DWD.Crawler.Util;

namespace DWD.Crawler.Parser {
    public class StationParser : IParser<Station> {
        public IEnumerable<Station> Parse(Stream contentStream) {
            contentStream.Reset();
            var stations = new List<Station>();
            var map = new Dictionary<short, short>(); // map with index and length per col
            var reader = new StreamReader(contentStream);
            var buffer = "";
            var lineCounter = 0;

            while(!reader.EndOfStream && (buffer = reader.ReadLine()) != null) {
                if (buffer.Length <= 1) {
                    break;
                }

                // data lines
                if (lineCounter > 1) {
                    stations.Add(new Station {
                        StationId = int.Parse(GetWithMap(buffer, 0, map)),
                        Name = GetWithMap(buffer, 6, map)
                    });
                }
                // second line contains the column width as "=", separated with spaces
                else if (lineCounter == 1) {
                    var splitted = buffer.Split(' ');
                    for (int i = 0; i < splitted.Length; i++) {
                        map.Add((short)i, (short)(splitted[i].Length + 1));
                    }
                }

                lineCounter++;
            }

            return stations;
        }

        protected string GetWithMap(string input, short index, Dictionary<short, short> map) {
            var start = map.OrderBy(x => x.Key).Where(x => x.Key < index).Sum(x => x.Value);
            return input.Substring(start, map[index]).Trim();
        }
    }
}