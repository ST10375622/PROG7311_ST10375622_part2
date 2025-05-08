using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG7311_ST10375622_part2.Data.Migrations
{
    /// <inheritdoc />
    public partial class prepopulateddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "Name", "Phone", "Role", "UserId" },
                values: new object[] { 3, "jane@employee.com", "Jane Doe", "0871234653", "Manager", "demoUser1" });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "FarmerId", "Description", "Email", "Location", "Name", "Phone", "TypeOfFarmer", "UserId" },
                values: new object[] { 7, "Hello, I am looking to engage with other farmers", "john@gmail.com", "Newcastle", "John Doe", "0871234653", "Dairy Farmer", "demoUser1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Description", "FarmerId", "ProductName", "ProductionDate" },
                values: new object[] { 5, "Fruits", "The best oranges in the area", 7, "oranges", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerId",
                keyValue: 7);
        }
    }
}
