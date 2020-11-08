using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class startap1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApCustId",
                table: "ApTransHs");

            migrationBuilder.DropColumn(
                name: "NamaCust",
                table: "ApTransHs");

            migrationBuilder.AddColumn<int>(
                name: "ApSupplId",
                table: "ApTransHs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NamaSup",
                table: "ApTransHs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApSupplId",
                table: "ApTransHs");

            migrationBuilder.DropColumn(
                name: "NamaSup",
                table: "ApTransHs");

            migrationBuilder.AddColumn<int>(
                name: "ApCustId",
                table: "ApTransHs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NamaCust",
                table: "ApTransHs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
