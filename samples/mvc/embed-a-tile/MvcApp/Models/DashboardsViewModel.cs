using Microsoft.PowerBI.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class DashboardsViewModel
    {
        public IEnumerable<IDashboard> Dashboards { get; set; }
    }
}