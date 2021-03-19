using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiePlannerBlazor.Server.Migrations
{
    public partial class NewUserInSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 21, 15, 9, 4, 710, DateTimeKind.Local).AddTicks(5457));

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "Email", "PersonalContact", "TelephoneNumber" },
                values: new object[] { 2, new DateTime(2021, 3, 21, 15, 9, 4, 712, DateTimeKind.Local).AddTicks(4428), "Appointment2@hotmail.com", true, "1234-567890" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8daf9a3-6b0f-4218-a714-be061f80a844", "AQAAAAEAACcQAAAAEHG6uXiaJCP9eGjWQy/5imZriEfhq7ZX2BaxJcKT/7PDFAYt7FToTNP6UgmalehAiQ==", "471a382d-6891-4792-a00f-4ceab09022b3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "SeedUser2", 0, "ba8fb4bd-8111-46ce-bbd2-eda4605024ad", "test2@hotmail.com", true, false, null, "TEST2@HOTMAIL.COM", "TEST2@HOTMAIL.COM", "AQAAAAEAACcQAAAAEIjILwyP2ZS/nCyoY9MsY39K/axdU1zECgmh6TzuHelHZuj7C9GKW6HwPKHhh8OWZw==", null, false, "4a0daa98-c861-4348-b8cf-3348ab5dd337", false, "test2@hotmail.com" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "ApplicationUserId", "AppointmentId", "EndDate", "Name", "Notes", "StartDate", "Status" },
                values: new object[] { 3, "SeedUser2", 2, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Work Order", "geen aantekeningen", new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser2");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 21, 14, 56, 52, 803, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e6ff3b7-0fd5-414e-8664-d12afbd49a9d", "AQAAAAEAACcQAAAAEEPn3wzvyYAzvwT8elYZ6tRPhs3OuDSQpDmG2GrdMB7EI+K7oRpH288iU4+SGxx7Ug==", "71d1ace5-cc8c-4310-a28e-e5d48fbd0c76" });
        }
    }
}
