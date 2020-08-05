﻿// <auto-generated />
using System;
using BMASoft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BMASoft.Migrations
{
    [DbContext(typeof(BmaDbContext))]
    [Migration("20200805075901_custArnull")]
    partial class custArnull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BMASoft.Data.Models.ArAcct", b =>
                {
                    b.Property<int>("ArAcctId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acct1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Acct2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Acct3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Acct4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Acct5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Acct6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcctSet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArAcctId");

                    b.ToTable("ArAccts");
                });

            modelBuilder.Entity("BMASoft.Data.Models.ArCust", b =>
                {
                    b.Property<int>("ArCustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcctSet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alamat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlmtKrm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlmtNPWP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Disc1")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Disc2")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Expedisi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Golongan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kontak")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KotaKrm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LstOrder")
                        .HasColumnType("datetime2");

                    b.Property<string>("NPWP_Cust")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaCust")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NonPPN")
                        .HasColumnType("bit");

                    b.Property<decimal>("Piutang")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("SldAwal")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Telpon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Termin")
                        .HasColumnType("int");

                    b.Property<DateTime>("TglMasuk")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TglPost")
                        .HasColumnType("datetime2");

                    b.HasKey("ArCustId");

                    b.HasIndex("Customer")
                        .IsUnique()
                        .HasFilter("[Customer] IS NOT NULL");

                    b.ToTable("ArCusts");
                });

            modelBuilder.Entity("BMASoft.Data.Models.ArDist", b =>
                {
                    b.Property<int>("ArDistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dist1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArDistId");

                    b.ToTable("ArDists");
                });

            modelBuilder.Entity("BMASoft.Data.Models.ArPiutng", b =>
                {
                    b.Property<int>("ArPiutngId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Bayar")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Customer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Dokumen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Dpp")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Jumlah")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodeTran")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LPB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PPh")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("PPn")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Sisa")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("SldBayar")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("SldDisc")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("SldSisa")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("SldUnpl")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("UnApplied")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ArPiutngId");

                    b.ToTable("ArPiutngs");
                });

            modelBuilder.Entity("BMASoft.Data.Models.ArTransD", b =>
                {
                    b.Property<int>("ArTransDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArTransHId")
                        .HasColumnType("int");

                    b.Property<decimal>("Bayar")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("DistCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Jumlah")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KodeTran")
                        .HasColumnType("int");

                    b.Property<string>("Lpb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Sisa")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.HasKey("ArTransDId");

                    b.HasIndex("ArTransHId");

                    b.ToTable("ArTransDs");
                });

            modelBuilder.Entity("BMASoft.Data.Models.ArTransH", b =>
                {
                    b.Property<int>("ArTransHId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcctSet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ArCustId")
                        .HasColumnType("int");

                    b.Property<decimal>("Bruto")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Bukti")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("JthTempo")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("JumPPh")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("JumPPn")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Jumlah")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("KdBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Netto")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("NoFaktur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PPh")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("PPn")
                        .HasColumnType("decimal(18,4)");

                    b.Property<bool>("Pajak")
                        .HasColumnType("bit");

                    b.Property<decimal>("Piutang")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Unapplied")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ArTransHId");

                    b.HasIndex("ArCustId");

                    b.ToTable("ArTransHs");
                });

            modelBuilder.Entity("BMASoft.Data.Models.CbBank", b =>
                {
                    b.Property<int>("CbBankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acctset")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<DateTime>("ClrDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GrpBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("KSaldo")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("KSldAwal")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("KodeBank")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Kurs")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("NmBank")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("NonPpn")
                        .HasColumnType("bit");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("SldAWal")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("CbBankId");

                    b.HasIndex("KodeBank")
                        .IsUnique()
                        .HasFilter("[KodeBank] IS NOT NULL");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("BMASoft.Data.Models.CbGrp", b =>
                {
                    b.Property<int>("CbGrpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grp")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("NamaGrp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CbGrpId");

                    b.ToTable("CbGrps");
                });

            modelBuilder.Entity("BMASoft.Data.Models.CbSrcCode", b =>
                {
                    b.Property<int>("CbSrcCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GlAcct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grp")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("NamaSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SrcCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CbSrcCodeId");

                    b.ToTable("CbSrcCodes");
                });

            modelBuilder.Entity("BMASoft.Data.Models.CbTransD", b =>
                {
                    b.Property<int>("CbTransDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Bayar")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("CbTransHId")
                        .HasColumnType("int");

                    b.Property<string>("GlAcct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Jumlah")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("KBayar")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("KJumlah")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("KTerima")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("KValue")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kurs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoPrj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SrcCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SrcCodeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Terima")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("CbTransDId");

                    b.HasIndex("CbTransHId");

                    b.ToTable("CbTransDs");
                });

            modelBuilder.Entity("BMASoft.Data.Models.CbTransH", b =>
                {
                    b.Property<int>("CbTransHId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acctset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Cek")
                        .HasColumnType("bit");

                    b.Property<string>("Customer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Giro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("KSaldo")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodeBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kurs")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<bool>("NonPPN")
                        .HasColumnType("bit");

                    b.Property<string>("Refno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Supplier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.HasKey("CbTransHId");

                    b.ToTable("CbTransHs");
                });

            modelBuilder.Entity("BMASoft.Data.Models.CbTransfer", b =>
                {
                    b.Property<int>("CbTransferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acctset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Cek")
                        .HasColumnType("bit");

                    b.Property<string>("DocNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Giro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("KSaldo")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("KValue")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodeBank1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodeBank2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kurs")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<bool>("NonPPN")
                        .HasColumnType("bit");

                    b.Property<string>("Refno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.HasKey("CbTransferId");

                    b.ToTable("CbTransfers");
                });

            modelBuilder.Entity("BMASoft.Data.Models.ArTransD", b =>
                {
                    b.HasOne("BMASoft.Data.Models.ArTransH", "ArTransH")
                        .WithMany("ArTransDs")
                        .HasForeignKey("ArTransHId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BMASoft.Data.Models.ArTransH", b =>
                {
                    b.HasOne("BMASoft.Data.Models.ArCust", "ArCust")
                        .WithMany()
                        .HasForeignKey("ArCustId");
                });

            modelBuilder.Entity("BMASoft.Data.Models.CbTransD", b =>
                {
                    b.HasOne("BMASoft.Data.Models.CbTransH", "CbTransH")
                        .WithMany("CbTransDs")
                        .HasForeignKey("CbTransHId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
