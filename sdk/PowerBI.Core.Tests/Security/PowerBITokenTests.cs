using Microsoft.PowerBI.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;

namespace PowerBI.Security.Tests
{
    [TestClass]
    public class PowerBITokenTests
    {
        private string signingKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        [TestMethod]
        public void CanCreateDevToken()
        {
            var workspaceId = Guid.NewGuid();
            var token = PowerBIToken.CreateDevToken("Contoso", workspaceId);

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.signingKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            var typeClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Type);
            var versionClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Version);
            var wcnClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.WorkspaceCollectionName);
            var widClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.WorkspaceId);

            Assert.AreEqual("PowerBISDK", decodedToken.Issuer);
            Assert.IsTrue(decodedToken.Audiences.Contains("https://analysis.windows.net/powerbi/api"));
            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow);
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddHours(1));
            Assert.AreEqual("dev", typeClaim.Value);
            Assert.AreEqual("0.1.0", versionClaim.Value);
            Assert.AreEqual("Contoso", wcnClaim.Value);
            Assert.AreEqual(workspaceId.ToString(), widClaim.Value);
        }

        [TestMethod]
        public void CanCreateDevTokenWithExplicitExpiration()
        {
            var workspaceId = Guid.NewGuid();
            var token = PowerBIToken.CreateDevToken("Contoso", workspaceId, DateTime.UtcNow.AddMinutes(1));

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.signingKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow);
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddMinutes(1));
        }

        [TestMethod]
        public void CanCreateDevTokenWithSlidingExpiration()
        {
            var workspaceId = Guid.NewGuid();
            var token = PowerBIToken.CreateDevToken("Contoso", workspaceId, TimeSpan.FromMinutes(2));

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.signingKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow.AddMinutes(1));
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddMinutes(2));
        }

        [TestMethod]
        public void CanCreateReportEmbedToken()
        {
            var workspaceId = Guid.NewGuid();
            var reportId = Guid.NewGuid();

            var token = PowerBIToken.CreateReportEmbedToken("Contoso", workspaceId, reportId);

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.signingKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            var typeClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Type);
            var versionClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Version);
            var wcnClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.WorkspaceCollectionName);
            var widClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.WorkspaceId);
            var ridCliam = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.ReportId);

            Assert.AreEqual("PowerBISDK", decodedToken.Issuer);
            Assert.IsTrue(decodedToken.Audiences.Contains("https://analysis.windows.net/powerbi/api"));
            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow);
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddHours(1));
            Assert.AreEqual("embed", typeClaim.Value);
            Assert.AreEqual("0.1.0", versionClaim.Value);
            Assert.AreEqual("Contoso", wcnClaim.Value);
            Assert.AreEqual(workspaceId.ToString(), widClaim.Value);
            Assert.AreEqual(reportId.ToString(), ridCliam.Value);
        }

        [TestMethod]
        public void CanCreateReportEmbedTokenWithExplicitExpiration()
        {
            var workspaceId = Guid.NewGuid();
            var reportId = Guid.NewGuid();

            var token = PowerBIToken.CreateReportEmbedToken("Contoso", workspaceId, reportId, DateTime.UtcNow.AddMinutes(1));

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.signingKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow);
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddMinutes(1));
        }

        [TestMethod]
        public void CanCreateReportEmbedTokenWithSlidingExpiration()
        {
            var workspaceId = Guid.NewGuid();
            var reportId = Guid.NewGuid();

            var token = PowerBIToken.CreateReportEmbedToken("Contoso", workspaceId, reportId, TimeSpan.FromMinutes(2));

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.signingKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow.AddMinutes(1));
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddMinutes(2));
        }

        [TestMethod]
        public void CanCreateProvisionEmbedToken()
        {
            var token = PowerBIToken.CreateProvisionToken("Contoso");

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.signingKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            var typeClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Type);
            var versionClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.Version);
            var wcnClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == PowerBIToken.ClaimTypes.WorkspaceCollectionName);

            Assert.AreEqual("PowerBISDK", decodedToken.Issuer);
            Assert.IsTrue(decodedToken.Audiences.Contains("https://analysis.windows.net/powerbi/api"));
            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow);
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddHours(1));
            Assert.AreEqual("provision", typeClaim.Value);
            Assert.AreEqual("0.1.0", versionClaim.Value);
            Assert.AreEqual("Contoso", wcnClaim.Value);
        }

        [TestMethod]
        public void CanCreateProvisionTokenWithExplicitExpiration()
        {
            var token = PowerBIToken.CreateProvisionToken("Contoso", DateTime.UtcNow.AddMinutes(1));

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.signingKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow);
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddMinutes(1));
        }

        [TestMethod]
        public void CanCreateProvisionTokenWithSlidingExpiration()
        {
            var token = PowerBIToken.CreateProvisionToken("Contoso", TimeSpan.FromMinutes(2));

            Assert.IsNotNull(token);
            var jwt = token.Generate(this.signingKey);
            Assert.IsFalse(string.IsNullOrEmpty(jwt));

            var decodedToken = new JwtSecurityToken(jwt);

            Assert.IsTrue(decodedToken.ValidTo >= DateTime.UtcNow.AddMinutes(1));
            Assert.IsTrue(decodedToken.ValidTo <= DateTime.UtcNow.AddMinutes(2));
        }

        [TestMethod]
        public void CanManuallyCreatePowerBIToken()
        {
            var token = new PowerBIToken
            {
                Audience = "TestAudience",
                Issuer = "TestIssuer",
                Expiration = DateTime.UtcNow.AddHours(2),
                SigningKey = this.signingKey
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
        public void CreateDevTokenWithInvalidExpirationFails()
        {
            var workspaceId = Guid.NewGuid();
            var token = PowerBIToken.CreateDevToken("Contoso", workspaceId, DateTime.MinValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateProvisionTokenWithInvalidExpirationFails()
        {
            var workspaceId = Guid.NewGuid();
            var token = PowerBIToken.CreateProvisionToken("Contoso", DateTime.MinValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateReportEmbedTokenWithInvalidExpirationFails()
        {
            var workspaceId = Guid.NewGuid();
            var reportId = Guid.NewGuid();

            var token = PowerBIToken.CreateReportEmbedToken("Contoso", workspaceId, reportId, DateTime.MinValue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateGenericTokenWithInvalidExpirationFails()
        {
            var token = new PowerBIToken
            {
                Issuer = "issuer",
                Audience = "audience",
                SigningKey = this.signingKey,
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

            token.Generate(this.signingKey);
        }
    }
}
