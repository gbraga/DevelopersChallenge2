using AutoMapper;
using Nibo.ConciliatorOFX.Data.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Application.API.Mappings
{
    public class BankTransactionDTOTypeConverter : ITypeConverter<BankTransactionDTO, BankTransaction>
    {
        public BankTransaction Convert(BankTransactionDTO source, BankTransaction destination, ResolutionContext context) =>
            new BankTransaction(source.TransactionType, source.PostedDate, source.Amount, source.Memo);
    }
}
