using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomm.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DisplayOrder", "Title" },
                values: new object[] { 10, new DateTime(2022, 6, 25, 11, 10, 8, 974, DateTimeKind.Local).AddTicks(7418), 1, "Apple" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DisplayOrder", "Title" },
                values: new object[] { 11, new DateTime(2022, 6, 25, 11, 10, 8, 974, DateTimeKind.Local).AddTicks(7464), 2, "Lenove" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
