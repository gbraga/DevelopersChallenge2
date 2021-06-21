using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Data.Mappings
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(c => c.BankAccountId);
            //builder
            //    .HasMany(c => c.BankStatement)
            //    .WithOne(c => c.BankAccount)
            //    .HasForeignKey(c => c.BankAccountId);
        }
    }
}
