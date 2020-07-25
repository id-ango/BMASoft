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
        }

    }
}
