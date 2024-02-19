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
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        [ForeignKey("Customer")]
        public int CustomerNumber { get; set; }

        public Customer Customer { get; set; }
    }
}
