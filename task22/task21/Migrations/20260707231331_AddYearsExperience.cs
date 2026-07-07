using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task21.Migrations
{
    /// <inheritdoc />
    public partial class AddYearsExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "yearsExperience",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "yearsExperience",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }
    }
}
