using AutoMapper;
using Nibo.ConciliatorOFX.Application.API.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Application.API.Mappings
{
    public class SourceMappingProfile : Profile
    {
        public SourceMappingProfile()
        {
            CreateMap<BankStatementDTO, BankStatement>()
                .ConvertUsing(new BankStatementDTOTypeConverter());

            CreateMap<BankAccountDTO, BankAccount>()
                .ConvertUsing(new BankAccountDTOTypeConverter());

            CreateMap<BankTransactionDTO, BankTransaction>()
                .ConvertUsing(new BankTransactionDTOTypeConverter());

            CreateMap<BankTransactionsListDTO, BankTransactionsList>()
                .ConvertUsing(new BankTransactionsListDTOTypeConverter());

            CreateMap<LedgerBalanceAggregateDTO, LedgerBalanceAggregate>();
        }
    }
}
