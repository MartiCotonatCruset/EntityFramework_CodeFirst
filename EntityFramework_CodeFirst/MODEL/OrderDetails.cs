using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.MODEL
{
    [Table("ORDERDETAILS")]
    class OrderDetails
    {
        [ForeignKey("Orders")]
        public int OrderNumber { get; set; }
        [ForeignKey("Products")]
        public string ProductCode { get; set; }
        public int QuantityOrdered { get; set; }
        public double PriceEach { get; set; }
        public short OrderLineNumber { get; set; }

        public Orders Orders { get; set; }
        public Products Products { get; set; }
    }
}
