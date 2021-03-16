using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiePlannerBlazor.Server.Migrations
{
    public partial class Files : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentModel_Tasks_TaskModelId",
                table: "DocumentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentModel",
                table: "DocumentModel");

            migrationBuilder.RenameTable(
                name: "DocumentModel",
                newName: "Documents");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentModel_TaskModelId",
                table: "Documents",
                newName: "IX_Documents_TaskModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 21, 10, 54, 22, 487, DateTimeKind.Local).AddTicks(2043));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "98d4cdf4-57b1-4695-aebe-6ed7d3b132a5", "b56cc3a6-61d5-4ad7-925d-9fdbe408d381" });

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Tasks_TaskModelId",
                table: "Documents",
                column: "TaskModelId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Tasks_TaskModelId",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "DocumentModel");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_TaskModelId",
                table: "DocumentModel",
                newName: "IX_DocumentModel_TaskModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentModel",
                table: "DocumentModel",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 3, 20, 10, 11, 12, 840, DateTimeKind.Local).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SeedUser1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dd724000-f22d-4c3e-b44f-392a4c10e059", "1799f3d7-b4b1-4407-abf2-036962c3dd63" });

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentModel_Tasks_TaskModelId",
                table: "DocumentModel",
                column: "TaskModelId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
