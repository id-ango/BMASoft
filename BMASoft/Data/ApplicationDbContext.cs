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
        }

    }
}
