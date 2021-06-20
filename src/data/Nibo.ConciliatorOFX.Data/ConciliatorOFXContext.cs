using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Nibo.ConciliatorOFX.Domain.Entities;
using System;
using System.IO;

namespace Nibo.ConciliatorOFX.Data
{
    public sealed class ConciliatorOFXContext : DbContext
    {
        public ConciliatorOFXContext(DbContextOptions<ConciliatorOFXContext> options)
            : base(options)
        { }

        public DbSet<BankStatement> BankStatements { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }
        public DbSet<BankTransactionsList> BankTransactionsLists { get; set; }
        public DbSet<LedgerBalanceAggregate> LedgerBalanceAggregates { get; set; }

        public sealed class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ConciliatorOFXContext>
        {
            public ConciliatorOFXContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ConciliatorOFXContext>();
                optionsBuilder.UseSqlServer(
                    @"Server=Localhost;Database=Nibo.ConciliatorOFX;User Id=sa;Password=1q2w3e%&!;");

                return new ConciliatorOFXContext(optionsBuilder.Options);
            }
        }
    }
}
