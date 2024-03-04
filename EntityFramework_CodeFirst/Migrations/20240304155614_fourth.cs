using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework_CodeFirst.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMPLOYEES_EMPLOYEES_ReportsTo",
                table: "EMPLOYEES");

            migrationBuilder.DropIndex(
                name: "IX_EMPLOYEES_ReportsTo",
                table: "EMPLOYEES");

            migrationBuilder.AddColumn<int>(
                name: "ManagerEmployeeNumber",
                table: "EMPLOYEES",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_ManagerEmployeeNumber",
                table: "EMPLOYEES",
                column: "ManagerEmployeeNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_EMPLOYEES_EMPLOYEES_ManagerEmployeeNumber",
                table: "EMPLOYEES",
                column: "ManagerEmployeeNumber",
                principalTable: "EMPLOYEES",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMPLOYEES_EMPLOYEES_ManagerEmployeeNumber",
                table: "EMPLOYEES");

            migrationBuilder.DropIndex(
                name: "IX_EMPLOYEES_ManagerEmployeeNumber",
                table: "EMPLOYEES");

            migrationBuilder.DropColumn(
                name: "ManagerEmployeeNumber",
                table: "EMPLOYEES");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_ReportsTo",
                table: "EMPLOYEES",
                column: "ReportsTo");

            migrationBuilder.AddForeignKey(
                name: "FK_EMPLOYEES_EMPLOYEES_ReportsTo",
                table: "EMPLOYEES",
                column: "ReportsTo",
                principalTable: "EMPLOYEES",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
