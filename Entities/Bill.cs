using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaLinq.Entities
{
    public class Bill
    {
        public int BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public int ClientId { get; set; }
        public double TotalBill { get; set; }
    }
}