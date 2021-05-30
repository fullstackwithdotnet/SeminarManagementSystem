using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarManagementSystem.Migrations
{
    public partial class AddDatabaseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    Organizer_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    Fees = table.Column<int>(nullable: false),
                    Signing_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.Organizer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Type_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "Seminars",
                columns: table => new
                {
                    Seminar_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Venue = table.Column<string>(maxLength: 100, nullable: false),
                    Seminar_Date = table.Column<DateTime>(nullable: false),
                    Starting_Time = table.Column<DateTime>(nullable: false),
                    Ending_Time = table.Column<DateTime>(nullable: false),
                    Organizer_Id = table.Column<int>(nullable: false),
                    Type_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seminars", x => x.Seminar_Id);
                    table.ForeignKey(
                        name: "FK_Seminars_Organizers_Organizer_Id",
                        column: x => x.Organizer_Id,
                        principalTable: "Organizers",
                        principalColumn: "Organizer_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seminars_Types_Type_Id",
                        column: x => x.Type_Id,
                        principalTable: "Types",
                        principalColumn: "Type_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Attendee_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Phone_No = table.Column<string>(maxLength: 20, nullable: false),
                    Date_Of_Birth = table.Column<DateTime>(nullable: false),
                    Designation = table.Column<string>(maxLength: 128, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    Occupation = table.Column<string>(maxLength: 100, nullable: false),
                    Seminar_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Attendee_Id);
                    table.ForeignKey(
                        name: "FK_Attendees_Seminars_Seminar_Id",
                        column: x => x.Seminar_Id,
                        principalTable: "Seminars",
                        principalColumn: "Seminar_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_Seminar_Id",
                table: "Attendees",
                column: "Seminar_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Seminars_Organizer_Id",
                table: "Seminars",
                column: "Organizer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Seminars_Type_Id",
                table: "Seminars",
                column: "Type_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Seminars");

            migrationBuilder.DropTable(
                name: "Organizers");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
