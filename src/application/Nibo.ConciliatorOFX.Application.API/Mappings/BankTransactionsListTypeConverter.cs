using AutoMapper;
using Nibo.ConciliatorOFX.Data.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;
using System.Linq;

namespace Nibo.ConciliatorOFX.Application.API.Mappings
{
    public class BankTransactionsListTypeConverter : BaseTypeConverter, ITypeConverter<BankTransactionsList, BankTransactionsListDTO>
    {
        public BankTransactionsListDTO Convert(BankTransactionsList source, BankTransactionsListDTO destination, ResolutionContext context) =>
            new BankTransactionsListDTO
            {
                StartDate = source.StartDate,
                EndDate = source.EndDate,
                BankTransactions = source.BankTransactions.Select(s => new BankTransactionDTO
                {
                    TransactionType = s.TransactionType,
                    PostedDate = s.PostedDate,
                    Amount = s.Amount,
                    Memo = s.Memo
                }).ToList()
            };
    }
}
