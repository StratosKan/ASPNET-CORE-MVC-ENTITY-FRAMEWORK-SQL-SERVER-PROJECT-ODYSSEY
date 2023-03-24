using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseStudy_PrimeEdu.Migrations
{
    /// <inheritdoc />
    public partial class TestsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TCategory",
                table: "Tests");

            migrationBuilder.AddColumn<string>(
                name: "TestCategory",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestCategory",
                table: "Tests");

            migrationBuilder.AddColumn<int>(
                name: "TCategory",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
