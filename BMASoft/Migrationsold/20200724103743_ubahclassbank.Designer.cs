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
    [Migration("20200724103743_ubahclassbank")]
    partial class ubahclassbank
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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