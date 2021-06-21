using Nibo.ConciliatorOFX.Data.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Nibo.ConciliatorOFX.Application.API.Mappings
{
    public abstract class BaseTypeConverter
    {
        protected IList<BankTransaction> ConvertFromDTOs(IList<BankTransactionDTO> dtos)
        {
            IList<BankTransaction> bankTrasanctions = new List<BankTransaction>();

            foreach (var bankTransaction in dtos)
            {
                bankTrasanctions.Add(new BankTransaction(
                    bankTransaction.TransactionType,
                    bankTransaction.PostedDate,
                    bankTransaction.Amount,
                    bankTransaction.Memo));
            }

            return bankTrasanctions;
        }

        protected IList<BankTransactionDTO> ConvertFromEntities(IList<BankTransaction> entities)
        {
            IList<BankTransactionDTO> bankTrasanctions = new List<BankTransactionDTO>();

            foreach (var bankTransaction in entities)
            {
                bankTrasanctions.Add(new BankTransactionDTO
                {
                    TransactionType = bankTransaction.TransactionType,
                    PostedDate = bankTransaction.PostedDate,
                    Amount = bankTransaction.Amount,
                    Memo = bankTransaction.Memo
                });
            }

            return bankTrasanctions;
        }
    }
}