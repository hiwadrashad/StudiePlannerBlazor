using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiePlannerBlazor.Server.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PersonalContact = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calenders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calenders_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim_IdentityUser_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserLogin",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin_IdentityUser_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole_IdentityUser_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    AppointmentId = table.Column<int>(nullable: true),
                    CalenderModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Calenders_CalenderModelId",
                        column: x => x.CalenderModelId,
                        principalTable: "Calenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(nullable: true),
                    TaskModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentModel_Tasks_TaskModelId",
                        column: x => x.TaskModelId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AppointmentId", "CalenderModelId", "EndDate", "Name", "Notes", "StartDate", "Status" },
                values: new object[] { 19, null, null, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Work order for March", null, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AppointmentId", "CalenderModelId", "EndDate", "Name", "Notes", "StartDate", "Status" },
                values: new object[] { 20, null, null, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Work order for February", null, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Calenders_UserId",
                table: "Calenders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentModel_TaskModelId",
                table: "DocumentModel",
                column: "TaskModelId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserClaim_IdentityUserId",
                table: "IdentityUserClaim",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserLogin_IdentityUserId",
                table: "IdentityUserLogin",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRole_IdentityUserId",
                table: "IdentityUserRole",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AppointmentId",
                table: "Tasks",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CalenderModelId",
                table: "Tasks",
                column: "CalenderModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentModel");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim");

            migrationBuilder.DropTable(
                name: "IdentityUserLogin");

            migrationBuilder.DropTable(
                name: "IdentityUserRole");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Calenders");

            migrationBuilder.DropTable(
                name: "IdentityUser");
        }
    }
}
