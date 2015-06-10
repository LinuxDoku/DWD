using System.Linq;
using DWD.Crawler.Provider;

namespace DWD.Console {
    class Program {
        static void Main(string[] args) {
            var temperatureProvider = new AirTemperatureProvider();
            var charting = new Charting.Charting();
            var temperatures = temperatureProvider.GetByStationName("Reimlingen");

            charting.AddData(temperatures.ToDictionary(x => x.MeasuredAt, x => x.Temperature));
            charting.SaveToPng("chart.png");

            foreach (var temperature in temperatures) {
                System.Console.WriteLine("{0}: {1} °C", temperature.Station.Name, temperature.Temperature);
            }


            System.Console.ReadLine();

        }
    }
}