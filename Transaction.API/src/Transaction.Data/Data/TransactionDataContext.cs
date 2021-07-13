using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Transaction.Domain.Models;
using Transaction.Domain.Models.Lookups;

namespace Transaction.Data.Data
{
    public class TransactionDataContext : DbContext
    {
        public TransactionDataContext()
        {

        }
    
        public TransactionDataContext(DbContextOptions<TransactionDataContext> options) : base(options) { }

        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<TypeLookup> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transactions>()
                .Property(p => p.AmountTotal)
                .HasColumnType("decimal(18,2)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=.;Database=TransactionsDB;Trusted_Connection=True; MultipleActiveResultSets=True");
            base.OnConfiguring(builder);
        }

    }
}
