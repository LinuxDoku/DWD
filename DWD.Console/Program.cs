using System.Linq;
using DWD.Crawler.Provider;

namespace DWD.Console {
    class Program {
        static void Main(string[] args) {
            var temperatureProvider = new AirTemperatureProvider();
            var charting = new Charting.Charting(10000, 100);
            charting.AddData(temperatureProvider.GetByStationName("Reimlingen").ToDictionary(x => x.MeasuredAt, x => x.Temperature));
            charting.SaveToPng("chart.png");

            foreach (var temperature in temperatureProvider.GetByStationName("Reimlingen")) {
                System.Console.WriteLine("{0}: {1} °C", temperature.Station.Name, temperature.Temperature);
            }


            System.Console.ReadLine();

        }
    }
}