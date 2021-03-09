using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiePlannerBlazor.Server.Migrations
{
    public partial class SeedData_Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bdc466b-4911-41d9-95f9-9bf3fb27411d", "TestPassword123!", "100b408a-bdd0-4c2b-91d9-63e2dcc8f23b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 13, 15, 36, 6, 524, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7b64d29-0c9f-447c-9973-48c133cce800", "Passw0rd!", "84d64d23-4de6-4545-9615-9dbda7172c2e" });
        }
    }
}
