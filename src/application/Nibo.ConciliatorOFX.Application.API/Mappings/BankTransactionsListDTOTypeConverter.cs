using AutoMapper;
using Nibo.ConciliatorOFX.Data.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Application.API.Mappings
{
    public class BankTransactionsListDTOTypeConverter : BaseTypeConverter, ITypeConverter<BankTransactionsListDTO, BankTransactionsList>
    {
        public BankTransactionsList Convert(BankTransactionsListDTO source, BankTransactionsList destination, ResolutionContext context) =>
            new BankTransactionsList(
                source.StartDate,
                source.EndDate,
                ConvertFromDTOs(source.BankTransactions));
    }
}
