using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class tambahoe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OeTransHs",
                columns: table => new
                {
                    OeTransHId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(maxLength: 2, nullable: true),
                    NoLpb = table.Column<string>(nullable: true),
                    NoSJ = table.Column<string>(nullable: true),
                    NoPrj = table.Column<string>(nullable: true),
                    Lokasi = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    JthTempo = table.Column<DateTime>(nullable: false),
                    TtlJumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DPayment = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Ongkos = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PpnPersen = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Ppn = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Tagihan = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalQty = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Customer = table.Column<string>(nullable: true),
                    NamaCust = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Cek = table.Column<string>(nullable: true),
                    Pajak = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OeTransHs", x => x.OeTransHId);
                });

            migrationBuilder.CreateTable(
                name: "OeTransDs",
                columns: table => new
                {
                    OeTransDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(maxLength: 2, nullable: true),
                    NoLpb = table.Column<string>(nullable: true),
                    NoSJ = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    NamaItem = table.Column<string>(nullable: true),
                    Satuan = table.Column<string>(nullable: true),
                    Lokasi = table.Column<string>(nullable: true),
                    Harga = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Persen = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    QtyBo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    HrgCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    JumDpp = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Customer = table.Column<string>(nullable: true),
                    AcctSet = table.Column<string>(nullable: true),
                    OeTransHId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OeTransDs", x => x.OeTransDId);
                    table.ForeignKey(
                        name: "FK_OeTransDs_OeTransHs_OeTransHId",
                        column: x => x.OeTransHId,
                        principalTable: "OeTransHs",
                        principalColumn: "OeTransHId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OeTransDs_OeTransHId",
                table: "OeTransDs",
                column: "OeTransHId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OeTransDs");

            migrationBuilder.DropTable(
                name: "OeTransHs");
        }
    }
}
