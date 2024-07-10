using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class IncludePassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "ID",
                keyValue: 1,
                column: "Password",
                value: "AGNvokmfybK2QXEK+1EbB6bVxPdqqZPc6sqTZ+gFnHBf8sMy+xxxrsxC8qtVr2L+8Q==");

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "ID",
                keyValue: 2,
                column: "Password",
                value: "AJcNszpqgAoOw79XE6KEPpcMJMStMpm6qpaRqwY6dp/jBdnnv4z/5S7H9A1KbA7xSA==");

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "ID",
                keyValue: 3,
                column: "Password",
                value: "AJLIovnneqiODRQugbDKyHgip5XIxKwMG4qXsVE3Uvjt/E/CX5fZHnXMKkiTBMkglg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Staffs");
        }
    }
}
