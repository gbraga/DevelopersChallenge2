using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Data.Mappings
{
    public class BankTransactionConfiguration : IEntityTypeConfiguration<BankTransaction>
    {
        public void Configure(EntityTypeBuilder<BankTransaction> builder)
        {
            builder.HasKey(c => c.BankTransactionId);
            //builder
            //    .HasOne(c => c.BankTransactionsList)
            //    .WithMany(c => c.BankTransactions)
            //    .HasForeignKey(c => c.BankTransactionsListId);
        }
    }
}
