using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Data.Mappings
{
    public class LedgerBalanceAggregateConfiguration : IEntityTypeConfiguration<LedgerBalanceAggregate>
    {
        public void Configure(EntityTypeBuilder<LedgerBalanceAggregate> builder)
        {
            builder.HasKey(c => c.LedgerBalanceAggregateId);
            //builder
            //    .HasOne(c => c.BankStatement)
            //    .WithOne()
            //    .HasForeignKey<BankStatement>(c => c.LedgerBalanceAggregateId);
        }
    }
}
