using System;
using System.Collections.Generic;
using System.IO;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace DWD.Charting {
    public class Charting {
        public PlotModel Model { get; set; }

        public Charting() {
            Model = new PlotModel();
            Model.PlotType = PlotType.XY;
            Model.Axes.Add(new LinearAxis {
                Position = AxisPosition.Left
            });
            Model.Axes.Add(new DateTimeAxis {
                Title = "Time",
                Position = AxisPosition.Bottom,
                IntervalType = DateTimeIntervalType.Days
            });
        }

        public void AddData(Dictionary<DateTime, decimal> data) {
            var line = new LineSeries();

            foreach (var set in data) {
                line.Points.Add(new DataPoint(DateTimeAxis.ToDouble(set.Key), (double)set.Value));
            }

            Model.Series.Add(line);
        }

        public void SaveToPng(string fileName) {
            using (var stream = File.Create(fileName)) {
                var pngExporter = new PngExporter();
                pngExporter.Export(Model, stream);
            }
        }
    }
}