using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class pajak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Pajak",
                table: "IrTransHs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pajak",
                table: "IcTransHs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pajak",
                table: "GlTransHs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pajak",
                table: "CbTransHs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pajak",
                table: "CbTransfers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pajak",
                table: "Banks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pajak",
                table: "ArPiutngs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AcctPjk",
                table: "ArCusts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Pajak",
                table: "ArCusts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AcctPjk",
                table: "ApSuppls",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Pajak",
                table: "ApHutangs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pajak",
                table: "IrTransHs");

            migrationBuilder.DropColumn(
                name: "Pajak",
                table: "IcTransHs");

            migrationBuilder.DropColumn(
                name: "Pajak",
                table: "GlTransHs");

            migrationBuilder.DropColumn(
                name: "Pajak",
                table: "CbTransHs");

            migrationBuilder.DropColumn(
                name: "Pajak",
                table: "CbTransfers");

            migrationBuilder.DropColumn(
                name: "Pajak",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "Pajak",
                table: "ArPiutngs");

            migrationBuilder.DropColumn(
                name: "AcctPjk",
                table: "ArCusts");

            migrationBuilder.DropColumn(
                name: "Pajak",
                table: "ArCusts");

            migrationBuilder.DropColumn(
                name: "AcctPjk",
                table: "ApSuppls");

            migrationBuilder.DropColumn(
                name: "Pajak",
                table: "ApHutangs");
        }
    }
}
