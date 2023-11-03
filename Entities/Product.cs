using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaLinq.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double PriceUnit { get; set; }
        public int  Quantity { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
    }
}