using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Beta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class DashboardViewModel
    {
        public Dashboard Dashboard { get; set; }
        public IEnumerable<Tile> Tiles { get; set; }
    }
}