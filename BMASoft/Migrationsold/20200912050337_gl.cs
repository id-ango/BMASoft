using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class gl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IcTransHId",
                table: "IcTransDs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GlAccounts",
                columns: table => new
                {
                    GlAccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlAcct = table.Column<string>(nullable: true),
                    GlNama = table.Column<string>(nullable: true),
                    GlDept = table.Column<string>(nullable: true),
                    GlStatus = table.Column<string>(nullable: true),
                    GlTipe = table.Column<int>(nullable: false),
                    GlSaldo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPost = table.Column<DateTime>(nullable: false),
                    GlSldAwal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlKurs = table.Column<string>(nullable: true),
                    GlFisc1 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlFisc2 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlFisc3 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlFisc4 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlFisc5 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlFisc6 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlFisc7 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlFisc8 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlFisc9 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlFisc10 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlFisc11 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlFisc12 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPreFisc1 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPreFisc2 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPreFisc3 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPreFisc4 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPreFisc5 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPreFisc6 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPreFisc7 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPreFisc8 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPreFisc9 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPreFisc10 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPreFisc11 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPreFisc12 = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlAccounts", x => x.GlAccountId);
                });

            migrationBuilder.CreateTable(
                name: "GlCodes",
                columns: table => new
                {
                    GlCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodeGl = table.Column<string>(nullable: true),
                    NamaGl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlCodes", x => x.GlCodeId);
                });

            migrationBuilder.CreateTable(
                name: "GlTransHs",
                columns: table => new
                {
                    GlTransHId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocNo = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    GlMemo = table.Column<string>(nullable: true),
                    KodeGl = table.Column<string>(nullable: true),
                    Debet = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Kredit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Kurs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlTransHs", x => x.GlTransHId);
                });

            migrationBuilder.CreateTable(
                name: "GlTransDs",
                columns: table => new
                {
                    GlTransDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keterangan = table.Column<string>(nullable: true),
                    Debet = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Kredit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlTransHId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlTransDs", x => x.GlTransDId);
                    table.ForeignKey(
                        name: "FK_GlTransDs_GlTransHs_GlTransHId",
                        column: x => x.GlTransHId,
                        principalTable: "GlTransHs",
                        principalColumn: "GlTransHId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IcTransDs_IcTransHId",
                table: "IcTransDs",
                column: "IcTransHId");

            migrationBuilder.CreateIndex(
                name: "IX_GlTransDs_GlTransHId",
                table: "GlTransDs",
                column: "GlTransHId");

            migrationBuilder.AddForeignKey(
                name: "FK_IcTransDs_IcTransHs_IcTransHId",
                table: "IcTransDs",
                column: "IcTransHId",
                principalTable: "IcTransHs",
                principalColumn: "IcTransHId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IcTransDs_IcTransHs_IcTransHId",
                table: "IcTransDs");

            migrationBuilder.DropTable(
                name: "GlAccounts");

            migrationBuilder.DropTable(
                name: "GlCodes");

            migrationBuilder.DropTable(
                name: "GlTransDs");

            migrationBuilder.DropTable(
                name: "GlTransHs");

            migrationBuilder.DropIndex(
                name: "IX_IcTransDs_IcTransHId",
                table: "IcTransDs");

            migrationBuilder.DropColumn(
                name: "IcTransHId",
                table: "IcTransDs");
        }
    }
}
