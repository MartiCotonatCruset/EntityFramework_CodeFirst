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
        public int CustomerNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CustomerName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ContactLastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ContactFirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string AddressLine1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? AddressLine2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? State { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string? PostalCode { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }
        [ForeignKey("Employee")]
        public int? SalesRepEmployeeNumber { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? CreditLimit { get; set; }

        public Employees Employee { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Payments> Payments { get; set; }
    }
}
