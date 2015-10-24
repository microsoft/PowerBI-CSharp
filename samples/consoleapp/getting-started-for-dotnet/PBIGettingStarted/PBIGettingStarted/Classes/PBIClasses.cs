using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBIGettingStarted
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsCompete { get; set; }
        public DateTime ManufacturedOn { get; set; }
    }

    //Example of a new Product schema
    public class Product2
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsCompete { get; set; }
        public DateTime ManufacturedOn { get; set; }

        public string NewColumn { get; set; }
    }
}
