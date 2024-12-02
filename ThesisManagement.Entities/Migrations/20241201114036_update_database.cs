using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class update_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdvisorID",
                table: "StudentGroups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CommiteID",
                table: "StudentGroups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CommiteeId",
                table: "StudentGroups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_AdvisorID",
                table: "StudentGroups",
                column: "AdvisorID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_CommiteID",
                table: "StudentGroups",
                column: "CommiteID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroups_Committees_CommiteID",
                table: "StudentGroups",
                column: "CommiteID",
                principalTable: "Committees",
                principalColumn: "CommitteeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroups_Lecturers_AdvisorID",
                table: "StudentGroups",
                column: "AdvisorID",
                principalTable: "Lecturers",
                principalColumn: "LecturerID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroups_Committees_CommiteID",
                table: "StudentGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroups_Lecturers_AdvisorID",
                table: "StudentGroups");

            migrationBuilder.DropIndex(
                name: "IX_StudentGroups_AdvisorID",
                table: "StudentGroups");

            migrationBuilder.DropIndex(
                name: "IX_StudentGroups_CommiteID",
                table: "StudentGroups");

            migrationBuilder.DropColumn(
                name: "AdvisorID",
                table: "StudentGroups");

            migrationBuilder.DropColumn(
                name: "CommiteID",
                table: "StudentGroups");

            migrationBuilder.DropColumn(
                name: "CommiteeId",
                table: "StudentGroups");
        }
    }
}
