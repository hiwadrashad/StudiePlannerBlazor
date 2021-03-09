using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiePlannerBlazor.Server.Migrations
{
    public partial class SeedData2_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 13, 13, 56, 41, 946, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "546b727a-610b-4566-8bfc-7ab452fa5d73", null, "1dd81378-7601-4083-8ada-fe7dac5ee27f" });
        }
    }
}
