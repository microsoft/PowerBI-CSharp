namespace Microsoft.PowerBI.Api.V2.Models
{
    public partial class UpdateDatasetParametersRequest
    {
        /// <summary>
        /// Initializes a new instance of the UpdateDatasetParametersRequest
        /// class.
        /// </summary>
        /// <param name="updateDetails">The dataset parameter list to
        /// update</param>
        public UpdateDatasetParametersRequest(UpdateDatasetParameterDetails updateDetails)
        {
            UpdateDetails = new [] { updateDetails };
            CustomInit();
        }
    }
}
