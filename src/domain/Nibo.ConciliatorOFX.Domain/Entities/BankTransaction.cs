using Nibo.ConciliatorOFX.Domain.Types;
using System;

namespace Nibo.ConciliatorOFX.Domain.Entities
{
    public class BankTransaction : IOfxElement
    {
        public BankTransaction(TransactionType transactionType, DateTime postedDate, decimal amount, string memo)
        {
            TransactionType = transactionType;
            PostedDate = postedDate;
            Amount = amount;
            Memo = memo;
        }
        public int BankTransactionId { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public DateTime PostedDate { get; private set; }
        public decimal Amount { get; private set; }
        public string Memo { get; private set; }
    }
}
