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
        public int CustomerNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CheckNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public double Amount { get; set; }

        public Customers Customers { get; set; }
    }
}
