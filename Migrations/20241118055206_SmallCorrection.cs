using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkTogether.Migrations
{
    /// <inheritdoc />
    public partial class SmallCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_employees_Name",
                table: "Employees",
                newName: "IX_Employees_Name");

            migrationBuilder.RenameIndex(
                name: "IX_employees_Mail",
                table: "Employees",
                newName: "IX_Employees_Mail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employees");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_Name",
                table: "employees",
                newName: "IX_employees_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_Mail",
                table: "employees",
                newName: "IX_employees_Mail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "Id");
        }
    }
}
