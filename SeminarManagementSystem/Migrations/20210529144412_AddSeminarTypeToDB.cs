using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarManagementSystem.Migrations
{
    public partial class AddSeminarTypeToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Types VALUES('Student Seminar')");
            migrationBuilder.Sql("INSERT INTO Types VALUES('Faculty Seminar')");
            migrationBuilder.Sql("INSERT INTO Types VALUES('Instructor Seminar')");
            migrationBuilder.Sql("INSERT INTO Types VALUES('Employee Seminar')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Types");
        }
    }
}
