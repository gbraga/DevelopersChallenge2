using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Data.Mappings
{
    public class BankStatementConfiguration : IEntityTypeConfiguration<BankStatement>
    {
        public void Configure(EntityTypeBuilder<BankStatement> builder)
        {
            builder.HasKey(c => c.BankStatementId);
            builder.Property(c => c.Currency);
            builder.Property(c => c.BankAccountId);
            builder.Property(c => c.BankTransactionsListId);
            builder.Property(c => c.LedgerBalanceAggregateId);

            builder
                .HasOne(c => c.BankAccount)
                .WithMany(c => c.BankStatement)
                .HasForeignKey(c => c.BankAccountId);

            builder
                .HasOne(c => c.BankTransactionsList)
                .WithOne(c => c.BankStatement)
                .HasForeignKey<BankTransactionsList>(c => c.BankTransactionsListId)
                .OnDelete(DeleteBehavior.Cascade);


            builder
                .HasOne(c => c.LedgerBalanceAggregate)
                .WithOne(c => c.BankStatement)
                .HasForeignKey<LedgerBalanceAggregate>(c => c.LedgerBalanceAggregateId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
