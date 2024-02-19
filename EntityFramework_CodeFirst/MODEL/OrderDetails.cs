using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.MODEL
{
    class OrderDetails
    {
        public int OrderNumber { get; set; }
        public string ProductName { get; set; }
        public int QuantityOrdered { get; set; }
        public double PriceEach { get; set; }
        public short OrderLineNumber { get; set; }
    }
}
