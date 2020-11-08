using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class bel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Keterangan",
                table: "IrTransHs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Ppn",
                table: "IrTransHs",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PpnPersen",
                table: "IrTransHs",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Keterangan",
                table: "IrTransHs");

            migrationBuilder.DropColumn(
                name: "Ppn",
                table: "IrTransHs");

            migrationBuilder.DropColumn(
                name: "PpnPersen",
                table: "IrTransHs");
        }
    }
}
