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
    class Orders
    {
        [Key]
        public int OrderNumber { get; set; }
        [Required]
        public Date OrderDate { get; set; }
        [Required]
        public Date RequiredDate { get; set; }
        public Date ShippedDate { get; set; }
        [Required]
        public string Status { get; set; }
        public string Comments { get; set; }
        [Required]
        [ForeignKey("Customers")]
        public int CustomerNumber { get; set; }

        public Customers Customers { get; set; }
    }
}
