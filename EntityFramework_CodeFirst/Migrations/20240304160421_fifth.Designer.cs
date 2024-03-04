﻿// <auto-generated />
using System;
using EntityFramework_CodeFirst.MODEL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFramework_CodeFirst.Migrations
{
    [DbContext(typeof(ModelsClassicsDbContext))]
    [Migration("20240304160421_fifth")]
    partial class fifth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.Customers", b =>
                {
                    b.Property<int>("CustomerNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ContactFirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ContactLastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("CreditLimit")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(15)");

                    b.Property<int?>("SalesRepEmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("varchar(50)");

                    b.HasKey("CustomerNumber");

                    b.HasIndex("SalesRepEmployeeNumber");

                    b.ToTable("CUSTOMERS");
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.Employees", b =>
                {
                    b.Property<int>("EmployeeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ManagerEmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("OfficeCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("ReportsTo")
                        .HasColumnType("int");

                    b.HasKey("EmployeeNumber");

                    b.HasIndex("ManagerEmployeeNumber");

                    b.HasIndex("OfficeCode");

                    b.ToTable("EMPLOYEES");
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.Offices", b =>
                {
                    b.Property<string>("OfficeCode")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("State")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Territory")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("OfficeCode");

                    b.ToTable("OFFICES");
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.OrderDetails", b =>
                {
                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("ProductCode")
                        .HasColumnType("varchar(15)");

                    b.Property<short>("OrderLineNumber")
                        .HasColumnType("smallint");

                    b.Property<decimal>("PriceEach")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("int");

                    b.HasKey("OrderNumber", "ProductCode");

                    b.HasIndex("ProductCode");

                    b.ToTable("ORDERDETAILS");
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.Orders", b =>
                {
                    b.Property<int>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("OrderNumber");

                    b.HasIndex("CustomerNumber");

                    b.ToTable("ORDERS");
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.Payments", b =>
                {
                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int");

                    b.Property<string>("CheckNumber")
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("date");

                    b.HasKey("CustomerNumber", "CheckNumber");

                    b.ToTable("PAYMENTS");
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.ProductLines", b =>
                {
                    b.Property<string>("ProductLine")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("HtmlDescription")
                        .HasColumnType("mediumtext");

                    b.Property<byte[]>("Image")
                        .HasColumnType("mediumblob");

                    b.Property<string>("TextDescription")
                        .HasColumnType("varchar(4000)");

                    b.HasKey("ProductLine");

                    b.ToTable("PRODUCTLINES");
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.Products", b =>
                {
                    b.Property<string>("ProductCode")
                        .HasColumnType("varchar(15)");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("MSRP")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductLine")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<string>("ProductScale")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ProductVendor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<short>("QuantityInStock")
                        .HasColumnType("smallint");

                    b.HasKey("ProductCode");

                    b.HasIndex("ProductLine");

                    b.ToTable("PRODUCTS");
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.Customers", b =>
                {
                    b.HasOne("EntityFramework_CodeFirst.MODEL.Employees", "Employee")
                        .WithMany("Customers")
                        .HasForeignKey("SalesRepEmployeeNumber");
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.Employees", b =>
                {
                    b.HasOne("EntityFramework_CodeFirst.MODEL.Employees", "Manager")
                        .WithMany("Employeess")
                        .HasForeignKey("ManagerEmployeeNumber");

                    b.HasOne("EntityFramework_CodeFirst.MODEL.Offices", "Offices")
                        .WithMany("Employees")
                        .HasForeignKey("OfficeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.OrderDetails", b =>
                {
                    b.HasOne("EntityFramework_CodeFirst.MODEL.Orders", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework_CodeFirst.MODEL.Products", "Products")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.Orders", b =>
                {
                    b.HasOne("EntityFramework_CodeFirst.MODEL.Customers", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.Payments", b =>
                {
                    b.HasOne("EntityFramework_CodeFirst.MODEL.Customers", "Customers")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFramework_CodeFirst.MODEL.Products", b =>
                {
                    b.HasOne("EntityFramework_CodeFirst.MODEL.ProductLines", "ProductLines")
                        .WithMany("Productes")
                        .HasForeignKey("ProductLine")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
