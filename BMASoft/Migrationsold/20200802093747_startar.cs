using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class startar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArAccts",
                columns: table => new
                {
                    ArAcctId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_ArAccts", x => x.ArAcctId);
                });

            migrationBuilder.CreateTable(
                name: "ArCusts",
                columns: table => new
                {
                    ArCustId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer = table.Column<string>(nullable: true),
                    NamaCust = table.Column<string>(nullable: true),
                    Golongan = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    Kota = table.Column<string>(nullable: true),
                    AlmtKrm = table.Column<string>(nullable: true),
                    KotaKrm = table.Column<string>(nullable: true),
                    Telpon = table.Column<string>(nullable: true),
                    NPWP_Cust = table.Column<string>(nullable: true),
                    AlmtNPWP = table.Column<string>(nullable: true),
                    Expedisi = table.Column<string>(nullable: true),
                    Termin = table.Column<int>(nullable: false),
                    Disc1 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Disc2 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Kontak = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    SldAwal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NonPPN = table.Column<bool>(nullable: false),
                    AcctSet = table.Column<string>(nullable: true),
                    TglPost = table.Column<DateTime>(nullable: false),
                    TglMasuk = table.Column<DateTime>(nullable: false),
                    LstOrder = table.Column<DateTime>(nullable: false),
                    Piutang = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArCusts", x => x.ArCustId);
                });

            migrationBuilder.CreateTable(
                name: "ArDists",
                columns: table => new
                {
                    ArDistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Dist1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArDists", x => x.ArDistId);
                });

            migrationBuilder.CreateTable(
                name: "ArPiutngs",
                columns: table => new
                {
                    ArPiutngId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(nullable: true),
                    Dokumen = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    KodeTran = table.Column<string>(nullable: true),
                    LPB = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_ArPiutngs", x => x.ArPiutngId);
                });

            migrationBuilder.CreateTable(
                name: "ArTransHs",
                columns: table => new
                {
                    ArTransHId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode = table.Column<string>(nullable: true),
                    Bukti = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    KdBank = table.Column<string>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
                    NoFaktur = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    JthTempo = table.Column<DateTime>(nullable: false),
                    PPn = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PPh = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    JumPPh = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    JumPPn = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Bruto = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Netto = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Piutang = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Pajak = table.Column<bool>(nullable: false),
                    Unapplied = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AcctSet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArTransHs", x => x.ArTransHId);
                });

            migrationBuilder.CreateTable(
                name: "ArTransDs",
                columns: table => new
                {
                    ArTransDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    KodeTran = table.Column<int>(nullable: false),
                    Lpb = table.Column<string>(nullable: true),
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Bayar = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Sisa = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Keterangan = table.Column<string>(nullable: true),
                    DistCode = table.Column<string>(nullable: true),
                    ArTransHId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArTransDs", x => x.ArTransDId);
                    table.ForeignKey(
                        name: "FK_ArTransDs_ArTransHs_ArTransHId",
                        column: x => x.ArTransHId,
                        principalTable: "ArTransHs",
                        principalColumn: "ArTransHId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArCusts_Customer",
                table: "ArCusts",
                column: "Customer",
                unique: true,
                filter: "[Customer] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ArTransDs_ArTransHId",
                table: "ArTransDs",
                column: "ArTransHId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArAccts");

            migrationBuilder.DropTable(
                name: "ArCusts");

            migrationBuilder.DropTable(
                name: "ArDists");

            migrationBuilder.DropTable(
                name: "ArPiutngs");

            migrationBuilder.DropTable(
                name: "ArTransDs");

            migrationBuilder.DropTable(
                name: "ArTransHs");
        }
    }
}
