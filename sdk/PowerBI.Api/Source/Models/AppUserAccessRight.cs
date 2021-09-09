// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.PowerBI.Api.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines values for AppUserAccessRight.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(AppUserAccessRightConverter))]
    public struct AppUserAccessRight : System.IEquatable<AppUserAccessRight>
    {
        private AppUserAccessRight(string underlyingValue)
        {
            UnderlyingValue=underlyingValue;
        }

        /// <summary>
        /// No permission to content in app
        /// </summary>
        public static readonly AppUserAccessRight None = "None";

        /// <summary>
        /// Grants Read access to content in app
        /// </summary>
        public static readonly AppUserAccessRight Read = "Read";

        /// <summary>
        /// Grants Read and Write access to content in app
        /// </summary>
        public static readonly AppUserAccessRight ReadWrite = "ReadWrite";

        /// <summary>
        /// Grants Read and Reshare access to content in app
        /// </summary>
        public static readonly AppUserAccessRight ReadReshare = "ReadReshare";

        /// <summary>
        /// Grants Read, Write and Reshare access to content in app
        /// </summary>
        public static readonly AppUserAccessRight ReadWriteReshare = "ReadWriteReshare";

        /// <summary>
        /// Grants Read and Explore access to content in app
        /// </summary>
        public static readonly AppUserAccessRight ReadExplore = "ReadExplore";

        /// <summary>
        /// Grants Read and Copy access to content in app
        /// </summary>
        public static readonly AppUserAccessRight ReadCopy = "ReadCopy";

        /// <summary>
        /// Grants Read, Explore and Copy access to content in app
        /// </summary>
        public static readonly AppUserAccessRight ReadExploreCopy = "ReadExploreCopy";

        /// <summary>
        /// Grants Read, Reshare, Explore and Copy access to content in app
        /// </summary>
        public static readonly AppUserAccessRight ReadReshareExploreCopy = "ReadReshareExploreCopy";

        /// <summary>
        /// Grants Read, Reshare and Explore access to content in app
        /// </summary>
        public static readonly AppUserAccessRight ReadReshareExplore = "ReadReshareExplore";

        /// <summary>
        /// Grants Read, Write and Explore access to content in app
        /// </summary>
        public static readonly AppUserAccessRight ReadWriteExplore = "ReadWriteExplore";

        /// <summary>
        /// Grants Read, Write, Reshare and Explore access to content in app
        /// </summary>
        public static readonly AppUserAccessRight ReadWriteReshareExplore = "ReadWriteReshareExplore";

        /// <summary>
        /// Grants Read, Write, Explore and Copy access to content in app
        /// </summary>
        public static readonly AppUserAccessRight ReadWriteExploreCopy = "ReadWriteExploreCopy";

        /// <summary>
        /// Grants Read, Write, Explore, Reshare and Copy access to content in
        /// app
        /// </summary>
        public static readonly AppUserAccessRight All = "All";


        /// <summary>
        /// Underlying value of enum AppUserAccessRight
        /// </summary>
        private readonly string UnderlyingValue;

        /// <summary>
        /// Returns string representation for AppUserAccessRight
        /// </summary>
        public override string ToString()
        {
            return UnderlyingValue.ToString();
        }

        /// <summary>
        /// Compares enums of type AppUserAccessRight
        /// </summary>
        public bool Equals(AppUserAccessRight e)
        {
            return UnderlyingValue.Equals(e.UnderlyingValue);
        }

        /// <summary>
        /// Implicit operator to convert string to AppUserAccessRight
        /// </summary>
        public static implicit operator AppUserAccessRight(string value)
        {
            return new AppUserAccessRight(value);
        }

        /// <summary>
        /// Implicit operator to convert AppUserAccessRight to string
        /// </summary>
        public static implicit operator string(AppUserAccessRight e)
        {
            return e.UnderlyingValue;
        }

        /// <summary>
        /// Overriding == operator for enum AppUserAccessRight
        /// </summary>
        public static bool operator == (AppUserAccessRight e1, AppUserAccessRight e2)
        {
            return e2.Equals(e1);
        }

        /// <summary>
        /// Overriding != operator for enum AppUserAccessRight
        /// </summary>
        public static bool operator != (AppUserAccessRight e1, AppUserAccessRight e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>
        /// Overrides Equals operator for AppUserAccessRight
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is AppUserAccessRight && Equals((AppUserAccessRight)obj);
        }

        /// <summary>
        /// Returns for hashCode AppUserAccessRight
        /// </summary>
        public override int GetHashCode()
        {
            return UnderlyingValue.GetHashCode();
        }

    }
}
