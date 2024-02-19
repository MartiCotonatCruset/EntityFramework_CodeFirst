using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.MODEL
{
    [Table("ORDERS")]
    class Orders
    {
        [Key]
        public int OrderNumber { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        [Required]
        public string Status { get; set; }
        public string Comments { get; set; }
        [Required]
        [ForeignKey("Customers")]
        public int CustomerNumber { get; set; }

        public Customers Customers { get; set; }
    }
}
