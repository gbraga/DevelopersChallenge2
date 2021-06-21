using AutoMapper;
using Nibo.ConciliatorOFX.Data.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Application.API.Mappings
{
    public class BankAccountDTOTypeConverter : ITypeConverter<BankAccountDTO, BankAccount>
    {
        public BankAccount Convert(BankAccountDTO source, BankAccount destination, ResolutionContext context) =>
            new BankAccount(source.BankId, source.AccountId, source.AccountType);
    }
}
