using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkTogether.Migrations
{
    /// <inheritdoc />
    public partial class Corrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Employees_EmployeeId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Guests_GuestId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ParkingCells_ParkingCellId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Vehicle_VehicleId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Employees_EmployeeId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Guests_GuestId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_GuestId",
                table: "Vehicles",
                newName: "IX_Vehicles_GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_EmployeeId",
                table: "Vehicles",
                newName: "IX_Vehicles_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_VehicleId",
                table: "Reservations",
                newName: "IX_Reservations_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_ParkingCellId",
                table: "Reservations",
                newName: "IX_Reservations_ParkingCellId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_GuestId",
                table: "Reservations",
                newName: "IX_Reservations_GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_EmployeeId",
                table: "Reservations",
                newName: "IX_Reservations_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Employees_EmployeeId",
                table: "Reservations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_GuestId",
                table: "Reservations",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ParkingCells_ParkingCellId",
                table: "Reservations",
                column: "ParkingCellId",
                principalTable: "ParkingCells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Vehicles_VehicleId",
                table: "Reservations",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Employees_EmployeeId",
                table: "Vehicles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Guests_GuestId",
                table: "Vehicles",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Employees_EmployeeId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_GuestId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ParkingCells_ParkingCellId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Vehicles_VehicleId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Employees_EmployeeId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Guests_GuestId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_GuestId",
                table: "Vehicle",
                newName: "IX_Vehicle_GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_EmployeeId",
                table: "Vehicle",
                newName: "IX_Vehicle_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_VehicleId",
                table: "Reservation",
                newName: "IX_Reservation_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ParkingCellId",
                table: "Reservation",
                newName: "IX_Reservation_ParkingCellId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_GuestId",
                table: "Reservation",
                newName: "IX_Reservation_GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_EmployeeId",
                table: "Reservation",
                newName: "IX_Reservation_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Employees_EmployeeId",
                table: "Reservation",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Guests_GuestId",
                table: "Reservation",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ParkingCells_ParkingCellId",
                table: "Reservation",
                column: "ParkingCellId",
                principalTable: "ParkingCells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Vehicle_VehicleId",
                table: "Reservation",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Employees_EmployeeId",
                table: "Vehicle",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Guests_GuestId",
                table: "Vehicle",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
