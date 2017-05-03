namespace Microsoft.PowerBI.Service.Api
{
    public interface ITile
    {
        string Id { get; set; }

        string Title { get; set; }

        string EmbedUrl { get; set; }
    }
}
