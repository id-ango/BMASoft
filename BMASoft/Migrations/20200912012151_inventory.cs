using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class inventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IcAccts",
                columns: table => new
                {
                    IcAcctId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcctSet = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Acct1 = table.Column<string>(nullable: true),
                    Acct2 = table.Column<string>(nullable: true),
                    Acct3 = table.Column<string>(nullable: true),
                    Acct4 = table.Column<string>(nullable: true),
                    Acct5 = table.Column<string>(nullable: true),
                    Acct6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcAccts", x => x.IcAcctId);
                });

            migrationBuilder.CreateTable(
                name: "IcAltItems",
                columns: table => new
                {
                    IcAltItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(nullable: true),
                    Lokasi = table.Column<string>(nullable: true),
                    NamaItem = table.Column<string>(nullable: true),
                    Satuan = table.Column<string>(nullable: true),
                    Divisi = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Harga = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    QtyPo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BefNetto = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    HrgNetto = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    HrgJual = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SaldoAwal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CostAwal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AcctSet = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    SerialNo = table.Column<bool>(nullable: false),
                    CostMethod = table.Column<int>(nullable: false),
                    JnsBrng = table.Column<int>(nullable: false),
                    StdPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TglPost = table.Column<DateTime>(nullable: true),
                    LastNetto = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcAltItems", x => x.IcAltItemId);
                });

            migrationBuilder.CreateTable(
                name: "IcCats",
                columns: table => new
                {
                    IcCatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Cat1 = table.Column<string>(nullable: true),
                    Cat2 = table.Column<string>(nullable: true),
                    Cat3 = table.Column<string>(nullable: true),
                    Cat4 = table.Column<string>(nullable: true),
                    Cat5 = table.Column<string>(nullable: true),
                    Cat6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcCats", x => x.IcCatID);
                });

            migrationBuilder.CreateTable(
                name: "IcDivs",
                columns: table => new
                {
                    IcDivId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Divisi = table.Column<string>(nullable: true),
                    NamaDiv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcDivs", x => x.IcDivId);
                });

            migrationBuilder.CreateTable(
                name: "IcItems",
                columns: table => new
                {
                    IcItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(nullable: true),
                    NamaItem = table.Column<string>(nullable: true),
                    Satuan = table.Column<string>(nullable: true),
                    Divisi = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Harga = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    QtyPo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BefNetto = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    HrgNetto = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    HrgJual = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SaldoAwal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CostAwal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AcctSet = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    SerialNo = table.Column<bool>(nullable: false),
                    CostMethod = table.Column<int>(nullable: false),
                    JnsBrng = table.Column<int>(nullable: false),
                    StdPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TglPost = table.Column<DateTime>(nullable: true),
                    LastNetto = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcItems", x => x.IcItemId);
                });

            migrationBuilder.CreateTable(
                name: "Iclokasis",
                columns: table => new
                {
                    IcLokasiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lokasi = table.Column<string>(nullable: true),
                    NamaLokasi = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    Kota = table.Column<string>(nullable: true),
                    Telpon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iclokasis", x => x.IcLokasiId);
                });

            migrationBuilder.CreateTable(
                name: "IcTransDs",
                columns: table => new
                {
                    IcTransDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(nullable: true),
                    NoOrder = table.Column<string>(nullable: true),
                    NoFaktur = table.Column<string>(nullable: true),
                    NoSj = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Lokasi = table.Column<string>(nullable: true),
                    Lokasi2 = table.Column<string>(nullable: true),
                    ItemCode = table.Column<string>(nullable: true),
                    NamaItem = table.Column<string>(nullable: true),
                    Satuan = table.Column<string>(nullable: true),
                    Harga = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    QtyBo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    QtyShp = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AcctSet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcTransDs", x => x.IcTransDId);
                });

            migrationBuilder.CreateTable(
                name: "IcTransHs",
                columns: table => new
                {
                    IcTransHId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(nullable: true),
                    NoOrder = table.Column<string>(nullable: true),
                    NoFaktur = table.Column<string>(nullable: true),
                    NoSj = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Lokasi = table.Column<string>(nullable: true),
                    Lokasi2 = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    AcctSet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcTransHs", x => x.IcTransHId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IcAccts");

            migrationBuilder.DropTable(
                name: "IcAltItems");

            migrationBuilder.DropTable(
                name: "IcCats");

            migrationBuilder.DropTable(
                name: "IcDivs");

            migrationBuilder.DropTable(
                name: "IcItems");

            migrationBuilder.DropTable(
                name: "Iclokasis");

            migrationBuilder.DropTable(
                name: "IcTransDs");

            migrationBuilder.DropTable(
                name: "IcTransHs");
        }
    }
}
