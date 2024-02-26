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
    [Table("PAYMENTS")]
    public class Payments
    {
        [ForeignKey("Customers")]
        [Name("customerNumber")]
        public int CustomerNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("checkNumber")]
        public string CheckNumber { get; set; }
        [Column(TypeName = "date")]
        [Name("paymentDate")]
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Name("amount")]
        public double Amount { get; set; }

        public Customers Customers { get; set; }
    }
}
