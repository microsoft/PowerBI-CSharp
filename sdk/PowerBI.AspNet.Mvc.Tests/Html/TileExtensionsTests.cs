using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.PowerBI.AspNet.Mvc.Html;
using System.Web.Mvc;
using Microsoft.PowerBI.Api.Beta.Models;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.AspNet.Mvc.Tests.Models;

namespace Microsoft.PowerBI.AspNet.Mvc.Tests.Html
{
    [TestClass]
    public class TileExtensionsTests
    {
        private HtmlHelper<TileViewModel> htmlHelper;
        private ITile Tile;
        private TileViewModel viewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            this.Tile = new Tile
            {
                Id = "ce402b30-3611-4b26-a6a2-750a46a9f3e0",
                EmbedUrl = "https://msit.powerbi.com/embed?dashboardId=86ffe081-a67a-4337-b141-62344e514af5&tileId=cbc13590-7b9b-4f00-b2af-d562534ac674"
            };
            this.viewModel = new TileViewModel { Tile = this.Tile };
            this.htmlHelper = TestHelper.CreateHtmlHelper(new ViewDataDictionary<TileViewModel>(this.viewModel));
        }

        [TestMethod]
        public void TileWithEmbedUrl()
        {
            var expectedHtml = "<div id=\"myTile\" powerbi-embed=\"https://msit.powerbi.com/embed?dashboardId=86ffe081-a67a-4337-b141-62344e514af5&amp;tileId=cbc13590-7b9b-4f00-b2af-d562534ac674\" powerbi-tile=\"\"></div>";
            var actualHtml = this.htmlHelper.PowerBITile("myTile", this.viewModel.Tile.EmbedUrl);

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void TileWithEmbedUrlAndAttrubites()
        {
            var expectedHtml = "<div class=\"powerbi-tile\" id=\"myTile\" powerbi-embed=\"https://msit.powerbi.com/embed?dashboardId=86ffe081-a67a-4337-b141-62344e514af5&amp;tileId=cbc13590-7b9b-4f00-b2af-d562534ac674\" powerbi-tile=\"\"></div>";
            var actualHtml = this.htmlHelper.PowerBITile("myTile", this.viewModel.Tile.EmbedUrl, new { @class = "powerbi-tile" });

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void TileWithTile()
        {
            var expectedHtml = "<div id=\"myTile\" powerbi-embed=\"https://msit.powerbi.com/embed?dashboardId=86ffe081-a67a-4337-b141-62344e514af5&amp;tileId=cbc13590-7b9b-4f00-b2af-d562534ac674\" powerbi-tile=\"ce402b30-3611-4b26-a6a2-750a46a9f3e0\"></div>";
            var actualHtml = this.htmlHelper.PowerBITile("myTile", this.viewModel.Tile);

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void TileWithTileAndAttrubites()
        {
            var expectedHtml = "<div class=\"powerbi-tile\" id=\"myTile\" powerbi-embed=\"https://msit.powerbi.com/embed?dashboardId=86ffe081-a67a-4337-b141-62344e514af5&amp;tileId=cbc13590-7b9b-4f00-b2af-d562534ac674\" powerbi-tile=\"ce402b30-3611-4b26-a6a2-750a46a9f3e0\"></div>";
            var actualHtml = this.htmlHelper.PowerBITile("myTile", this.viewModel.Tile, new { @class = "powerbi-tile" });

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void TileForWithEmbedUrl()
        {
            var expectedHtml = "<div id=\"Tile_EmbedUrl\" powerbi-embed=\"https://msit.powerbi.com/embed?dashboardId=86ffe081-a67a-4337-b141-62344e514af5&amp;tileId=cbc13590-7b9b-4f00-b2af-d562534ac674\" powerbi-tile=\"\"></div>";
            var actualHtml = this.htmlHelper.PowerBITileFor(m => m.Tile.EmbedUrl);

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void TileForWithTile()
        {
            var expectedHtml = "<div id=\"Tile\" powerbi-embed=\"https://msit.powerbi.com/embed?dashboardId=86ffe081-a67a-4337-b141-62344e514af5&amp;tileId=cbc13590-7b9b-4f00-b2af-d562534ac674\" powerbi-tile=\"ce402b30-3611-4b26-a6a2-750a46a9f3e0\"></div>";
            var actualHtml = this.htmlHelper.PowerBITileFor(m => m.Tile);

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void TileForWithTileAndAttributes()
        {
            var expectedHtml = "<div id=\"Tile\" powerbi-embed=\"https://msit.powerbi.com/embed?dashboardId=86ffe081-a67a-4337-b141-62344e514af5&amp;tileId=cbc13590-7b9b-4f00-b2af-d562534ac674\" powerbi-tile=\"ce402b30-3611-4b26-a6a2-750a46a9f3e0\" style=\"width:500px;height:500px;\"></div>";
            var actualHtml = this.htmlHelper.PowerBITileFor(m => m.Tile, new { style = "width:500px;height:500px;" });

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void TileForWithEmbedUrlAndAttributes()
        {
            var expectedHtml = "<div class=\"powerbi-tile\" id=\"Tile_EmbedUrl\" powerbi-embed=\"https://msit.powerbi.com/embed?dashboardId=86ffe081-a67a-4337-b141-62344e514af5&amp;tileId=cbc13590-7b9b-4f00-b2af-d562534ac674\" powerbi-tile=\"\"></div>";
            var actualHtml = this.htmlHelper.PowerBITileFor(m => m.Tile.EmbedUrl, new { @class = "powerbi-tile" });

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }
    }
}
