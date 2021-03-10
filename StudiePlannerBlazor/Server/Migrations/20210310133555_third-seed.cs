using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiePlannerBlazor.Server.Migrations
{
    public partial class thirdseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 15, 14, 35, 54, 707, DateTimeKind.Local).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "75fe95a2-fa22-4752-b126-4dbbb942e095", "9e6437fe-4b78-4548-9346-13edc1f28ba2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 13, 15, 40, 21, 346, DateTimeKind.Local).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4bdc466b-4911-41d9-95f9-9bf3fb27411d", "100b408a-bdd0-4c2b-91d9-63e2dcc8f23b" });
        }
    }
}
