using System.Collections.Generic;
using DWD.Crawler.Contract;
using DWD.Crawler.Model;

namespace DWD.Crawler.Provider {
    public class StationProvider : IProvider<Station> {
        public IEnumerable<Station> Get() {
            return new List<Station> {
                {new Station {
                    StationId = 3621,
                    Name = "Reimlingen"
                }}
            };
        }
    }
}