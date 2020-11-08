using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class statusoedanir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "OeTransHs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "IrTransHs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "OeTransHs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "IrTransHs");
        }
    }
}
