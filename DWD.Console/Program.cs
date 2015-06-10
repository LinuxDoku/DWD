using DWD.Crawler.Provider;

namespace DWD.Console {
    class Program {
        static void Main(string[] args) {
            var temperatureProvider = new AirTemperatureProvider();

            foreach (var temperature in temperatureProvider.GetByStationName("Reimlingen")) {
                System.Console.WriteLine("{0}: {1} °C", temperature.Station.Name, temperature.Temperature);
            }

            System.Console.ReadLine();
        }
    }
}