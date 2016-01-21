namespace Microsoft.PowerBI.Api
{
    public interface ITile
    {
        string Id { get; set; }

        string Title { get; set; }

        string EmbedUrl { get; set; }
    }
}
