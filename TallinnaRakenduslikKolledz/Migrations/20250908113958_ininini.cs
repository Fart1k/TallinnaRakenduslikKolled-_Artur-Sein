using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallinnaRakenduslikKolledz.Migrations
{
    /// <inheritdoc />
    public partial class ininini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "LanguageGroup",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Course",
                newName: "CourseID");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Student",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentGrade",
                table: "Enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Course",
                newName: "CourseId");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageGroup",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentGrade",
                table: "Enrollment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
