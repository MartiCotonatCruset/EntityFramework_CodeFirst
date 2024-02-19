using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.MODEL
{
    [Table("PRODUCTS")]
    class Products
    {
        [Key]
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        [ForeignKey("ProductLines")]
        public string ProductLine { get; set; }
        public string ProductScale { get; set; }
        public string ProductVendor { get; set; }
        public string ProductDescription { get; set; }
        public short QuantityInStock { get; set; }
        public double BuyPrice { get; set; }
        public double MSRP { get; set; }

        public ProductLines ProductLines { get; set; }
    }
}
