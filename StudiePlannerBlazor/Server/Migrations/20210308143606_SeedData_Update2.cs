using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiePlannerBlazor.Server.Migrations
{
    public partial class SeedData_Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 13, 14, 17, 25, 924, DateTimeKind.Local).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f69df5c6-32da-40c7-8144-57af57d0dc6d", "AQAAAAEAACcQAAAAEHjsKXdmWBh2n4LMr60mo3b2zma6XZaCba6v+X60OzGPBYq3uPsddtQM1ruMNH1OCg==", "6b3629fb-01de-4683-93d7-40c201afa580" });
        }
    }
}
