using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Microsoft.PowerBI.Security
{
    /// <summary>
    /// The Power BI app token used to authenticate with Power BI Embedded services
    /// </summary>
    public class PowerBIToken
    {
        /// <summary>
        /// The Power BI supported claim types
        /// </summary>
        public static class ClaimTypes
        {
            /// <summary>
            /// The version claim
            /// </summary>
            public const string Version = "ver";

            /// <summary>
            /// The workspace collection claim
            /// </summary>
            public const string WorkspaceCollectionName = "wcn";

            /// <summary>
            /// The workspace id claim
            /// </summary>
            public const string WorkspaceId = "wid";

            /// <summary>
            /// The Jwt token type claim
            /// </summary>
            public const string JwtType = "type";

            /// <summary>
            /// The report id claim
            /// </summary>
            public const string ReportId = "rid";

            /// <summary>
            /// The dataset id claim
            /// </summary>
            public const string DatasetId = "did";

            /// <summary>
            /// The RLS username claim
            /// </summary>
            public const string Username = "username";

            /// <summary>
            /// The RLS roles claim
            /// </summary>
            public const string Roles = "roles";

            /// <summary>
            /// The permissions scopes claim
            /// </summary>
            public const string Scopes = "scp";
        }

        private const int DefaultExpirationSeconds = 3600;
        private const string DefaultIssuer = "PowerBISDK";
        private const string DefaultAudience = "https://analysis.windows.net/powerbi/api";
        private const string DefaultJwtType = "embed";

        /// <summary>
        /// Represents an access token used to authenticate and authorize against Power BI Platform services
        /// </summary>
        public PowerBIToken()
        {
            this.Claims = new List<Claim>();
            this.Issuer = DefaultIssuer;
            this.Audience = DefaultAudience;
            this.Expiration = DateTime.UtcNow.AddSeconds(DefaultExpirationSeconds);

            this.InitDefaultClaims();
        }

        /// <summary>
        /// Creates a embed token with default expiration used to embed Power BI components into your own applications
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="workspaceId">The workspace id</param>
        /// <param name="reportId">The report id</param>
        /// <param name="datasetId">The dataset id</param>
        /// <param name="username">The RLS username</param>
        /// <param name="roles">The RLS roles</param>
        /// <param name="scopes">The permission scopes</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateReportEmbedToken(string workspaceCollectionName, string workspaceId, string reportId = null, string datasetId = null, string username = null, IEnumerable<string> roles = null, string scopes = null)
        {
            var expires = DateTime.UtcNow.Add(TimeSpan.FromSeconds(DefaultExpirationSeconds));
            return CreateReportEmbedToken(workspaceCollectionName, workspaceId, reportId: reportId, datasetId: string.Empty, expiration: expires, username: username, roles: roles, scopes: scopes);
        }


        /// <summary>
        /// Creates a embed token with default expiration used to embed Power BI components into your own applications
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="workspaceId">The workspace id</param>
        /// <param name="reportId">The report id</param>
        /// <param name="datasetId">The dataset id</param>
        /// <param name="username">The RLS username</param>
        /// <param name="roles">The RLS roles</param>
        /// <param name="scopes">The permission scopes</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateReportEmbedTokenWithDataset(string workspaceCollectionName, string workspaceId, string datasetId, string reportId = null, string username = null, IEnumerable<string> roles = null, string scopes = null)
        {
            var expires = DateTime.UtcNow.Add(TimeSpan.FromSeconds(DefaultExpirationSeconds));
            return CreateReportEmbedToken(workspaceCollectionName, workspaceId, reportId, expires, datasetId, username, roles, scopes);
        }

        /// <summary>
        /// Creates a embed token with default expiration used to embed Power BI components into your own applications
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="workspaceId">The workspace id</param>
        /// <param name="reportId">The report id</param>
        /// <param name="datasetId">The dataset id</param>
        /// <param name="username">The RLS username</param>
        /// <param name="roles">The RLS roles</param>
        /// <param name="scopesList">The permission scopes list</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateReportEmbedTokenWithScopes(string workspaceCollectionName, string workspaceId, string reportId = null, string datasetId = null, string username = null, IEnumerable<string> roles = null, IEnumerable<string> scopesList = null)
        {
            var expires = DateTime.UtcNow.Add(TimeSpan.FromSeconds(DefaultExpirationSeconds));
            var scopes = scopesList != null ? string.Join(" ", scopesList.ToArray()) : string.Empty;
            return CreateReportEmbedToken(workspaceCollectionName, workspaceId, reportId, expires, datasetId, username, roles, scopes);
        }

        /// <summary>
        /// Creates a embed token with default expiration used to embed Power BI components into your own applications
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="workspaceId">The workspace id</param>
        /// <param name="reportId">The report id</param>
        /// <param name="datasetId">The dataset id</param>
        /// <param name="slidingExpiration">The timespan to append to the current date/time</param>
        /// <param name="username">The RLS username</param>
        /// <param name="roles">The RLS roles</param>
        /// <param name="scopes">The permission scopes</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateReportEmbedTokenWithExpiration(string workspaceCollectionName, string workspaceId, TimeSpan slidingExpiration, string reportId, string datasetId = null, string username = null, IEnumerable<string> roles = null, string scopes = null)
        {
            var expires = DateTime.UtcNow.Add(slidingExpiration);
            return CreateReportEmbedToken(workspaceCollectionName, workspaceId, reportId, expires, datasetId, username, roles);
        }

        /// <summary>
        /// Creates a embed token with default expiration used to embed Power BI components into your own applications
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="workspaceId">The workspace id</param>
        /// <param name="reportId">The report id</param>
        /// <param name="datasetId">The dataset id</param>
        /// <param name="expiration">The token expiration date/time</param>
        /// <param name="username">The RLS username</param>
        /// <param name="roles">The RLS roles</param>
        /// <param name="scopes">The permission scopes</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateReportEmbedToken(string workspaceCollectionName, string workspaceId, string reportId, DateTime expiration, string datasetId = null, string username = null, IEnumerable<string> roles = null, string scopes = null)
        {
            Guard.ValidateString(workspaceCollectionName, "workspaceCollectionName");
            Guard.ValidateString(workspaceId, "workspaceId");

            if (expiration < DateTime.UtcNow)
            {
                throw new ArgumentException("Expiration must be a date/time in the future", nameof(expiration));
            }

            if (string.IsNullOrWhiteSpace(reportId) && string.IsNullOrWhiteSpace(datasetId))
            {
                throw new ArgumentException("Either ReportId or DatasetId must be set", nameof(reportId) + "\\ " + nameof(datasetId));
            }

            if (roles != null && string.IsNullOrEmpty(username))
            {
                throw  new ArgumentException("Cannot have an empty or null Username claim with the non-empty Roles claim");
            }

            var token = new PowerBIToken
            {
                Expiration = expiration
            };

            token.Claims.Add(new Claim(ClaimTypes.WorkspaceCollectionName, workspaceCollectionName));
            token.Claims.Add(new Claim(ClaimTypes.WorkspaceId, workspaceId));

            if (!string.IsNullOrWhiteSpace(reportId))
            {
                token.ReportId = reportId;
                token.Claims.Add(new Claim(ClaimTypes.ReportId, reportId));
            }

            if (!string.IsNullOrWhiteSpace(datasetId))
            {
                token.DatasetId = datasetId;
                token.Claims.Add(new Claim(ClaimTypes.DatasetId, datasetId));
            }

            // RLS claims: requires username and roles are optional
            if (!string.IsNullOrEmpty(username))
            {
                token.Claims.Add(new Claim(ClaimTypes.Username, username));

                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        token.Claims.Add(new Claim(ClaimTypes.Roles, role));
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(scopes))
            {
                token.Claims.Add(new Claim(ClaimTypes.Scopes, scopes));
            }

            return token;
        }

        /// <summary>
        /// The token issuer
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// The audience this token is valid for
        /// </summary>
        public string Audience { get; set; }

        // <summary>
        /// The report id this token is valid for
        /// </summary>
        public string ReportId { get; set; }

        // <summary>
        /// The dataset id this token is valid for
        /// </summary>
        public string DatasetId { get; set; }

        /// <summary>
        /// Gets or sets a collection of claims associated with this token
        /// </summary>
        public ICollection<Claim> Claims { get; private set; }

        /// <summary>
        /// Gets or set the access key used to sign the app token
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets the token expiration.  Default expiration is 1 hour
        /// </summary>
        public DateTime? Expiration { get; set; }

        /// <summary>
        /// Generates an app token with the specified claims and signs it the the configured signing key.
        /// </summary>
        /// <param name="accessKey">The access key used to sign the app token</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string Generate(string accessKey = null)
        {
            if (string.IsNullOrWhiteSpace(this.AccessKey) && accessKey == null)
            {
                throw new ArgumentNullException(nameof(accessKey));
            }

            this.ValidateToken();

            accessKey = accessKey ?? this.AccessKey;

            var key = Encoding.UTF8.GetBytes(accessKey);
            var signingCredentials = new SigningCredentials(new InMemorySymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);
            var token = new JwtSecurityToken(this.Issuer, this.Audience, this.Claims, DateTime.UtcNow, this.Expiration, signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Generate();
        }

        /// <summary>
        /// Returns a JWT token string that represents the current object
        /// </summary>
        /// <param name="accessKey">The access key used to sign the app token</param>
        /// <returns></returns>
        public string ToString(string accessKey)
        {
            return Generate(accessKey);
        }

        private void InitDefaultClaims()
        {
            this.Claims.Add(new Claim(ClaimTypes.Version, "0.2.0"));
            this.Claims.Add(new Claim(ClaimTypes.JwtType, DefaultJwtType));
        }

        private void ValidateToken()
        {
            if (this.Expiration.HasValue && this.Expiration.Value < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Expiration must be set to a date/time in the future");
            }

            if (string.IsNullOrWhiteSpace(this.Issuer))
            {
                throw new InvalidOperationException("Issuer must be set");
            }

            if (string.IsNullOrWhiteSpace(this.Audience))
            {
                throw new InvalidOperationException("Audience must be set");
            }
        }
    }
}
