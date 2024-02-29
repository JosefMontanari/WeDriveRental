using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeDriveRental.Migrations
{
    /// <inheritdoc />
    public partial class addcars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Description", "ImageUrl", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "E 220 d 194hk, AMG Pano Burmester Drag 360° Navi", "https://kvdbil-object-images.imgix.net/7178075/848243.jpg?w=1920&auto=format", false, "Mercedes E-Klass", 1799m },
                    { 2, "XCeed Plug-in, Advance Plus B-kam", "https://kvdbil-object-images.imgix.net/7191259/995776.jpg?w=1920&auto=format", false, "KIA Cee'd", 899m },
                    { 3, "T2 129hk, Momentum Läder Teknikpak D-värm VOC", "https://kvdbil-object-images.imgix.net/7195428/c474c115.jpg?w=1920&auto=format", false, "Volvo XC40", 1199m },
                    { 4, "Sportback 35 TFSI 150hk", "Url", false, "Audi A3", 999m },
                    { 5, "xDrive40d, G07 (340hk+11hk), M Sport Innovation", "https://kvdbil-object-images.imgix.net/7194305/995071.jpg?w=1920&auto=format", false, "BMW X7", 2199m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
