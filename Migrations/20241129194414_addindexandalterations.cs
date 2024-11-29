using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkTogether.Migrations
{
    /// <inheritdoc />
    public partial class addindexandalterations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ParkingCells_Location",
                table: "ParkingCells",
                column: "Location",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ParkingCells_Location",
                table: "ParkingCells");
        }
    }
}
