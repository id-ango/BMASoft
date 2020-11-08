using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class IRqty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QtyBeli",
                table: "IrTransDs",
                newName: "Qty");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalQty",
                table: "IrTransHs",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TipeBarang",
                table: "IcItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalQty",
                table: "IrTransHs");

            migrationBuilder.DropColumn(
                name: "TipeBarang",
                table: "IcItems");

            migrationBuilder.RenameColumn(
                name: "Qty",
                table: "IrTransDs",
                newName: "QtyBeli");
        }
    }
}
