using System;
using DWD.Crawler.Model;

namespace DWD.Crawler.Contract.Model {
    public interface IAirTemperature {
        /// <summary>
        /// Station where the temperature was measured.
        /// </summary>
        IStation Station { get; }

        /// <summary>
        /// DateTime when the temperature was measured.
        /// </summary>
        DateTime MeasuredAt { get; }

        /// <summary>
        /// Quality level of the temperature.
        /// </summary>
        IQualtityLevel QualityLevel { get; }

        /// <summary>
        /// Actual Temperature.
        /// </summary>
        decimal Temperature { get; }

        /// <summary>
        /// Relative humidity of the last 24 measures.
        /// </summary>
        decimal RelativeHumidity { get; }
    }
}