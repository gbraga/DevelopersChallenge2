using AutoMapper;
using Nibo.ConciliatorOFX.Data.DTOs;
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

            CreateMap<BankAccount, BankAccountDTO>();

            CreateMap<BankTransactionDTO, BankTransaction>()
                .ConvertUsing(new BankTransactionDTOTypeConverter());

            CreateMap<BankTransaction, BankTransactionDTO>();

            CreateMap<BankTransactionsListDTO, BankTransactionsList>()
                .ConvertUsing(new BankTransactionsListDTOTypeConverter());

            CreateMap<BankTransactionsList, BankTransactionsListDTO>()
                .ConvertUsing(new BankTransactionsListTypeConverter());

            CreateMap<LedgerBalanceAggregateDTO, LedgerBalanceAggregate>();
            
            CreateMap<LedgerBalanceAggregate, LedgerBalanceAggregateDTO>();
        }
    }
}
