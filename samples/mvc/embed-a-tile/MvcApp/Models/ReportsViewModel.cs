using Microsoft.PowerBI.Api;
using System.Collections.Generic;

namespace MvcApp.Models
{
    public class ReportsViewModel
    {
        public IEnumerable<IReport> Reports { get; set; }
    }
}