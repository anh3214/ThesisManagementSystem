using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThesisManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class updateStuden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MSSV",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MSSV",
                table: "Students");
        }
    }
}
