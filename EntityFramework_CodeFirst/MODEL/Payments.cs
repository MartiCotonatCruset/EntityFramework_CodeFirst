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
        [ForeignKey("Customers")]
        public int CustomerNumber { get; set; }
        public string CheckNumber { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public double Amount { get; set; }

        public Customers Customers { get; set; }
    }
}
