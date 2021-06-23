using Nibo.ConciliatorOFX.Domain.Types;
using System.Collections.Generic;

namespace Nibo.ConciliatorOFX.Domain.Entities
{
    public class BankAccount
    {
        protected BankAccount() { }

        public BankAccount(int bankId, long accountId, AccountType accountType)
        {
            BankId = bankId;
            AccountId = accountId;
            AccountType = accountType;
        }

        public int BankAccountId { get; private set; }
        public int BankId { get; private set; }
        public long AccountId { get; private set; }
        public AccountType AccountType { get; private set; }
    }
}
