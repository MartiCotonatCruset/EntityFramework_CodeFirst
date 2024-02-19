using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.MODEL
{
    class Payments
    {
        public int CustomerNumber { get; set; }
        public string CheckNumber { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
