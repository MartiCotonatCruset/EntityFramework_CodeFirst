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
        [Column(TypeName = "varchar(50)")]
        public string CheckNumber { get; set; }
<<<<<<< HEAD
        [Column(TypeName = "date")]
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
=======
        [Required]
        public Date PaymentDate { get; set; }
        [Required]
>>>>>>> 4462df83d8a252d4f9448120cca6286d007ecb0d
        public double Amount { get; set; }

        public Customers Customers { get; set; }
    }
}
