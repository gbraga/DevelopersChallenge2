﻿using System;

namespace Nibo.ConciliatorOFX.Domain.Entities
{
    public class LedgerBalanceAggregate
    {
        public LedgerBalanceAggregate(decimal amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }

        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
    }
}
