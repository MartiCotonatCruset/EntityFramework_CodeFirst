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
    class Payments
    {
        [ForeignKey("Customers")]
        public int CustomerNumber { get; set; }
        public string CheckNumber { get; set; }
        [Required]
        public Date PaymentDate { get; set; }
        [Required]
        public double Amount { get; set; }

        public Customers Customers { get; set; }
    }
}
