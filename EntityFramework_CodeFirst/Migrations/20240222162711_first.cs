using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework_CodeFirst.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OFFICES",
                columns: table => new
                {
                    OfficeCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    State = table.Column<string>(type: "varchar(50)", nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    Territory = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFFICES", x => x.OfficeCode);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTLINES",
                columns: table => new
                {
                    ProductLine = table.Column<string>(type: "varchar(50)", nullable: false),
                    TextDescription = table.Column<string>(type: "varchar(4000)", nullable: true),
                    HtmlDescription = table.Column<string>(type: "mediumtext", nullable: true),
                    Image = table.Column<byte[]>(type: "mediumblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTLINES", x => x.ProductLine);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Extension = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    OfficeCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    ReportsTo = table.Column<int>(nullable: true),
                    JobTitle = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.EmployeeNumber);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_OFFICES_OfficeCode",
                        column: x => x.OfficeCode,
                        principalTable: "OFFICES",
                        principalColumn: "OfficeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_EMPLOYEES_ReportsTo",
                        column: x => x.ReportsTo,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    ProductName = table.Column<string>(type: "varchar(70)", nullable: false),
                    ProductLine = table.Column<string>(type: "varchar(50)", nullable: false),
                    ProductScale = table.Column<string>(type: "varchar(10)", nullable: false),
                    ProductVendor = table.Column<string>(type: "varchar(50)", nullable: false),
                    ProductDescription = table.Column<string>(type: "text", nullable: false),
                    QuantityInStock = table.Column<short>(nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MSRP = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_PRODUCTLINES_ProductLine",
                        column: x => x.ProductLine,
                        principalTable: "PRODUCTLINES",
                        principalColumn: "ProductLine",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ContactLastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ContactFirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(15)", nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", nullable: false),
                    SalesRepEmployeeNumber = table.Column<int>(nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.CustomerNumber);
                    table.ForeignKey(
                        name: "FK_CUSTOMERS_EMPLOYEES_SalesRepEmployeeNumber",
                        column: x => x.SalesRepEmployeeNumber,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "date", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "varchar(15)", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    CustomerNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_ORDERS_CUSTOMERS_CustomerNumber",
                        column: x => x.CustomerNumber,
                        principalTable: "CUSTOMERS",
                        principalColumn: "CustomerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTS",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(nullable: false),
                    CheckNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTS", x => new { x.CustomerNumber, x.CheckNumber });
                    table.ForeignKey(
                        name: "FK_PAYMENTS_CUSTOMERS_CustomerNumber",
                        column: x => x.CustomerNumber,
                        principalTable: "CUSTOMERS",
                        principalColumn: "CustomerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDERDETAILS",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    QuantityOrdered = table.Column<int>(nullable: false),
                    PriceEach = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OrderLineNumber = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERDETAILS", x => new { x.OrderNumber, x.ProductCode });
                    table.ForeignKey(
                        name: "FK_ORDERDETAILS_ORDERS_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "ORDERS",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERDETAILS_PRODUCTS_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_SalesRepEmployeeNumber",
                table: "CUSTOMERS",
                column: "SalesRepEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_OfficeCode",
                table: "EMPLOYEES",
                column: "OfficeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_ReportsTo",
                table: "EMPLOYEES",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERDETAILS_ProductCode",
                table: "ORDERDETAILS",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_CustomerNumber",
                table: "ORDERS",
                column: "CustomerNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_ProductLine",
                table: "PRODUCTS",
                column: "ProductLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDERDETAILS");

            migrationBuilder.DropTable(
                name: "PAYMENTS");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "PRODUCTLINES");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "OFFICES");
        }
    }
}
