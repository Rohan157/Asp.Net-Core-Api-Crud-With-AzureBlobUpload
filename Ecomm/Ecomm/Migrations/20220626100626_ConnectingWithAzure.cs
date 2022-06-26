using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomm.Migrations
{
    public partial class ConnectingWithAzure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.AddColumn<string>(
                name: "CategoryImagePath",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryImagePath",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DisplayOrder", "Title" },
                values: new object[] { 10, new DateTime(2022, 6, 25, 11, 10, 8, 974, DateTimeKind.Local).AddTicks(7418), 1, "Apple" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DisplayOrder", "Title" },
                values: new object[] { 11, new DateTime(2022, 6, 25, 11, 10, 8, 974, DateTimeKind.Local).AddTicks(7464), 2, "Lenove" });
        }
    }
}
