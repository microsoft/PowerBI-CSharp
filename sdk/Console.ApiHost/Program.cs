using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.PowerBI.Api.Beta;
using Microsoft.PowerBI.Api.Beta.Models;
using Microsoft.Rest;
using Console = System.Console;
using Microsoft.Threading;
using ApiHost.Models;
using System.IO;
using Microsoft.PowerBI.Security;

namespace ApiHost
{
    class Program
    {
        private const string paasSigningKey = "6vr7uH5jcuYNRWC86KF3mydCXolayDDQi6NA8r5iV6YsPYD+Qb+KySkrwV9So1TgX/RQv5Bt5/abW7qvN+0uAQ==";
        private const string workspaceCollection = "Josh_WC";

        static void Main(string[] args)
        {
            AsyncPump.Run(async delegate
            {
                await Run();
            });

            Console.ReadKey(true);
        }

        static async Task Run()
        {
            try {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Create a workspace");
                Console.WriteLine("2. Import PBIX Desktop file");
                Console.WriteLine("3. Update connection string info");
                Console.WriteLine("4. Get Report Embed Url");
                Console.WriteLine("5. SaaS Demo");
                Console.WriteLine();

                var key = Console.ReadKey(true);

                switch (key.KeyChar)
                {
                    case '1':
                        var workspace = await CreateWorkspace();
                        Console.WriteLine("Workspace ID: {0}", workspace.ObjectId);
                        await Run();
                        break;
                    case '2':
                        Console.Write("Workspace ID:");
                        var workspaceId1 = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("Dataset Name:");
                        var datasetName = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("File Path:");
                        var filePath = Console.ReadLine();
                        Console.WriteLine();

                        await ImportPbix(Guid.Parse(workspaceId1), datasetName, filePath);
                        await Run();
                        break;
                    case '3':
                        Console.Write("Workspace ID:");
                        var workspaceId2 = Console.ReadLine();
                        Console.WriteLine();

                        await UpdateConnection(Guid.Parse(workspaceId2));
                        await Run();
                        break;
                    case '4':
                        Console.Write("Workspace ID:");
                        var workspaceId3 = Console.ReadLine();
                        Console.WriteLine();

                        var embedUrl = await GetReportEmbedUrl(Guid.Parse(workspaceId3));
                        Console.WriteLine("EmbedUrl: {0}", embedUrl);
                        await Run();
                        break;
                    case '5':
                        await DemoAsync();
                        await Run();
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ooops, something broke: {0}", ex.Message);
                Console.WriteLine();
                await Run();
            }
        }

        static async Task<Workspace> CreateWorkspace()
        {
            var paasToken = PowerBIToken.CreateProvisionToken(workspaceCollection);
            var jwt = paasToken.Generate(paasSigningKey);

            var credentials = new TokenCredentials(jwt, "AppToken");
            var client = new PowerBIClient(credentials);
            client.BaseUri = new Uri("https://onebox-redirect.analysis.windows-int.net");

            return await client.Workspaces.PostWorkspaceByWorkspaceCollectionNameAsync(workspaceCollection);
        }

        static async Task ImportPbix(Guid workspaceId, string datasetName, string filePath)
        {
            using (var fileStream = File.OpenRead(filePath))
            {
                var devToken = PowerBIToken.CreateDevToken(workspaceCollection, workspaceId);
                var jwt = devToken.Generate(paasSigningKey);

                var credentials = new TokenCredentials(jwt, "AppToken");
                var client = new PowerBIClient(credentials);
                client.BaseUri = new Uri("https://onebox-redirect.analysis.windows-int.net");

                await client.Imports.PostImportWithFileAsync(fileStream, datasetName);
            }
        }

        static async Task UpdateConnection(Guid workspaceId)
        {
            var devToken = PowerBIToken.CreateDevToken(workspaceCollection, workspaceId);
            var jwt = devToken.Generate(paasSigningKey);

            var credentials = new TokenCredentials(jwt, "AppToken");
            var client = new PowerBIClient(credentials);
            client.BaseUri = new Uri("https://onebox-redirect.analysis.windows-int.net");

            var datasets = await client.Datasets.GetDatasetsAsync();
            var datasource = await client.DatasetsCont.GetBoundGatewayDatasourcesByDatasetkeyAsync(datasets.Value[0].Id);

            var delta = new GatewayDatasource
            {
                CredentialType = "Basic",
                BasicCredentials = new BasicCredentials
                {
                    Username = "demouser",
                    Password = "pa$$word1"
                }
            };

            await client.Gateways.PatchDatasourceByGatewayidAndDatasourceidAsync(datasource.Value[0].GatewayId, datasource.Value[0].Id, delta);
        }

        static async Task<string> GetReportEmbedUrl(Guid workspaceId)
        {
            var devToken = PowerBIToken.CreateDevToken(workspaceCollection, workspaceId);
            var jwt = devToken.Generate(paasSigningKey);

            var credentials = new TokenCredentials(jwt, "AppToken");
            var client = new PowerBIClient(credentials);
            client.BaseUri = new Uri("https://onebox-redirect.analysis.windows-int.net");

            var reports = await client.Reports.GetReportsAsync();
            return reports.Value[0].EmbedUrl;
        }

        static async Task DemoAsync()
        {
            //var accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjF6bmJlNmV2ZWJPamg2TTNXR1E5X1ZmWXVJdyIsImtpZCI6IjF6bmJlNmV2ZWJPamg2TTNXR1E5X1ZmWXVJdyJ9.eyJhdWQiOiJodHRwczovL2FuYWx5c2lzLndpbmRvd3MtaW50Lm5ldC9wb3dlcmJpL2FwaSIsImlzcyI6Imh0dHBzOi8vc3RzLndpbmRvd3MtcHBlLm5ldC9mNjg2ZDQyNi04ZDE2LTQyZGItODFiNy1hYjU3OGUxMTBjY2QvIiwiaWF0IjoxNDUzMjMyNjQ2LCJuYmYiOjE0NTMyMzI2NDYsImV4cCI6MTQ1MzIzNjU0NiwiYWNyIjoiMSIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiI4NzFjMDEwZi01ZTYxLTRmYjEtODNhYy05ODYxMGE3ZTkxMTAiLCJhcHBpZGFjciI6IjIiLCJmYW1pbHlfbmFtZSI6IkJyZXphIiwiZ2l2ZW5fbmFtZSI6IldhbGxhY2UiLCJpcGFkZHIiOiIxNjcuMjIwLjEuNiIsIm5hbWUiOiJXYWxsYWNlIEJyZXphIiwib2lkIjoiMGM0NWE2Y2ItNTgzNC00MTdlLTg4MWEtODkwM2M2NDE3YWFkIiwib25wcmVtX3NpZCI6IlMtMS01LTIxLTIxMjc1MjExODQtMTYwNDAxMjkyMC0xODg3OTI3NTI3LTY3NDQ2NTIiLCJwdWlkIjoiMTAwMzNGRkY4MDJFMzYyRSIsInNjcCI6InVzZXJfaW1wZXJzb25hdGlvbiIsInN1YiI6InZPbTRaZGttdTA0clRxVFBodmlQV0ZPZGpTT3NOTF9kdThaZ2w2MVRiZWsiLCJ0aWQiOiJmNjg2ZDQyNi04ZDE2LTQyZGItODFiNy1hYjU3OGUxMTBjY2QiLCJ1bmlxdWVfbmFtZSI6IndhYnJlemFAbWljcm9zb2Z0LmNvbSIsInVwbiI6IndhYnJlemFAbWljcm9zb2Z0LmNvbSIsInZlciI6IjEuMCJ9.jNVmS0pyC_t-n461xBba_R3MJxxSk6up-s41GDjgKkp9d27l4Q5oeRWar-pV3wF4kB8VxMLBNtM4z6-wIwRzKdNzUEzTDJBBVCONU2zbL9FqD1mys6jAsvbZDLc4i_x4kwZRdYzhjfVxNTvHsxLB_Z0fNF9mHJBfxFZtbcogNmUFGm81A2Aaz3sTo9h_fNkIhEk7-SeIbGuNvPdmY1YVbnalfUEX0uTByGJFj-UQ367bq2oPFwbW9SIc-wRHx_OQAeSPb0vOLfBM5hMyiwENN3fCcw_Njj93ACX0yRD1LPsG10_JFQ3XaG0UUOf6ULOozzi27x77c3skn4udNUcY9g";

            var resourceUri = "https://analysis.windows.net/powerbi/api";
            var authority = "https://login.windows.net/common/oauth2/authorize";
            var clientId = "f3ea3093-dec5-48ad-97e5-ab5f491a848e";
            var redirectUri = "https://login.live.com/oauth20_desktop.srf";

            var tokenCache = new TokenCache();
            var authContext = new AuthenticationContext(authority, tokenCache);
            var authResult = authContext.AcquireToken(resourceUri, clientId, new Uri(redirectUri), PromptBehavior.Always);

            var credentials = new TokenCredentials(authResult.AccessToken, authResult.AccessTokenType);
            var client = new PowerBIClient(credentials);
            client.BaseUri = new Uri("https://onebox-redirect.analysis.windows-int.net");

            var imports = await client.Imports.GetImportsAsync();

            Console.WriteLine();
            Console.WriteLine("Imports");
            Console.WriteLine("================================");
            foreach (var import in imports.Value)
            {
                Console.WriteLine("{0}", import.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Import PBIX? (y/N)");
            var key = Console.ReadKey(true);
            if (key.KeyChar == 'Y')
            {
                using (var pbix = File.OpenRead(@"c:\users\wabreza\Desktop\progress.pbix"))
                {
                    await client.Imports.PostImportWithFileAsync(pbix, "Progress");
                }
            }


            var dashboards = await client.Dashboards.GetDashboardsAsync();

            Console.WriteLine();
            Console.WriteLine("Dashboards");
            Console.WriteLine("================================");
            foreach (var dashboard in dashboards.Value)
            {
                Console.WriteLine("{0}", dashboard.DisplayName);

                var tiles = await client.Dashboards.GetTilesByDashboardkeyAsync(dashboard.Id);
                foreach (var tile in tiles.Value)
                {
                    Console.WriteLine("-- {0} - {1}", tile.Title, tile.EmbedUrl);
                }
            }

            var reports = await client.Reports.GetReportsAsync();

            Console.WriteLine();
            Console.WriteLine("Reports");
            Console.WriteLine("================================");
            foreach (var report in reports.Value)
            {
                Console.WriteLine("{0} - {1}", report.Name, report.EmbedUrl);
            }

            var datasets = await client.Datasets.GetDatasetsAsync();

            Console.WriteLine();
            Console.WriteLine("Datasets");
            Console.WriteLine("================================");
            foreach (var dataset in datasets.Value)
            {
                Console.WriteLine("{0} ({1})", dataset.Name, dataset.Id);

                try
                {
                    var tables = await client.Datasets.GetTablesByDatasetkeyAsync(dataset.Id);
                    foreach (var table in tables.Value)
                    {
                        Console.WriteLine("-- {0}", table.Name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-- {0}", ex.Message);
                }

                Console.WriteLine();
            }

            var groups = await client.Groups.GetGroupsAsync();

            Console.WriteLine();
            Console.WriteLine("Groups");
            Console.WriteLine("================================");
            foreach (var group in groups.Value)
            {
                Console.WriteLine("{0}", group.Name);

                var groupDashboards = await client.Dashboards.GetDashboardsByGroupAsync(group.Id);
                Console.WriteLine();
                Console.WriteLine("Group Dashboards");
                Console.WriteLine("================================");

                foreach (var groupDashboard in groupDashboards.Value)
                {
                    Console.WriteLine("--{0}", groupDashboard.DisplayName);
                }
            }

            var datasetTables = new List<Table>
            {
                new Table("Users", new List<Column>()
                {
                    new Column {Name = "Id", DataType = "string"},
                    new Column {Name = "FirstName", DataType = "string"},
                    new Column {Name = "LastName", DataType = "string"},
                    new Column {Name = "Email", DataType = "string"}
                })
            };

            //var newDataset = new Dataset("Foobar - " + DateTime.Now.ToShortTimeString(), datasetTables);
            //var foo = await client.Datasets.PostDatasetAsync(newDataset) as Dataset;

            var datasetKey = "4f5cc321-0007-42ff-afea-d7b3926172be";
            var tableName = "Users";

            await client.Datasets.DeleteRowsByDatasetkeyAndTablenameAsync(datasetKey, tableName);

            var rows = new List<User>
            {
                new User{ Id = "1", FirstName= "Wallace", LastName = "Breza" },
                new User{ Id = "2", FirstName= "Jon", LastName = "Gallant" },
                new User{ Id = "3", FirstName= "Will", LastName = "Anderson" },
                new User{ Id = "4", FirstName= "Tony", LastName = "Ferrel" },
            };

            var request = new DatasetOperation<User>(rows);

            await client.Datasets.PostRowsByDatasetkeyAndTablenameAsync(datasetKey, tableName, request);
        }
    }
}
