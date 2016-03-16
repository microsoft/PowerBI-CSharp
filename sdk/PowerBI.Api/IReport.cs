namespace Microsoft.PowerBI.Api
{
    /// <summary>
    /// The Power BI Report contract
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// The report id
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// The report name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The report web url
        /// </summary>
        string WebUrl { get; set; }

        /// <summary>
        /// The report embed url
        /// </summary>
        string EmbedUrl { get; set; }
    }
}
