// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.PowerBI.Api.V2.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A Power BI capacity
    /// </summary>
    public partial class Capacity
    {
        /// <summary>
        /// Initializes a new instance of the Capacity class.
        /// </summary>
        public Capacity()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Capacity class.
        /// </summary>
        /// <param name="id">The capacity id</param>
        /// <param name="displayName">The capacity display name</param>
        /// <param name="admins">An array of capacity admins</param>
        /// <param name="sku">The capacity SKU</param>
        /// <param name="state">The capacity state. Possible values include:
        /// 'NotActivated', 'Active', 'Provisioning', 'ProvisionFailed',
        /// 'PreSuspended', 'Suspended', 'Deleting', 'Deleted', 'Invalid',
        /// 'UpdatingSku'</param>
        /// <param name="capacityUserAccessRight">Access rights user has for
        /// capacity. Possible values include: 'None', 'Assign',
        /// 'Admin'</param>
        public Capacity(string id = default(string), string displayName = default(string), IList<string> admins = default(IList<string>), string sku = default(string), StateEnum? state = default(StateEnum?), CapacityUserAccessRightEnum? capacityUserAccessRight = default(CapacityUserAccessRightEnum?))
        {
            Id = id;
            DisplayName = displayName;
            Admins = admins;
            Sku = sku;
            State = state;
            CapacityUserAccessRight = capacityUserAccessRight;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the capacity id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the capacity display name
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets an array of capacity admins
        /// </summary>
        [JsonProperty(PropertyName = "admins")]
        public IList<string> Admins { get; set; }

        /// <summary>
        /// Gets or sets the capacity SKU
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the capacity state. Possible values include:
        /// 'NotActivated', 'Active', 'Provisioning', 'ProvisionFailed',
        /// 'PreSuspended', 'Suspended', 'Deleting', 'Deleted', 'Invalid',
        /// 'UpdatingSku'
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public StateEnum? State { get; set; }

        /// <summary>
        /// Gets or sets access rights user has for capacity. Possible values
        /// include: 'None', 'Assign', 'Admin'
        /// </summary>
        [JsonProperty(PropertyName = "capacityUserAccessRight")]
        public CapacityUserAccessRightEnum? CapacityUserAccessRight { get; set; }

    }
}
