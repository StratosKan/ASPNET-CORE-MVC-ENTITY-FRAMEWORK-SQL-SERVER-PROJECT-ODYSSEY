using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseStudy_PrimeEdu.Migrations
{
    /// <inheritdoc />
    public partial class CourseTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Courses");
        }
    }
}
