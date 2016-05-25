using DWD.Crawler.Contract.Model;

namespace DWD.Crawler.Model {
    /// <summary>
    /// Description: http://www.dwd.de/DE/leistungen/klimadatendeutschland/qualitaetsniveau.html
    /// </summary>
    public class QualityLevel : IQualtityLevel {
        /// <summary>
        /// Level id from the DWD web-site.
        /// </summary>
        public short LevelId { get; set; }

        /// <summary>
        /// Description of the quality level from the DWD web-site.
        /// </summary>
        public string Description { get; set; }
    }
}