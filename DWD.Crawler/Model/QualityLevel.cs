namespace DWD.Crawler.Model {
    /// <summary>
    /// Description: http://www.dwd.de/bvbw/appmanager/bvbw/dwdwwwDesktop?_nfpb=true&_pageLabel=dwdwww_result_page&portletMasterPortlet_i1gsbDocumentPath=Navigation%2FOeffentlichkeit%2FKlima__Umwelt%2FKlimadaten%2Fkldaten__kostenfrei%2Fqualitaetsniveau__node.html%3F__nnn%3Dtrue
    /// </summary>
    public class QualityLevel {
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