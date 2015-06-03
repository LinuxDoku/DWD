using DWD.Crawler.Provider;

namespace DWD.Console {
    class Program {
        static void Main(string[] args) {
            var temperatureProvider = new AirTemperatureProvider();

            foreach (var temperature in temperatureProvider.Get()) {
                System.Console.WriteLine(temperature.Temperature);
            }
        }
    }
}