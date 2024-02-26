using CsvHelper.Configuration.Attributes;
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
        [Name("employeeNumber")]
        public int EmployeeNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("lastName")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("firstName")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(10)")]
        [Name("extension")]
        public string Extension { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Name("email")]
        public string Email { get; set; }
        [ForeignKey("Offices")]
        [Column(TypeName = "varchar(10)")]
        [Name("officeCode")]
        public string OfficeCode { get; set; }
        [ForeignKey("ReportsToSelfReference")]
        [Name("reportsTo")]
        public int? ReportsTo { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("jobTitle")]
        public string JobTitle { get; set; }

        public Offices Offices { get; set; }
        public Employees ReportsToSelfReference {  get; set; }
    }
}
