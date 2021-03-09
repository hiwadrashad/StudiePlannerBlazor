using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiePlannerBlazor.Server.Migrations
{
    public partial class SeedData3_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 14, 14, 35, 5, 647, DateTimeKind.Local).AddTicks(1985));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27ae633c-ad44-4f5e-8554-be558dfd556d", "AQAAAAEAACcQAAAAEAvF8phZGhc/FBbcmscPPfF6DdKGK49suaP6303bqkXJYGmzoqpWRKG632Qm9nwtHQ==", "b2436019-16f6-49c7-9226-af5379d01dfc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 14, 14, 30, 48, 246, DateTimeKind.Local).AddTicks(2041));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57d75696-2fa1-4af3-8191-c21cdd2274b0", "Passw0rd!", "23b44558-26fb-4522-9123-2f0bca49774d" });
        }
    }
}
