using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeDriveRental.Migrations
{
    /// <inheritdoc />
    public partial class url : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://kvdbil-object-images.imgix.net/7193409/953141.jpg?w=1920&auto=format");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "Url");
        }
    }
}
