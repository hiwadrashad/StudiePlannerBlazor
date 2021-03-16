using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiePlannerBlazor.Server.Migrations
{
    public partial class SeedData_Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 21, 13, 50, 13, 744, DateTimeKind.Local).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91d79dbc-c819-4048-bb97-8b5620f43d0c", "TEST1@HOTMAIL.COM", "TEST1@HOTMAIL.COM", "AQAAAAEAACcQAAAAEMGo+BGrafH1ENbv18/2iYly0SLWGWlBHklMjo5I32HajJ9kMbSPvJ1blRDOImQPsA==", "63edff4c-5d82-49bc-a96e-1604d6f4da0d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27ae633c-ad44-4f5e-8554-be558dfd556d", null, null, "AQAAAAEAACcQAAAAEAvF8phZGhc/FBbcmscPPfF6DdKGK49suaP6303bqkXJYGmzoqpWRKG632Qm9nwtHQ==", "b2436019-16f6-49c7-9226-af5379d01dfc" });
        }
    }
}
