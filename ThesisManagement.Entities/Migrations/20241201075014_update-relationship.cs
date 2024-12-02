using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class updaterelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registrations_GroupID",
                table: "Registrations");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_GroupID",
                table: "Registrations",
                column: "GroupID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registrations_GroupID",
                table: "Registrations");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_GroupID",
                table: "Registrations",
                column: "GroupID",
                unique: true);
        }
    }
}
