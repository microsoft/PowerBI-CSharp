using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Microsoft.PowerBI.Security
{
    /// <summary>
    /// Manages reading / storing tokens for use in the Power BI service
    /// </summary>
    public class TokenManager
    {
        private static TokenManager current;
        private IDictionary<string, string> tokenStore;
        private Func<IIdentity, string> readTokenFactory;
        private Action<IIdentity, string> writeTokenAction;
        internal TokenManager()
        {
            this.tokenStore = new Dictionary<string, string>();
            this.readTokenFactory = (identity) =>
            {
                string accessToken = null;
                if (identity.IsAuthenticated)
                {
                    accessToken = this.tokenStore.ContainsKey(identity.Name) ? this.tokenStore[identity.Name] : null;
                }

                return accessToken;
            };

            this.writeTokenAction = (identity, accessToken) =>
            {
                if (!identity.IsAuthenticated)
                {
                    return;
                }

                this.tokenStore[identity.Name] = accessToken;
            };
        }

        /// <summary>
        /// Stores a Power BI token and associates it with the specified identity
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="accessToken"></param>
        public void WriteToken(IIdentity identity, string accessToken)
        {
            Guard.ValidateObjectNotNull(identity, "identity");
            Guard.ValidateString(accessToken, "accesstoken");

            this.writeTokenAction(identity, accessToken);
        }

        /// <summary>
        /// Reads the Power BI token for the specified identity
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string ReadToken(IIdentity identity)
        {
            Guard.ValidateObjectNotNull(identity, "identity");
            return this.readTokenFactory(identity);
        }

        /// <summary>
        /// Gets the current instance of the TokenManager class
        /// </summary>
        public static TokenManager Current
        {
            get
            {
                return (current ?? (current = new TokenManager()));
            }
        }

        /// <summary>
        /// Sets the reader strategy for reading Power BI tokens
        /// </summary>
        /// <param name="readTokenFactory">The strategy expression used to read tokens</param>
        public void SetTokenReader(Func<IIdentity, string> readTokenFactory)
        {
            Guard.ValidateObjectNotNull(readTokenFactory, "readTokenFactory");
            this.readTokenFactory = readTokenFactory;
        }

        /// <summary>
        /// Sets the writer strategy for storing Power BI tokens
        /// </summary>
        /// <param name="writeTokenAction">The strategy expression used to store tokens</param>
        public void SetTokenWriter(Action<IIdentity, string> writeTokenAction)
        {
            Guard.ValidateObjectNotNull(writeTokenAction, "writeTokenAction");
            this.writeTokenAction = writeTokenAction;
        }

        /// <summary>
        /// Clears the token store for all users
        /// </summary>
        public void Clear()
        {
            this.tokenStore.Clear();
        }
    }
}