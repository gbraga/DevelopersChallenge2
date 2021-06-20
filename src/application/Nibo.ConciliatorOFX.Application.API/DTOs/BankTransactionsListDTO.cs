using System;
using System.Collections.Generic;

namespace Nibo.ConciliatorOFX.Application.API.DTOs
{
    public class BankTransactionsListDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<BankTransactionDTO> BankTransactions { get; set; }
    }
}
