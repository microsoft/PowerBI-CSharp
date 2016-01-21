namespace Microsoft.PowerBI.Api
{
    public interface IReport
    {
        string Id { get; set; }

        string Name { get; set; }

        string WebUrl { get; set; }

        string EmbedUrl { get; set; }
    }
}
