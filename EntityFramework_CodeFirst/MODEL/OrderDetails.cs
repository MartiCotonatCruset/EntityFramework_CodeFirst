using CsvHelper.Configuration.Attributes;
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
    public class OrderDetails
    {
        [ForeignKey("Orders")]
        [Name("orderNumber")]
        public int OrderNumber { get; set; }
        [ForeignKey("Products")]
        [Column(TypeName = "varchar(15)")]
        [Name("productCode")]
        public string ProductCode { get; set; }
        [Name("quantityOrdered")]
        public int QuantityOrdered { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Name("priceEach")]
        public double PriceEach { get; set; }
        [Name("orderLineNumber")]
        public short OrderLineNumber { get; set; }

        public Orders Orders { get; set; }
        public Products Products { get; set; }
    }
}
