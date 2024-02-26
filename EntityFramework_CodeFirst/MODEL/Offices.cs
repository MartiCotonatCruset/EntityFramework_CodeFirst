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
    [Table("OFFICES")]
    public class Offices
    {
        [Key]
        [Column(TypeName = "varchar(10)")]
        [Name("officeCode")]
        public string OfficeCode { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("city")]
        public string City { get; set; }
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
        [Name("state")]
        public string? State { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Name("country")]
        public string Country { get; set; }
        [Column(TypeName = "varchar(15)")]
        [Name("postalCode")]
        public string PostalCode { get; set; }
        [Column(TypeName = "varchar(10)")]
        [Name("territory")]
        public string Territory { get; set; }
    }
}
