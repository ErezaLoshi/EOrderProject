using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EOrderProject.Data.Migrations
{
    public partial class added_issuesagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Issues",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Suggestion",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "IssueDescription",
                table: "Issuess",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Issues",
                newName: "IssueDescription");

            migrationBuilder.AddColumn<string>(
                name: "Issues",
                table: "Issuess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Issuess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Suggestion",
                table: "Issuess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Issues",
                table: "Issuess");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Issuess");

            migrationBuilder.DropColumn(
                name: "Suggestion",
                table: "Issuess");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Issuess",
                newName: "IssueDescription");

            migrationBuilder.RenameColumn(
                name: "IssueDescription",
                table: "Issues",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Issues",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Suggestion",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
