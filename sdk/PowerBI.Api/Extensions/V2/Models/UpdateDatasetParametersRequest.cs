namespace Microsoft.PowerBI.Api.V2.Models
{
    public partial class UpdateMashupParametersRequest
    {
        /// <summary>
        /// Initializes a new instance of the UpdateMashupParametersDetails
        /// class.
        /// </summary>
        /// <param name="updateDetails">The mashup parameter to update</param>
        public UpdateMashupParametersRequest(UpdateMashupParameterDetails updateDetails)
        {
            UpdateDetails = new [] { updateDetails };
            CustomInit();
        }
    }
}
