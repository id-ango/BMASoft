using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class beli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IcCatID",
                table: "IcCats",
                newName: "IcCatId");

            migrationBuilder.CreateTable(
                name: "IrTransHs",
                columns: table => new
                {
                    IrTransHId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(maxLength: 2, nullable: true),
                    NoLpb = table.Column<string>(nullable: true),
                    NoPrj = table.Column<string>(nullable: true),
                    Lokasi = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    TtlJual = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DPayment = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Ongkos = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalMtr = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    NamaSup = table.Column<string>(nullable: true),
                    Cek = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrTransHs", x => x.IrTransHId);
                });

            migrationBuilder.CreateTable(
                name: "IrTransDs",
                columns: table => new
                {
                    IrTransDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(maxLength: 2, nullable: true),
                    NoLpb = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    NamaItem = table.Column<string>(nullable: true),
                    Satuan = table.Column<string>(nullable: true),
                    Lokasi = table.Column<string>(nullable: true),
                    Harga = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Persen = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    QtyBeli = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    QtyBo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    JumDpp = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    AcctSet = table.Column<string>(nullable: true),
                    IrTransHId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrTransDs", x => x.IrTransDId);
                    table.ForeignKey(
                        name: "FK_IrTransDs_IrTransHs_IrTransHId",
                        column: x => x.IrTransHId,
                        principalTable: "IrTransHs",
                        principalColumn: "IrTransHId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IrTransDs_IrTransHId",
                table: "IrTransDs",
                column: "IrTransHId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IrTransDs");

            migrationBuilder.DropTable(
                name: "IrTransHs");

            migrationBuilder.RenameColumn(
                name: "IcCatId",
                table: "IcCats",
                newName: "IcCatID");
        }
    }
}
