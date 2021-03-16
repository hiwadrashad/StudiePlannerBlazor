using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiePlannerBlazor.Server.Migrations
{
    public partial class SeedData_Update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 21, 14, 45, 11, 110, DateTimeKind.Local).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50da17b7-b482-4ede-8391-b3741071f1a4", "AQAAAAEAACcQAAAAECfOcT2b/fNnPS5ZC65YKIKecfzwGKUmFhOLZNHeXh6USPmuEXN838VrMNVNJxuhNw==", "fa0b2f41-27d7-4777-8634-f3a2dffc3ee8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 21, 14, 44, 56, 551, DateTimeKind.Local).AddTicks(9886));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d9d2874-4a1b-4f1a-82f8-64b98ad72264", "AQAAAAEAACcQAAAAELHqlLsBSwcVYqA6Kkh7wuI7RG2K+XagaKoTYLg9CgUGKxCQ2KTcpcHdMSP8lBh1FQ==", "ec5fca6f-4c03-4c82-879c-fe33281e5d9a" });
        }
    }
}
