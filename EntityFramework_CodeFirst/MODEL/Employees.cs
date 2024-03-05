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
    public class Employees
    {
        [Key]
        public int EmployeeNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Extension { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [ForeignKey("Offices")]
        [Column(TypeName = "varchar(10)")]
        public string OfficeCode { get; set; }
        [ForeignKey("ReportsToSelfReference")]
        public int? ReportsTo { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string JobTitle { get; set; }

        public Offices Offices { get; set; }
        public ICollection<Customers> Customers { get; set; }
        //Manager
        public ICollection<Employees>? Employeess { get; set; }
        public Employees? Manager {  get; set; }
    }
}
