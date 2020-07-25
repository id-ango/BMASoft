using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    CbBankId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodeBank = table.Column<string>(nullable: true),
                    NmBank = table.Column<string>(maxLength: 100, nullable: true),
                    Kurs = table.Column<string>(maxLength: 3, nullable: true),
                    Acctset = table.Column<string>(maxLength: 6, nullable: true),
                    SldAWal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    KSldAwal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ClrDate = table.Column<DateTime>(nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    KSaldo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GrpBank = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.CbBankId);
                });

            migrationBuilder.CreateTable(
                name: "CbGrps",
                columns: table => new
                {
                    CbGrpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grp = table.Column<string>(maxLength: 3, nullable: true),
                    NamaGrp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CbGrps", x => x.CbGrpId);
                });

            migrationBuilder.CreateTable(
                name: "CbSrcCodes",
                columns: table => new
                {
                    CbSrcCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SrcCode = table.Column<string>(nullable: true),
                    NamaSrc = table.Column<string>(nullable: true),
                    GlAcct = table.Column<string>(nullable: true),
                    Grp = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CbSrcCodes", x => x.CbSrcCodeId);
                });

            migrationBuilder.CreateTable(
                name: "CbTransfers",
                columns: table => new
                {
                    CbTransferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocNo = table.Column<string>(nullable: true),
                    KodeBank1 = table.Column<string>(nullable: true),
                    KodeBank2 = table.Column<string>(nullable: true),
                    Refno = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Acctset = table.Column<string>(nullable: true),
                    Giro = table.Column<string>(nullable: true),
                    Kurs = table.Column<string>(maxLength: 3, nullable: true),
                    KValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    KSaldo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NonPPN = table.Column<bool>(nullable: false),
                    Cek = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CbTransfers", x => x.CbTransferId);
                });

            migrationBuilder.CreateTable(
                name: "CbTransHs",
                columns: table => new
                {
                    CbTransHId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocNo = table.Column<string>(nullable: true),
                    KodeBank = table.Column<string>(nullable: true),
                    Refno = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Acctset = table.Column<string>(nullable: true),
                    Supplier = table.Column<string>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
                    Giro = table.Column<string>(nullable: true),
                    Kurs = table.Column<string>(maxLength: 3, nullable: true),
                    NonPPN = table.Column<bool>(nullable: false),
                    Cek = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CbTransHs", x => x.CbTransHId);
                });

            migrationBuilder.CreateTable(
                name: "CbTransDs",
                columns: table => new
                {
                    CbTransDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoPrj = table.Column<string>(nullable: true),
                    SrcCodeId = table.Column<int>(nullable: false),
                    SrcCode = table.Column<string>(nullable: true),
                    GlAcct = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Terima = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Bayar = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Kurs = table.Column<string>(nullable: true),
                    KValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    KTerima = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    KBayar = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CbTransHId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CbTransDs", x => x.CbTransDId);
                    table.ForeignKey(
                        name: "FK_CbTransDs_CbTransHs_CbTransHId",
                        column: x => x.CbTransHId,
                        principalTable: "CbTransHs",
                        principalColumn: "CbTransHId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banks_KodeBank",
                table: "Banks",
                column: "KodeBank",
                unique: true,
                filter: "[KodeBank] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CbTransDs_CbTransHId",
                table: "CbTransDs",
                column: "CbTransHId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "CbGrps");

            migrationBuilder.DropTable(
                name: "CbSrcCodes");

            migrationBuilder.DropTable(
                name: "CbTransDs");

            migrationBuilder.DropTable(
                name: "CbTransfers");

            migrationBuilder.DropTable(
                name: "CbTransHs");
        }
    }
}
