using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaLinq.Entities
{
    public class BillDetail
    {
        public int BillDetailId { get; set; }
        public int BillNumber { get; set; }
        public List<int> ProductIds { get; set; }
        public List<int> QuantitySolds { get; set; }
        public List<double> ValueSolds { get; set; }
    }
}