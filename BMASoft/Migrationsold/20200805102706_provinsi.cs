using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class provinsi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProvKirim",
                table: "ArCusts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provinsi",
                table: "ArCusts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProvKirim",
                table: "ArCusts");

            migrationBuilder.DropColumn(
                name: "Provinsi",
                table: "ArCusts");
        }
    }
}
