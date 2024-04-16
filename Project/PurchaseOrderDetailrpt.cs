using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class PurchaseOrderDetailrpt
    {
        public int PurchaseOrderID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime OnOrder { get; set; }
        public int CarNo { get; set; }
        public string Name { get; set; }
        public string ModelName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
