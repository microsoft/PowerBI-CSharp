using Microsoft.PowerBI.Api.Beta;
using Microsoft.PowerBI.Security;
using Microsoft.Rest;
using MvcApp.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    [Authorize]
    public class EmbedController : Controller
    {
        // GET: Embed
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Dashboards()
        {
            using (var client = CreatePowerBIClient())
            {
                var dashboards = await client.Dashboards.GetDashboardsAsync();
                var viewModel = new DashboardsViewModel
                {
                    Dashboards = dashboards.Value
                };

                return View("Dashboards", viewModel);
            }
        }

        public async Task<ActionResult> Reports()
        {
            using (var client = CreatePowerBIClient())
            {
                var reports = await client.Reports.GetReportsAsync();
                var viewModel = new ReportsViewModel
                {
                    Reports = reports.Value
                };

                return View("Reports", viewModel);
            }
        }

        public async Task<ActionResult> Dashboard(string dashboardId)
        {
            using (var client = CreatePowerBIClient())
            {
                var dashboard = await client.Dashboards.GetDashboardByDashboardkeyAsync(dashboardId);
                var tiles = await client.Dashboards.GetTilesByDashboardkeyAsync(dashboardId);
                var viewModel = new DashboardViewModel
                {
                    Dashboard = dashboard,
                    Tiles = tiles.Value.ToList()
                };

                return View("Dashboard", viewModel);
            }
        }

        public async Task<ActionResult> Report(string reportId)
        {
            using (var client = CreatePowerBIClient())
            {
                var reports = await client.Reports.GetReportsAsync();
                var viewModel = new ReportViewModel
                {
                    Report = reports.Value.FirstOrDefault(r => r.Id == reportId)
                };

                return View("Report", viewModel);
            }
        }

        public async Task<ActionResult> Tile(string dashboardId, string tileId)
        {
            using (var client = CreatePowerBIClient())
            {
                var tile = await client.Dashboards.GetTileByDashboardkeyAndTilekeyAsync(dashboardId, tileId);
                var viewModel = new TileEmbedViewModel
                {
                    Tile = tile
                };

                return View("Tile", viewModel);
            }
        }

        private IPowerBIClient CreatePowerBIClient()
        {
            var baseUri = new Uri("https://api.powerbi.com");

            if (this.User.Identity.IsAuthenticated) {
                var accessToken = TokenManager.Current.ReadToken(this.User.Identity);
                var credentials = new TokenCredentials(accessToken);
                return new PowerBIClient(baseUri, credentials);
            }

            return null;
        }
    }
}