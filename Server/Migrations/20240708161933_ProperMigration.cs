using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class ProperMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoPeople = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Present = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClassList",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassList", x => new { x.PersonID, x.ClassID });
                    table.ForeignKey(
                        name: "FK_ClassList_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassList_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ID", "EndTime", "Name", "NoPeople", "Room", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), "Math 101", 30, "Room 101", new DateTime(2021, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 9, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "History 101", 25, "Room 102", new DateTime(2021, 9, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 9, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Science 101", 20, "Room 103", new DateTime(2021, 9, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "Email", "Name", "Present" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe", true },
                    { 2, "jane.smith@example.com", "Jane Smith", false },
                    { 3, "alice.johnson@example.com", "Alice Johnson", true }
                });

            migrationBuilder.InsertData(
                table: "ClassList",
                columns: new[] { "ClassID", "PersonID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 1, 3 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassList_ClassID",
                table: "ClassList",
                column: "ClassID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassList");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
