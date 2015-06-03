using System;

namespace DWD.Crawler.Model {
    public class AirTemperature {
        /// <summary>
        /// Station where the temperature was measured.
        /// </summary>
        public Station Station { get; set; }

        /// <summary>
        /// DateTime when the temperature was measured.
        /// </summary>
        public DateTime MeasuredAt { get; set; }

        /// <summary>
        /// Quality level of the temperature.
        /// </summary>
        public QualityLevel QualityLevel { get; set; }

        /// <summary>
        /// Actual Temperature.
        /// </summary>
        public decimal Temperature { get; set; }

        /// <summary>
        /// Relative humidity of the last 24 measures.
        /// </summary>
        public decimal RelativeHumidity { get; set; }
    }
}