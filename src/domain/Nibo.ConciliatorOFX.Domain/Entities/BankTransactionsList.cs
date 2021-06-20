using Nibo.ConciliatorOFX.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nibo.ConciliatorOFX.Domain.Entities
{
    public class BankTransactionsList : IOfxElement
    {
        private IList<BankTransaction> _bankTransactions;

        public BankTransactionsList() { }

        public BankTransactionsList(DateTime startDate, DateTime endDate, IList<BankTransaction> bankTransactions)
        {
            StartDate = startDate;
            EndDate = endDate;
            _bankTransactions = bankTransactions;
        }

        public int BankTransactionsListId { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public IReadOnlyList<BankTransaction> BankTransactions { get { return _bankTransactions.ToList(); } }
    }
}
