using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class rubahTransh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "KSaldo",
                table: "CbTransHs",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "CbTransHs",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Jumlah",
                table: "CbTransDs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "KJumlah",
                table: "CbTransDs",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KSaldo",
                table: "CbTransHs");

            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "CbTransHs");

            migrationBuilder.DropColumn(
                name: "Jumlah",
                table: "CbTransDs");

            migrationBuilder.DropColumn(
                name: "KJumlah",
                table: "CbTransDs");
        }
    }
}
