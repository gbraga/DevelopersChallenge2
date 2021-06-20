using Nibo.ConciliatorOFX.Application.API.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;
using System.Collections.Generic;

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
    }
}