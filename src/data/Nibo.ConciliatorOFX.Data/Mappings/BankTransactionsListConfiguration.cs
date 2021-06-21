using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Data.Mappings
{
    public class BankTransactionsListConfiguration : IEntityTypeConfiguration<BankTransactionsList>
    {
        public void Configure(EntityTypeBuilder<BankTransactionsList> builder)
        {
            builder.HasKey(c => c.BankTransactionsListId);
            //builder
            //    .HasOne(c => c.BankStatement)
            //    .WithOne()
            //    .HasForeignKey<BankStatement>(c => c.BankTransactionsListId);

            //builder
            //    .HasMany(c => c.BankTransactions)
            //    .WithOne(c => c.BankTransactionsList)
            //    .HasForeignKey(c => c.BankTransactionsListId);
        }
    }
}
