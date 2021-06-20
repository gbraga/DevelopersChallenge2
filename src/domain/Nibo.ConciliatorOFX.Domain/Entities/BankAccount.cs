using Nibo.ConciliatorOFX.Domain.Types;

namespace Nibo.ConciliatorOFX.Domain.Entities
{
    public class BankAccount : IOfxElement
    {
        public BankAccount(int bankId, int accountId, AccountType accountType)
        {
            BankId = bankId;
            AccountId = accountId;
            AccountType = accountType;
        }

        public int BankId { get; private set; }
        public long AccountId { get; private set; }
        public AccountType AccountType { get; private set; }
    }
}
