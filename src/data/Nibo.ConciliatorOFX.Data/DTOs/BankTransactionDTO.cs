using Nibo.ConciliatorOFX.Domain.Types;
using System;

namespace Nibo.ConciliatorOFX.Data.DTOs
{
    public class BankTransactionDTO
    {
        public TransactionType TransactionType { get; set; }
        public DateTime PostedDate { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; }
    }
}
