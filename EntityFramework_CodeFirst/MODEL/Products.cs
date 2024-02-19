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
        [Required]
        public string ProductName { get; set; }

        [Required]
        [ForeignKey("ProductLines")]
        public string ProductLine { get; set; }
        [Required]
        public string ProductScale { get; set; }
        [Required]
        public string ProductVendor { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public short QuantityInStock { get; set; }
        [Required]
        public double BuyPrice { get; set; }
        [Required]
        public double MSRP { get; set; }

        public ProductLines ProductLines { get; set; }
    }
}
