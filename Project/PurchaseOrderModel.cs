using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class PurchaseOrderModel
    {
        public long CarNo { get; set; }
        public string Name { get; set; }
        public string ModelName { get; set; }
        public int Quantity { get; set; }
        public Double Price { get; set; }
    }
}
