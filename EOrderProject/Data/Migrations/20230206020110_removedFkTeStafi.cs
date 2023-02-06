using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EOrderProject.Data.Migrations
{
    public partial class removedFkTeStafi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Issues_IssuesId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_IssuesId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "IssuesId",
                table: "Staffs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IssuesId",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_IssuesId",
                table: "Staffs",
                column: "IssuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Issues_IssuesId",
                table: "Staffs",
                column: "IssuesId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
