using Microsoft.EntityFrameworkCore;
using Nibo.ConciliatorOFX.Domain.Entities;

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

        //public sealed class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ConciliatorOFXContext>
        //{
        //    private readonly DatabaseSettings _dbSettings;

        //    public ApplicationDbContextFactory(IOptions<DatabaseSettings> dbSettings)
        //    {
        //        _dbSettings = dbSettings.Value;
        //    }

        //    public ConciliatorOFXContext CreateDbContext(string[] args)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<ConciliatorOFXContext>();
        //        optionsBuilder.UseSqlServer(_dbSettings.ConnectionString);

        //        return new ConciliatorOFXContext(optionsBuilder.Options);
        //    }
        //}
    }
}
