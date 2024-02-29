using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EntityFramework_CodeFirst.MODEL
{
    [Table("ORDERS")]
    public class Orders
    {
        [Key]
        [Name("orderNumber")]
        public int OrderNumber { get; set; }
        [Column(TypeName = "date")]
        [Name("orderDate")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "date")]
        [Name("requiredDate")]
        public DateTime RequiredDate { get; set; }
        [Column(TypeName = "date")]
        [Name("shippedDate")]
        public DateTime? ShippedDate { get; set; }
        [Column(TypeName = "varchar(15)")]
        [Name("status")]
        public string Status { get; set; }
        [Column(TypeName = "text")]
        [Name("comments")]
        public string? Comments { get; set; }
        [ForeignKey("Customers")]
        [Name("customerNumber")]
        public int CustomerNumber { get; set; }

        [Ignore]
        public Customers Customers { get; set; }
    }
}
