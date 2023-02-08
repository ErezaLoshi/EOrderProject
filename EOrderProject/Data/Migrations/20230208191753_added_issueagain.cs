using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EOrderProject.Data.Migrations
{
    public partial class added_issueagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Issuess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuess", x => x.Id);
                });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Restaurantis_Pikas_PikatId",
            //    table: "Restaurantis",
            //    column: "PikatId",
            //    principalTable: "Pikas",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Restaurants_Pikat_PikaId",
            //    table: "Restaurants",
            //    column: "PikaId",
            //    principalTable: "Pikat",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_Restaurantis_Pikas_PikatId",
        //        table: "Restaurantis");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Restaurants_Pikat_PikaId",
            //    table: "Restaurants");

            migrationBuilder.DropTable(
                name: "Issuess");

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
                name: "Surname",
                table: "Issues",
                newName: "IssueDescription");
        }
    }
}
