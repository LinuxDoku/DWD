namespace DWD.Crawler.Contract.Model {
    public interface IStation {
        /// <summary>
        /// DWD ID of the Station. E.g. 3621 for Reimlingen.
        /// </summary>
        int StationId { get; }

        /// <summary>
        /// Name of the station.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// State in which the station is located. E.g. Bayern.
        /// </summary>
        string State { get; }

        /// <summary>
        /// Geo Longitude.
        /// </summary>
        decimal GeoLongitude { get; }

        /// <summary>
        /// Geo Latitude.
        /// </summary>
        decimal GeoLatitude { get; }
    }
}