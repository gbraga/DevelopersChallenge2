using System;

namespace Nibo.ConciliatorOFX.Application.API.DTOs
{
    public class LedgerBalanceAggregateDTO
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
