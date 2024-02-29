using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeDriveRental.Migrations
{
    /// <inheritdoc />
    public partial class bookingtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AspNetUsers_BookedUserId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Cars_BookedCarId",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_BookedUserId",
                table: "Bookings",
                newName: "IX_Bookings_BookedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_BookedCarId",
                table: "Bookings",
                newName: "IX_Bookings_BookedCarId");

            migrationBuilder.AlterColumn<string>(
                name: "BookedUserId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_BookedUserId",
                table: "Bookings",
                column: "BookedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Cars_BookedCarId",
                table: "Bookings",
                column: "BookedCarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_BookedUserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Cars_BookedCarId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_BookedUserId",
                table: "Booking",
                newName: "IX_Booking_BookedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_BookedCarId",
                table: "Booking",
                newName: "IX_Booking_BookedCarId");

            migrationBuilder.AlterColumn<string>(
                name: "BookedUserId",
                table: "Booking",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AspNetUsers_BookedUserId",
                table: "Booking",
                column: "BookedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Cars_BookedCarId",
                table: "Booking",
                column: "BookedCarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
