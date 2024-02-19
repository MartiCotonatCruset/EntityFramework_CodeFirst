using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.MODEL
{
    [Table("EMPLOYEES")]
    class Employees
    {
        [Key]
        public int EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }

        [ForeignKey("Offices")]
        public string OfficeCode { get; set; }

        [ForeignKey("ReportsToSelfReference")]
        public int ReportsTo { get; set; }
        public string JobTitle { get; set; }

        public Offices Offices { get; set; }

        public Employees ReportsToSelfReference {  get; set; }
    }
}
