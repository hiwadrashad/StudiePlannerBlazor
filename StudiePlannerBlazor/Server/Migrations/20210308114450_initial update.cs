using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiePlannerBlazor.Server.Migrations
{
    public partial class initialupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Calenders_CalenderModelCalenderId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CalenderModelCalenderId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CalenderModelCalenderId",
                table: "Tasks");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7b216ff5-b26f-481b-85da-4e9a628e6b18", 0, "541309dd-92a0-45c4-9390-503d784a36dd", "test@hotmail.com", false, false, null, null, null, null, null, false, "6420faf6-07f8-4a17-9418-dbb8cd45ffb8", false, "test@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "Calenders",
                keyColumn: "CalenderId",
                keyValue: 1,
                column: "UserId",
                value: "7b216ff5-b26f-481b-85da-4e9a628e6b18");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b216ff5-b26f-481b-85da-4e9a628e6b18");

            migrationBuilder.AddColumn<int>(
                name: "CalenderModelCalenderId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Calenders",
                keyColumn: "CalenderId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Calenders",
                keyColumn: "CalenderId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CalenderModelCalenderId",
                table: "Tasks",
                column: "CalenderModelCalenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Calenders_CalenderModelCalenderId",
                table: "Tasks",
                column: "CalenderModelCalenderId",
                principalTable: "Calenders",
                principalColumn: "CalenderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
