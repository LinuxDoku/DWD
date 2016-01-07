using System.Linq;
using System.Windows.Forms;
using DWD.Crawler.Provider;
using OxyPlot.WindowsForms;

namespace DWD.UI {
    public partial class MainWindow : Form {
        protected AirTemperatureProvider AirTemperatureProvider { get; set; }
        protected PlotView Plot { get; set; }

        public MainWindow() {
            InitializeComponent();

            AirTemperatureProvider = new AirTemperatureProvider();
            Plot = new PlotView {
                Dock = DockStyle.Fill
            };

            UpdatePlot();
            Controls.Add(Plot);
        }

        protected Charting.Charting LoadTemperature(string stationName) {
            var temperatures = AirTemperatureProvider.GetByStationName(stationName);

            var charting = new Charting.Charting();
            charting.AddData(temperatures.ToDictionary(x => x.MeasuredAt, x => x.Temperature));

            return charting;
        }

        protected void UpdatePlot() {
            Plot.Model = LoadTemperature(txtStationName.Text).Model;
        }

        private void btnUpdate_Click(object sender, System.EventArgs e) {
            UpdatePlot();
        }
    }
}