using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiCode_AutoFeedbackTool.Migrations
{
    /// <inheritdoc />
    public partial class updateUserTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "surname",
                table: "AspNetUsers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "student_number",
                table: "AspNetUsers",
                newName: "Student_number");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "AspNetUsers",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "lastLogin",
                table: "AspNetUsers",
                newName: "LastLogin");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "AspNetUsers",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AspNetUsers",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Student_number",
                table: "AspNetUsers",
                newName: "student_number");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "AspNetUsers",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "LastLogin",
                table: "AspNetUsers",
                newName: "lastLogin");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "AspNetUsers",
                newName: "createdAt");
        }
    }
}
