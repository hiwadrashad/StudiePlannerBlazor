using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiePlannerBlazor.Server.Migrations
{
    public partial class SeedData_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d475721-6938-469a-a738-48f25eccf88f", 0, "2f02e081-5f23-4cad-a025-0da5be8521d2", "test1@hotmail.com", false, false, null, null, null, null, null, false, "41e26662-84f6-40ca-a5f4-4d2fccf4435a", false, "test1@hotmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d475721-6938-469a-a738-48f25eccf88f");
        }
    }
}
