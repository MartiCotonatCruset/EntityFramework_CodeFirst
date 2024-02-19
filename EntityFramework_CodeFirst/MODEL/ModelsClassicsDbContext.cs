using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.MODEL
{
    class ModelsClassicsDbContext: DbContext
    {
        public ModelsClassicsDbContext() { }

        public ModelsClassicsDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //En caso de que el contexto no este configurado, lo configuramos mediante la cadena de conexion
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=MODELSCLASSICS;Uid=root;Pwd=\"\"");
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                .HasKey(o => new { o.OrderNumber, o.ProductCode });
            modelBuilder.Entity<Payments>()
                .HasKey(o => new { o.CustomerNumber, o.CheckNumber });
        }


        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Offices> Offices { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<ProductLines> ProductLines { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
