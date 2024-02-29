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
    [Table("PRODUCTS")]
    public class Products
    {
        [Key]
        [Column(TypeName = "varchar(15)")]
        [Name("productCode")]
        public string ProductCode { get; set; }
        [Column(TypeName = "varchar(70)")]
        [Name("productName")]
        public string ProductName { get; set; }
        [ForeignKey("ProductLines")]
        [Column(TypeName = "varchar(50)")]
        [Name("productLine")]
        public string ProductLine { get; set; }
        [Column(TypeName = "varchar(10)")]
        [Name("productScale")]
        public string ProductScale { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("productVendor")]
        public string ProductVendor { get; set; }
        [Column(TypeName = "text")]
        [Name("productDescription")]
        public string ProductDescription { get; set; }
        [Name("quantityInStock")]
        public short QuantityInStock { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Name("buyPrice")]
        public double BuyPrice { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Name("MSRP")]
        public double MSRP { get; set; }

        [Ignore]
        public ProductLines ProductLines { get; set; }
    }
}
