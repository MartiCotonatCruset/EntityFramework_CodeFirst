using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.MODEL
{
    [Table("CUSTOMERS")]
    public class Customers
    {
        [Key]
        [Name("customerNumber")]
        public int CustomerNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("customerName")]
        public string CustomerName { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("contactLastName")]
        public string ContactLastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("contactFirstName")]
        public string ContactFirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("phone")]
        public string Phone { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("addressLine1")]
        public string AddressLine1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("addressLine2")]
        public string? AddressLine2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("city")]
        public string City { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("state")]
        public string? State { get; set; }
        [Column(TypeName = "varchar(15)")]
        [Name("postalCode")]
        public string? PostalCode { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("country")]
        public string Country { get; set; }
        [ForeignKey("Employee")]
        [Name("salesRepEmployeeNumber")]
        public int? SalesRepEmployeeNumber { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Name("creditLimit")]
        public decimal? CreditLimit { get; set; }

        [Ignore]
        public Employees Employee { get; set; }
        [Ignore]
        public ICollection<Orders> Orders { get; set; }
        [Ignore]
        public ICollection<Payments> Payments { get; set; }
    }
}
