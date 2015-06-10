namespace DWD.Crawler.Model {
    /// <summary>
    /// Measuring station.
    /// </summary>
    public class Station {
        /// <summary>
        /// DWD ID of the Station. E.g. 3621 for Reimlingen.
        /// </summary>
        public int StationId { get; set; }
        
        /// <summary>
        /// Name of the station.
        /// </summary>
        public string Name { get; set; }
    }
}