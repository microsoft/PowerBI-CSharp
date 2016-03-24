using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHost.Models
{
    public class DatasetOperation<T>
    {
        public DatasetOperation(IEnumerable<T> rows)
        {
            this.Rows = rows;
        }

        public IEnumerable<T> Rows { get; set; }
    }
}
