using System.Linq;
using DWD.Crawler.Parser;
using NUnit.Framework;

namespace DWD.Crawler.Tests.Parser {
    [TestFixture]
    public class StationParserTests {
        private const string StationText = @"Stations_id von_datum bis_datum Stationshoehe geoBreite geoLaenge Stationsname Bundesland
----------- --------- --------- ------------- --------- --------- ----------------------------------------- ----------
          3 19500401 20110331            202     50.7827    6.0941 Aachen                                   Nordrhein-Westfalen                                                                         
         44 20070401 20160105             44     52.9335    8.2370 Großenkneten                             Niedersachsen";

        [Test]
        public void Should_Parse_Station() {
            var stationParser = new StationParser();
            var result = stationParser.Parse(StationText.ToStream());

            Assert.AreEqual(2, result.Count());

            // first row
            Assert.AreEqual(3, result.First().StationId);
            Assert.AreEqual("Nordrhein-Westfalen", result.First().State);
            Assert.AreEqual("Aachen", result.First().Name);
            Assert.AreEqual(50.7827m, result.First().GeoLatitude);
            Assert.AreEqual(6.0941m, result.First().GeoLongitude);

            // second row
            Assert.AreEqual(44, result.Last().StationId);
            Assert.AreEqual("Niedersachsen", result.Last().State);
            Assert.AreEqual("Großenkneten", result.Last().Name);
            Assert.AreEqual(52.9335, result.Last().GeoLatitude);
            Assert.AreEqual(8.2370m, result.Last().GeoLongitude);
        }
    }
}