using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class gantiIR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipeBarang",
                table: "IcItems");

            migrationBuilder.RenameColumn(
                name: "TtlJual",
                table: "IrTransHs",
                newName: "TtlJumlah");

            migrationBuilder.RenameColumn(
                name: "TotalMtr",
                table: "IrTransHs",
                newName: "Tagihan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TtlJumlah",
                table: "IrTransHs",
                newName: "TtlJual");

            migrationBuilder.RenameColumn(
                name: "Tagihan",
                table: "IrTransHs",
                newName: "TotalMtr");

            migrationBuilder.AddColumn<int>(
                name: "TipeBarang",
                table: "IcItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
