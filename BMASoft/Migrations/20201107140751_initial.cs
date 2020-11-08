using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BMASoft.Migrations
{
    public partial class initial : Migration
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
                    Pajak = table.Column<bool>(nullable: false),
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
                    AcctPjk = table.Column<string>(nullable: true),
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
                    ApSupplId = table.Column<int>(nullable: false),
                    NamaSup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApTransHs", x => x.ApTransHId);
                });

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
                    Provinsi = table.Column<string>(nullable: true),
                    AlmtKrm = table.Column<string>(nullable: true),
                    KotaKrm = table.Column<string>(nullable: true),
                    ProvKirim = table.Column<string>(nullable: true),
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
                    Pajak = table.Column<bool>(nullable: false),
                    AcctSet = table.Column<string>(nullable: true),
                    AcctPjk = table.Column<string>(nullable: true),
                    TglPost = table.Column<DateTime>(nullable: true),
                    TglMasuk = table.Column<DateTime>(nullable: true),
                    LstOrder = table.Column<DateTime>(nullable: true),
                    Piutang = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NamaLengkap = table.Column<string>(nullable: true)
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
                    DueDate = table.Column<DateTime>(nullable: true),
                    KodeTran = table.Column<string>(nullable: true),
                    LPB = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
                    Pajak = table.Column<bool>(nullable: false),
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
                    Kode = table.Column<string>(maxLength: 2, nullable: true),
                    Bukti = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    KdBank = table.Column<string>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
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
                    Piutang = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Pajak = table.Column<bool>(nullable: false),
                    Unapplied = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AcctSet = table.Column<string>(nullable: true),
                    ArCustId = table.Column<int>(nullable: false),
                    NamaCust = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArTransHs", x => x.ArTransHId);
                });

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
                    Status = table.Column<string>(nullable: true),
                    NonPpn = table.Column<bool>(nullable: false),
                    Pajak = table.Column<bool>(nullable: false),
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
                    Pajak = table.Column<bool>(nullable: false),
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
                    Pajak = table.Column<bool>(nullable: false),
                    Cek = table.Column<bool>(nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    KSaldo = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CbTransHs", x => x.CbTransHId);
                });

            migrationBuilder.CreateTable(
                name: "GlAccounts",
                columns: table => new
                {
                    GlAccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlAcct = table.Column<string>(nullable: true),
                    GlNama = table.Column<string>(nullable: true),
                    GlDept = table.Column<string>(nullable: true),
                    TipeGl = table.Column<string>(nullable: true),
                    GlStatus = table.Column<string>(nullable: true),
                    GlTipe = table.Column<int>(nullable: false),
                    GlSaldo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GlPost = table.Column<DateTime>(nullable: true),
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
                    GlPreFisc12 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NamaLengkap = table.Column<string>(nullable: true)
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
                    Kurs = table.Column<string>(nullable: true),
                    Pajak = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlTransHs", x => x.GlTransHId);
                });

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
                    IcCatId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_IcCats", x => x.IcCatId);
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
                    HrgUsd = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                    CostMethod = table.Column<string>(nullable: true),
                    JnsBrng = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    StdPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TglPost = table.Column<DateTime>(nullable: true),
                    LastNetto = table.Column<DateTime>(nullable: true),
                    NamaLengkap = table.Column<string>(nullable: true)
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
                    AcctSet = table.Column<string>(nullable: true),
                    Pajak = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcTransHs", x => x.IcTransHId);
                });

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
                    JthTempo = table.Column<DateTime>(nullable: false),
                    TtlJumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DPayment = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Ongkos = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PpnPersen = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Ppn = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Tagihan = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalQty = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    NamaSup = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Cek = table.Column<string>(nullable: true),
                    Pajak = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrTransHs", x => x.IrTransHId);
                });

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
                    Pajak = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OeTransHs", x => x.OeTransHId);
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

            migrationBuilder.CreateTable(
                name: "ArTransDs",
                columns: table => new
                {
                    ArTransDId = table.Column<int>(nullable: false)
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
                    Jumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Terima = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Bayar = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Kurs = table.Column<string>(nullable: true),
                    KValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    KJumlah = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                    AcctSet = table.Column<string>(nullable: true),
                    IcTransHId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcTransDs", x => x.IcTransDId);
                    table.ForeignKey(
                        name: "FK_IcTransDs_IcTransHs_IcTransHId",
                        column: x => x.IcTransHId,
                        principalTable: "IcTransHs",
                        principalColumn: "IcTransHId",
                        onDelete: ReferentialAction.Cascade);
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
                    Qty = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                name: "IX_ApSuppls_Supplier",
                table: "ApSuppls",
                column: "Supplier",
                unique: true,
                filter: "[Supplier] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApTransDs_ApTransHId",
                table: "ApTransDs",
                column: "ApTransHId");

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

            migrationBuilder.CreateIndex(
                name: "IX_GlTransDs_GlTransHId",
                table: "GlTransDs",
                column: "GlTransHId");

            migrationBuilder.CreateIndex(
                name: "IX_IcTransDs_IcTransHId",
                table: "IcTransDs",
                column: "IcTransHId");

            migrationBuilder.CreateIndex(
                name: "IX_IrTransDs_IrTransHId",
                table: "IrTransDs",
                column: "IrTransHId");

            migrationBuilder.CreateIndex(
                name: "IX_OeTransDs_OeTransHId",
                table: "OeTransDs",
                column: "OeTransHId");
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
                name: "GlAccounts");

            migrationBuilder.DropTable(
                name: "GlCodes");

            migrationBuilder.DropTable(
                name: "GlTransDs");

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
                name: "IrTransDs");

            migrationBuilder.DropTable(
                name: "OeTransDs");

            migrationBuilder.DropTable(
                name: "ApTransHs");

            migrationBuilder.DropTable(
                name: "ArTransHs");

            migrationBuilder.DropTable(
                name: "CbTransHs");

            migrationBuilder.DropTable(
                name: "GlTransHs");

            migrationBuilder.DropTable(
                name: "IcTransHs");

            migrationBuilder.DropTable(
                name: "IrTransHs");

            migrationBuilder.DropTable(
                name: "OeTransHs");
        }
    }
}
