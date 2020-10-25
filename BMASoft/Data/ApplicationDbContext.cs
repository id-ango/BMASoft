using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BMASoft.Data.Models;

namespace BMASoft.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

    public class BmaDbContext : DbContext
    {
        public BmaDbContext(DbContextOptions<BmaDbContext> options) : base(options) { }

        public DbSet<CbBank> Banks { get; set; }
        public DbSet<CbTransH> CbTransHs { get; set; }
        public DbSet<CbTransD> CbTransDs { get; set; }
        public DbSet<CbTransfer> CbTransfers { get; set; }
        public DbSet<CbSrcCode> CbSrcCodes { get; set; }
        public DbSet<CbGrp> CbGrps { get; set; }

        public DbSet<ArCust> ArCusts { get; set; }
        public DbSet<ArAcct> ArAccts { get; set; }
        public DbSet<ArDist> ArDists { get; set; }
        public DbSet<ArTransH> ArTransHs { get; set; }
        public DbSet<ArTransD> ArTransDs { get; set; }
        public DbSet<ArPiutng> ArPiutngs { get; set; }

        public DbSet<ApSuppl> ApSuppls { get; set; }
        public DbSet<ApAcct> ApAccts { get; set; }
        public DbSet<ApDist> ApDists { get; set; }
        public DbSet<ApTransH> ApTransHs { get; set; }
        public DbSet<ApTransD> ApTransDs { get; set; }
        public DbSet<ApHutang> ApHutangs { get; set; }

        public DbSet<IcItem> IcItems { get; set; }
        public DbSet<IcAltItem> IcAltItems { get; set; }
        public DbSet<IcLokasi> Iclokasis { get; set; }
        public DbSet<IcDiv> IcDivs { get; set; }
        public DbSet<IcCat> IcCats { get; set; }
        public DbSet<IcAcct> IcAccts { get; set; }
        public DbSet<IcTransH> IcTransHs { get; set; }
        public DbSet<IcTransD> IcTransDs { get; set; }

        public DbSet<IrTransH> IrTransHs { get; set; }
        public DbSet<IrTransD> IrTransDs { get; set; }

        public DbSet<OeTransH> OeTransHs { get; set; }
        public DbSet<OeTransD> OeTransDs { get; set; }

        public DbSet<GlAccount> GlAccounts { get; set; }
        public DbSet<GlCode> GlCodes { get; set; }
        public DbSet<GlTransH> GlTransHs { get; set; }
        public DbSet<GlTransD> GlTransDs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CbBank>()
                .HasIndex(p => p.KodeBank)
                .IsUnique();
            builder.Entity<CbBank>().Property(p => p.KSaldo).HasColumnType("decimal(18,4)");
            builder.Entity<CbBank>().Property(p => p.KSldAwal).HasColumnType("decimal(18,4)");
            builder.Entity<CbBank>().Property(p => p.Saldo).HasColumnType("decimal(18,4)");
            builder.Entity<CbBank>().Property(p => p.SldAWal).HasColumnType("decimal(18,4)");

            builder.Entity<ArCust>()
                .HasIndex(p => p.Customer)
                .IsUnique();
            builder.Entity<ArCust>().Property(p => p.TglMasuk).HasDefaultValue(null);
            builder.Entity<ArCust>().Property(p => p.TglPost).HasDefaultValue(null);
            builder.Entity<ArCust>().Property(p => p.LstOrder).HasDefaultValue(null);

            builder.Entity<ApSuppl>()
                    .HasIndex(p => p.Supplier)
                    .IsUnique();
            builder.Entity<ApSuppl>().Property(p => p.TglMasuk).HasDefaultValue(null);
            builder.Entity<ApSuppl>().Property(p => p.TglPost).HasDefaultValue(null);
            builder.Entity<ApSuppl>().Property(p => p.LstOrder).HasDefaultValue(null);

          
        }

    }
}
