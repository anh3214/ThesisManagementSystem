using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MilestoneId",
                table: "Evaluations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_MilestoneId",
                table: "Evaluations",
                column: "MilestoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Milestones_MilestoneId",
                table: "Evaluations",
                column: "MilestoneId",
                principalTable: "Milestones",
                principalColumn: "MilestoneID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Milestones_MilestoneId",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_MilestoneId",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "MilestoneId",
                table: "Evaluations");
        }
    }
}
