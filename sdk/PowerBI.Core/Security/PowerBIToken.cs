using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Microsoft.PowerBI.Security
{
    public class PowerBIToken
    {
        public static class ClaimTypes
        {
            public const string Version = "ver";
            public const string Type = "type";
            public const string WorkspaceCollectionName = "wcn";
            public const string WorkspaceId = "wid";
            public const string ReportId = "rid";
        }

        private const int DefaultExpirationSeconds = 3600;
        private const string DefaultIssuer = "PowerBISDK";
        private const string DefaultAudience = "https://analysis.windows.net/powerbi/api";

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
        /// Creates a provision token with default expiration used to manages workspaces witin a workspace collection
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateProvisionToken(string workspaceCollectionName)
        {
            var expires = DateTime.UtcNow.Add(TimeSpan.FromSeconds(DefaultExpirationSeconds));
            return CreateProvisionToken(workspaceCollectionName, expires);
        }

        /// <summary>
        /// Creates a provision token with a sliding expiration used to manages workspaces witin a workspace collection
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="slidingExpiration">The timespan to append to the current date/time</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateProvisionToken(string workspaceCollectionName, TimeSpan slidingExpiration)
        {
            var expires = DateTime.UtcNow.Add(slidingExpiration);
            return CreateProvisionToken(workspaceCollectionName, expires);
        }

        /// <summary>
        /// Creates a provision token with a sliding expiration used to manages workspaces witin a workspace collection
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="expiration">The token expiration date/time</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateProvisionToken(string workspaceCollectionName, DateTime expiration)
        {
            Guard.ValidateString(workspaceCollectionName, "workspaceCollectionName");

            if (expiration < DateTime.UtcNow)
            {
                throw new ArgumentException("Expiration must be a date/time in the future", "expiration");
            }

            var token = new PowerBIToken
            {
                Expiration = expiration
            };

            token.Claims.Add(new Claim(ClaimTypes.Type, "provision"));
            token.Claims.Add(new Claim(ClaimTypes.WorkspaceCollectionName, workspaceCollectionName));

            return token;
        }

        /// <summary>
        /// Creates a developer token with default expiration used to access Power BI platform services
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="workspaceId">The workspace id</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateDevToken(string workspaceCollectionName, Guid workspaceId)
        {
            var expires = DateTime.UtcNow.Add(TimeSpan.FromSeconds(DefaultExpirationSeconds));
            return CreateDevToken(workspaceCollectionName, workspaceId, expires);
        }

        /// <summary>
        /// Creates a developer token with default expiration used to access Power BI platform services
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="workspaceId">The workspace id</param>
        /// <param name="slidingExpiration">The timespan to append to the current date/time</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateDevToken(string workspaceCollectionName, Guid workspaceId, TimeSpan slidingExpiration)
        {
            var expires = DateTime.UtcNow.Add(slidingExpiration);
            return CreateDevToken(workspaceCollectionName, workspaceId, expires);
        }


        /// <summary>
        /// Creates a developer token with default expiration used to access Power BI platform services
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="workspaceId">The workspace id</param>
        /// <param name="expiration">The token expiration date/time</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateDevToken(string workspaceCollectionName, Guid workspaceId, DateTime expiration)
        {
            Guard.ValidateString(workspaceCollectionName, "workspaceCollectionName");
            Guard.ValidateGuid(workspaceId, "workspaceId");

            if (expiration < DateTime.UtcNow)
            {
                throw new ArgumentException("Expiration must be a date/time in the future", "expiration");
            }

            var token = new PowerBIToken
            {
                Expiration = expiration
            };

            token.Claims.Add(new Claim(ClaimTypes.Type, "dev"));
            token.Claims.Add(new Claim(ClaimTypes.WorkspaceCollectionName, workspaceCollectionName));
            token.Claims.Add(new Claim(ClaimTypes.WorkspaceId, workspaceId.ToString()));

            return token;
        }

        /// <summary>
        /// Creates a embed token with default expiration used to embed Power BI components into your own applications
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="workspaceId">The workspace id</param>
        /// <param name="reportId">The report id</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateReportEmbedToken(string workspaceCollectionName, Guid workspaceId, Guid reportId)
        {
            var expires = DateTime.UtcNow.Add(TimeSpan.FromSeconds(DefaultExpirationSeconds));
            return CreateReportEmbedToken(workspaceCollectionName, workspaceId, reportId, expires);
        }

        /// <summary>
        /// Creates a embed token with default expiration used to embed Power BI components into your own applications
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="workspaceId">The workspace id</param>
        /// <param name="reportId">The report id</param>
        /// <param name="slidingExpiration">The timespan to append to the current date/time</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateReportEmbedToken(string workspaceCollectionName, Guid workspaceId, Guid reportId, TimeSpan slidingExpiration)
        {
            var expires = DateTime.UtcNow.Add(slidingExpiration);
            return CreateReportEmbedToken(workspaceCollectionName, workspaceId, reportId, expires);
        }

        /// <summary>
        /// Creates a embed token with default expiration used to embed Power BI components into your own applications
        /// </summary>
        /// <param name="workspaceCollectionName">The workspace collection name</param>
        /// <param name="workspaceId">The workspace id</param>
        /// <param name="reportId">The report id</param>
        /// <param name="expiration">The token expiration date/time</param>
        /// <returns>The Power BI access token</returns>
        public static PowerBIToken CreateReportEmbedToken(string workspaceCollectionName, Guid workspaceId, Guid reportId, DateTime expiration)
        {
            Guard.ValidateString(workspaceCollectionName, "workspaceCollectionName");
            Guard.ValidateGuid(workspaceId, "workspaceId");
            Guard.ValidateGuid(reportId, "reportId");

            if (expiration < DateTime.UtcNow)
            {
                throw new ArgumentException("Expiration must be a date/time in the future", "expiration");
            }

            var token = new PowerBIToken
            {
                Expiration = expiration
            };

            token.Claims.Add(new Claim(ClaimTypes.Type, "embed"));
            token.Claims.Add(new Claim(ClaimTypes.WorkspaceCollectionName, workspaceCollectionName));
            token.Claims.Add(new Claim(ClaimTypes.WorkspaceId, workspaceId.ToString()));
            token.Claims.Add(new Claim(ClaimTypes.ReportId, reportId.ToString()));

            return token;
        }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public ICollection<Claim> Claims { get; private set; }

        public string SigningKey { get; set; }

        public DateTime? Expiration { get; set; }

        public string Generate(string signingKey = null)
        {
            if (string.IsNullOrWhiteSpace(this.SigningKey) && signingKey == null)
            {
                throw new ArgumentNullException("signingKey");
            }

            this.ValidateToken();

            signingKey = signingKey ?? this.SigningKey;

            var key = Encoding.UTF8.GetBytes(signingKey);
            var signingCredentials = new SigningCredentials(new InMemorySymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);
            var token = new JwtSecurityToken(this.Issuer, this.Audience, this.Claims, DateTime.UtcNow, this.Expiration, signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public override string ToString()
        {
            return Generate();
        }

        public string ToString(string signingKey)
        {
            return Generate(signingKey);
        }

        private void InitDefaultClaims()
        {
            this.Claims.Add(new Claim(ClaimTypes.Version, "0.1.0"));
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
