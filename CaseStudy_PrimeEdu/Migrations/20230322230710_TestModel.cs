using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseStudy_PrimeEdu.Migrations
{
    /// <inheritdoc />
    public partial class TestModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Tests",
                newName: "LastModifiedDate");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Tests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Tests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Tests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Result",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TestId",
                table: "Courses",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Tests_TestId",
                table: "Courses",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Tests_TestId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TestId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "Tests",
                newName: "ModifiedDate");
        }
    }
}
