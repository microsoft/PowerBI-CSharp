using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.PowerBI.Api.Beta;
using Microsoft.PowerBI.Api.Beta.Models;
using Microsoft.Rest;
using Console = System.Console;
using Microsoft.Threading;
using ApiHost.Models;
using System.IO;
using System.Configuration;

namespace ApiHost
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncPump.Run(async delegate
            {
                await DemoAsync();
            });

            Console.ReadKey(true);
        }

        static async Task DemoAsync()
        {
            var resourceUri = "https://analysis.windows.net/powerbi/api";
            var authority = "https://login.windows.net/common/oauth2/authorize";
            var clientId = "f3ea3093-dec5-48ad-97e5-ab5f491a848e";
            var redirectUri = "https://login.live.com/oauth20_desktop.srf";

            var tokenCache = new TokenCache();
            var authContext = new AuthenticationContext(authority, tokenCache);
            var authResult = authContext.AcquireToken(resourceUri, clientId, new Uri(redirectUri), PromptBehavior.Always);

            var credentials = new TokenCredentials(authResult.AccessToken, authResult.AccessTokenType);
            var client = new PowerBIClient(credentials);
            client.BaseUri = new Uri("https://api.powerbi.com");

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
