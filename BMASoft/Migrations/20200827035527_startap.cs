using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class startap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApAccts",
                columns: table => new
                {
                    ApAcctId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_ApAccts", x => x.ApAcctId);
                });

            migrationBuilder.CreateTable(
                name: "ApDists",
                columns: table => new
                {
                    ApDistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Dist1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApDists", x => x.ApDistId);
                });

            migrationBuilder.CreateTable(
                name: "ApHutangs",
                columns: table => new
                {
                    ApHutangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(nullable: true),
                    Dokumen = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    KodeTran = table.Column<string>(nullable: true),
                    LPB = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Supplier = table.Column<string>(nullable: true),
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Bayar = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Sisa = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UnApplied = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Dpp = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PPn = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PPh = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SldSisa = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SldBayar = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SldDisc = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SldUnpl = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApHutangs", x => x.ApHutangId);
                });

            migrationBuilder.CreateTable(
                name: "ApSuppls",
                columns: table => new
                {
                    ApSupplId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier = table.Column<string>(nullable: true),
                    NamaSup = table.Column<string>(nullable: true),
                    Person = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    Kota = table.Column<string>(nullable: true),
                    Provinsi = table.Column<string>(nullable: true),
                    Telpon = table.Column<string>(nullable: true),
                    NPWP_Sup = table.Column<string>(nullable: true),
                    AlmtNPWP = table.Column<string>(nullable: true),
                    Termin = table.Column<int>(nullable: false),
                    Disc1 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Disc2 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Kontak = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    SldAwal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Pajak = table.Column<bool>(nullable: false),
                    AcctSet = table.Column<string>(nullable: true),
                    TglPost = table.Column<DateTime>(nullable: true),
                    TglMasuk = table.Column<DateTime>(nullable: true),
                    LstOrder = table.Column<DateTime>(nullable: true),
                    Hutang = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NamaLengkap = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApSuppls", x => x.ApSupplId);
                });

            migrationBuilder.CreateTable(
                name: "ApTransHs",
                columns: table => new
                {
                    ApTransHId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(maxLength: 2, nullable: true),
                    Bukti = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    KdBank = table.Column<string>(nullable: true),
                    Supplier = table.Column<string>(nullable: true),
                    NoFaktur = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    JthTempo = table.Column<DateTime>(nullable: true),
                    PPn = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PPh = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    JumPPh = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    JumPPn = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Bruto = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Netto = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Hutang = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Pajak = table.Column<bool>(nullable: false),
                    Unapplied = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AcctSet = table.Column<string>(nullable: true),
                    ApCustId = table.Column<int>(nullable: false),
                    NamaCust = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApTransHs", x => x.ApTransHId);
                });

            migrationBuilder.CreateTable(
                name: "ApTransDs",
                columns: table => new
                {
                    ApTransDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Kode = table.Column<string>(maxLength: 2, nullable: true),
                    KodeTran = table.Column<string>(maxLength: 2, nullable: true),
                    Lpb = table.Column<string>(nullable: true),
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Bayar = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Sisa = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Keterangan = table.Column<string>(nullable: true),
                    DistCode = table.Column<string>(nullable: true),
                    ApTransHId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApTransDs", x => x.ApTransDId);
                    table.ForeignKey(
                        name: "FK_ApTransDs_ApTransHs_ApTransHId",
                        column: x => x.ApTransHId,
                        principalTable: "ApTransHs",
                        principalColumn: "ApTransHId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApSuppls_Supplier",
                table: "ApSuppls",
                column: "Supplier",
                unique: true,
                filter: "[Supplier] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApTransDs_ApTransHId",
                table: "ApTransDs",
                column: "ApTransHId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApAccts");

            migrationBuilder.DropTable(
                name: "ApDists");

            migrationBuilder.DropTable(
                name: "ApHutangs");

            migrationBuilder.DropTable(
                name: "ApSuppls");

            migrationBuilder.DropTable(
                name: "ApTransDs");

            migrationBuilder.DropTable(
                name: "ApTransHs");
        }
    }
}
