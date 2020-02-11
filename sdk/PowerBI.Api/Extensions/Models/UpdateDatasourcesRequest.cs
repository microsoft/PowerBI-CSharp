namespace Microsoft.PowerBI.Api.Models
{
    public partial class UpdateDatasourcesRequest
    {
        /// <summary>
        /// Initializes a new instance of the UpdateDatasourcesRequest class.
        /// </summary>
        /// <param name="updateDetails">The connection server</param>
        public UpdateDatasourcesRequest(UpdateDatasourceConnectionRequest updateDetails)
        {
            UpdateDetails = new[] { updateDetails };
            CustomInit();
        }
    }
}
