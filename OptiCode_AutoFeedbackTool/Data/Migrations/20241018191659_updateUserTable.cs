using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiCode_AutoFeedbackTool.Migrations
{
    /// <inheritdoc />
    public partial class updateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "lastLogin",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "student_number",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lastLogin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "student_number",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "surname",
                table: "AspNetUsers");
        }
    }
}
