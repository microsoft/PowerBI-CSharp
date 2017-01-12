using Microsoft.PowerBI.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;

namespace PowerBI.Security.Tests
{
    [TestClass]
    public class PowerBITokenTests
    {
        private string accessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        [TestMethod]
        public void CanCreateReportEmbedToken()
        {
            var workspaceId = Guid.NewGuid().ToString();
            var reportId = Guid.NewGuid().ToString();

            var token = PowerBIToken.CreateReportEmbedToken("Contoso", workspaceId, reportId: reportId, username: "TestUser", roles: new []{ "TestRole" });

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.accessKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            var versionClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Version);
            var typeClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.JwtType);
            var wcnClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.WorkspaceCollectionName);
            var widClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.WorkspaceId);
            var ridCliam = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.ReportId);
            var usernameClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Username);
            var rolesClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Roles);

            Assert.AreEqual("PowerBISDK", decodedToken.Issuer);
            Assert.IsTrue(decodedToken.Audiences.Contains("https://analysis.windows.net/powerbi/api"));
            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow);
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddHours(1));
            Assert.AreEqual("0.2.0", versionClaim.Value);
            Assert.AreEqual("embed", typeClaim.Value);
            Assert.AreEqual("Contoso", wcnClaim.Value);
            Assert.AreEqual(workspaceId, widClaim.Value);
            Assert.AreEqual(reportId, ridCliam.Value);
            Assert.AreEqual("TestUser", usernameClaim.Value);
            Assert.AreEqual("TestRole", rolesClaim.Value);
        }

        [TestMethod]
        public void CanCreateReportEmbedTokenForDatasetId()
        {
            var workspaceId = Guid.NewGuid().ToString();
            var datasetId = Guid.NewGuid().ToString();

            var token = PowerBIToken.CreateReportEmbedTokenForCreation("Contoso", workspaceId, datasetId: datasetId, username: "TestUser", roles: new[] { "TestRole" });

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.accessKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            var versionClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Version);
            var typeClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.JwtType);
            var wcnClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.WorkspaceCollectionName);
            var widClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.WorkspaceId);
            var didCliam = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.DatasetId);
            var usernameClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Username);
            var rolesClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Roles);

            Assert.AreEqual("PowerBISDK", decodedToken.Issuer);
            Assert.IsTrue(decodedToken.Audiences.Contains("https://analysis.windows.net/powerbi/api"));
            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow);
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddHours(1));
            Assert.AreEqual("0.2.0", versionClaim.Value);
            Assert.AreEqual("embed", typeClaim.Value);
            Assert.AreEqual("Contoso", wcnClaim.Value);
            Assert.AreEqual(workspaceId, widClaim.Value);
            Assert.AreEqual(datasetId, didCliam.Value);
            Assert.AreEqual("TestUser", usernameClaim.Value);
            Assert.AreEqual("TestRole", rolesClaim.Value);
        }

        [TestMethod]
        public void CanCreateReportEmbedTokenWithExplicitExpiration()
        {
            var workspaceId = Guid.NewGuid().ToString();
            var reportId = Guid.NewGuid().ToString();

            var token = PowerBIToken.CreateReportEmbedToken("Contoso", workspaceId, reportId, DateTime.UtcNow.AddMinutes(1));

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.accessKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow);
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddMinutes(1));
        }

        [TestMethod]
        public void CanCreateReportEmbedTokenWithSlidingExpiration()
        {
            var workspaceId = Guid.NewGuid().ToString();
            var reportId = Guid.NewGuid().ToString();

            var token = PowerBIToken.CreateReportEmbedTokenWithExpiration("Contoso", workspaceId, reportId: reportId, slidingExpiration: TimeSpan.FromMinutes(2));

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.accessKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow.AddMinutes(1));
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddMinutes(2));
        }

        [TestMethod]
        public void CanCreateReportEmbedTokenWithRlsNoRoles()
        {
            var workspaceId = Guid.NewGuid().ToString();
            var reportId = Guid.NewGuid().ToString();

            var token = PowerBIToken.CreateReportEmbedToken("Contoso", workspaceId, reportId, username: "TestUser");

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.accessKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            var usernameClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Username);
            var rolesClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Roles);

            Assert.AreEqual("TestUser", usernameClaim.Value);
            Assert.IsNull(rolesClaim);
        }

        [TestMethod]
        public void CanCreateReportEmbedTokenWithRlsWithMultipleRoles()
        {
            var workspaceId = Guid.NewGuid().ToString();
            var reportId = Guid.NewGuid().ToString();

            var token = PowerBIToken.CreateReportEmbedToken("Contoso", workspaceId, reportId, username: "TestUser", roles: new []{ "TestRole1", "TestRole2" });

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.accessKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            var usernameClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Username);
            var rolesClaims = decodedToken.Claims.Where(c => c.Type == PowerBIToken.ClaimTypes.Roles).Select(c => c.Value).ToList();

            Assert.AreEqual("TestUser", usernameClaim.Value);
            Assert.AreEqual(rolesClaims.Count, 2);
            Assert.IsTrue(rolesClaims.Contains("TestRole1"));
            Assert.IsTrue(rolesClaims.Contains("TestRole2"));
        }

        [TestMethod]
        public void CanCreateReportEmbedTokenWithScopes()
        {
            var workspaceId = Guid.NewGuid().ToString();
            var reportId = Guid.NewGuid().ToString();
            var scopes = Scopes.DatasetRead;

            var token = PowerBIToken.CreateReportEmbedToken("Contoso", workspaceId, reportId, scopes: scopes);

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.accessKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            var scopesClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Scopes).Value.Split(' ').ToList();

            Assert.IsTrue(scopesClaim.Contains(scopes));
        }

        [TestMethod]
        public void CanCreateReportEmbedTokenWithScopesList()
        {
            var workspaceId = Guid.NewGuid().ToString();
            var reportId = Guid.NewGuid().ToString();
            var scopesList = new List<string>() {
                Scopes.DatasetRead,
                Scopes.ReportReadWrite
            };

            var token = PowerBIToken.CreateReportEmbedTokenWithScopes("Contoso", workspaceId, reportId, scopesList: scopesList);

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.accessKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            var scopesClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Scopes).Value.Split(' ').ToList();

            foreach (var scope in scopesList)
            {
                Assert.IsTrue(scopesClaim.Contains(scope));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateReportEmbedTokenWithRlsWithRolesAndMissingUsernameFails()
        {
            var workspaceId = Guid.NewGuid().ToString();
            var reportId = Guid.NewGuid().ToString();

            PowerBIToken.CreateReportEmbedToken("Contoso", workspaceId, reportId, username: null, roles: new[] { "TestRole"});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateReportEmbedTokenMissingReportAndDatasetIdsFails()
        {
            var workspaceId = Guid.NewGuid().ToString();
            var reportId = Guid.NewGuid().ToString();

            PowerBIToken.CreateReportEmbedToken("Contoso", workspaceId);
        }

        [TestMethod]
        public void CanManuallyCreatePowerBIToken()
        {
            var token = new PowerBIToken
            {
                Audience = "TestAudience",
                Issuer = "TestIssuer",
                Expiration = DateTime.UtcNow.AddHours(2),
                AccessKey = this.accessKey
            };

            token.Claims.Add(new Claim("Name", "TestUser"));

            var jwt = token.Generate();
            var decodedToken = new JwtSecurityToken(jwt);

            var tokenExpiration = new DateTime(
                token.Expiration.Value.Year,
                token.Expiration.Value.Month,
                token.Expiration.Value.Day,
                token.Expiration.Value.Hour,
                token.Expiration.Value.Minute,
                token.Expiration.Value.Second);

            Assert.IsTrue(decodedToken.Audiences.Contains(token.Audience));
            Assert.AreEqual(token.Issuer, decodedToken.Issuer);
            Assert.AreEqual(tokenExpiration, decodedToken.ValidTo);

            var nameClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == "Name");
            Assert.AreEqual("TestUser", nameClaim.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateReportEmbedTokenWithInvalidExpirationFails()
        {
            var workspaceId = Guid.NewGuid().ToString();
            var reportId = Guid.NewGuid().ToString();

            PowerBIToken.CreateReportEmbedToken("Contoso", workspaceId, reportId, DateTime.MinValue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateGenericTokenWithInvalidExpirationFails()
        {
            var token = new PowerBIToken
            {
                Issuer = "issuer",
                Audience = "audience",
                AccessKey = this.accessKey,
                Expiration = DateTime.MinValue
            };

            token.Generate();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateGenericTokenWithMissingParamsFails()
        {
            var token = new PowerBIToken
            {
                Issuer = null,
                Audience = null
            };

            token.Generate(this.accessKey);
        }
    }
}
