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
    public class Products
    {
        [Key]
        [Column(TypeName = "varchar(15)")]
        public string ProductCode { get; set; }
        [Column(TypeName = "varchar(70)")]
        public string ProductName { get; set; }
        [ForeignKey("ProductLines")]
        [Column(TypeName = "varchar(50)")]
        public string ProductLine { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string ProductScale { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ProductVendor { get; set; }
        [Column(TypeName = "text")]
        public string ProductDescription { get; set; }
        public short QuantityInStock { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double BuyPrice { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double MSRP { get; set; }

        public ProductLines ProductLines { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
