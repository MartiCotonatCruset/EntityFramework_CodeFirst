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
    [Table("PRODUCTLINES")]
    public class ProductLines
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        [Name("productLine")]
        public string ProductLine { get; set; }
        [Column(TypeName = "varchar(4000)")]
        [Name("textDescription")]
        public string? TextDescription { get; set; }
        [Column(TypeName = "mediumtext")]
        [Name("htmlDescription")]
        public string? HtmlDescription { get; set; }
        [Column(TypeName = "mediumblob")]
        [Name("image")]
        public string? Image { get; set; }
    }
}
