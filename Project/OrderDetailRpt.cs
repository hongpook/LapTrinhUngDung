using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class OrderDetailRpt
    {
        public int idOrder { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public bool confirmation { get; set; }
        public DateTime onOrder { get; set; }
        public double Price { get; set; }
        public int carNo { get; set; }
        public string carName { get; set; }
        public string ModelName { get; set; }
        public int quantity { get; set; }
    }
}
