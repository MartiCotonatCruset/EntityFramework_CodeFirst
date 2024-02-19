using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.MODEL
{
    [Table("PAYMENTS")]
    class Payments
    {
        [Key]
        [ForeignKey("Customers")]
        public int CustomerNumber { get; set; }
        [Key]
        public string CheckNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }

        public Customers Customers { get; set; }
    }
}
