﻿using System;
using DWD.Crawler.Contract.Model;

namespace DWD.Crawler.Model {
    public class AirTemperature : IAirTemperature {
        /// <summary>
        /// Station where the temperature was measured.
        /// </summary>
        public IStation Station { get; set; }

        /// <summary>
        /// DateTime when the temperature was measured.
        /// </summary>
        public DateTime MeasuredAt { get; set; }

        /// <summary>
        /// Quality level of the temperature.
        /// </summary>
        public IQualtityLevel QualityLevel { get; set; }

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