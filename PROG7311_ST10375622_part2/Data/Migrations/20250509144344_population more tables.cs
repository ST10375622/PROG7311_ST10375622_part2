using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PROG7311_ST10375622_part2.Data.Migrations
{
    /// <inheritdoc />
    public partial class populationmoretables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Contenet", "CreatedAt", "FarmerId", "Title", "category" },
                values: new object[] { 7, "I use compost and crop rotation to Maintain healthy soil.", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Tips for healthy Soil", "General" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Description", "FarmerId", "ProductName", "ProductionDate" },
                values: new object[,]
                {
                    { 6, "Fruits", "The season is about to end", 3, "Watermelons", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Livestock", "Sourced out for their meat", 1, "Pigs", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "CreatedAt", "FarmerId", "PostId" },
                values: new object[] { 7, "Thank you for this tip. It was really helpful. I will try it during composting season.", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 7);
        }
    }
}
