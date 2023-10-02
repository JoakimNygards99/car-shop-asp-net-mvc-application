using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop.Migrations
{
    /// <inheritdoc />
    public partial class SeedCarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Colour", "Description", "GearBox", "HorsePower", "Mileage", "Model", "ModelYear", "MotorFuel", "Path", "Price" },
                values: new object[,]
                {
                    { 1, "red", "fin bil", "Manual", 499, 13000L, "AudiRS6", 2007, "Disel", "jucke/jucke", 599999 },
                    { 2, "Blue", "fin a3 bil", "Automat", 200, 20000L, "AudiA3", 1999, "Bensin", "jucke/jucke", 90000 }
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
        }
    }
}
