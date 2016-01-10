using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DWD.Crawler.Model;
using DWD.Crawler.Provider;
using static System.Console;

namespace DWD.Console {
    public class Program {
        public static void Main(string[] args) {
            if (!args.Any() || args.Contains("help")) {
                Help();
                return;
            }

            if (args.Length == 1 && args[0] == "stations") {
                ShowAllStations();
            }


            if (args.Length == 2) {
                if (args[0] == "current") {
                    ShowTemperature(args[1], Period.Current);
                }

                if (args[0] == "today") {
                    ShowTemperature(args[1], Period.Today);
                }

                if (args[0] == "yesterday") {
                    ShowTemperature(args[1], Period.Yesterday);
                }
            }
        }

        private enum Period {
            Current, Today, Yesterday
        }

        private static void Help() {
            WriteLine();
            WriteLine(" help                    |  Show this list of all commands");
            WriteLine();
            WriteLine(" stations                |  List all available stations");
            WriteLine(" last [STATION]          |  Get the station's last temperature");
            WriteLine(" yesterday [STATION]     |  Get the station's temperature of each hour yesterday");
            WriteLine();
        }

        private static void ShowAllStations() {
            var stationProvider = new StationProvider();

            foreach (var station in stationProvider.GetAll()) {
                WriteLine("{0} at {1}", station.Name, station.State);
            }
        }

        private static void ShowTemperature(string station, Period period) {
            var temperatureProvider = new AirTemperatureProvider();
            var temperatures = temperatureProvider.GetByStationName(station.Trim()).ToList();

            Debugger.Launch();

            // TODO: fix period filtering
            switch (period) {
                case Period.Current:
                    temperatures.RemoveRange(0, temperatures.Count - 1);
                    break;
                case Period.Yesterday:
                    temperatures.RemoveAll(x => x.MeasuredAt.Date != DateTime.Today.AddDays(-1));
                    break;
            }

            foreach (var temperature in temperatures) {
                WriteLine("{0}, {1}: {2} °C", temperature.Station.Name, temperature.MeasuredAt, temperature.Temperature);
            }
        }

        private static void GenerateChart(IEnumerable<AirTemperature> temperatures, string fileName) {
            var charting = new Charting.Charting();

            charting.AddData(temperatures.ToDictionary(x => x.MeasuredAt, x => x.Temperature));
            charting.SaveToPng(fileName + ".png");
        }
    }
}