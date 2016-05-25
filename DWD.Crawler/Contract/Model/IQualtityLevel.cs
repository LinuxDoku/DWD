namespace DWD.Crawler.Contract.Model {
    public interface IQualtityLevel {
        /// <summary>
        /// Level id from the DWD web-site.
        /// </summary>
        short LevelId { get; set; }

        /// <summary>
        /// Description of the quality level from the DWD web-site.
        /// </summary>
        string Description { get; set; }
    }
}