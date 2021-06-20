using Nibo.ConciliatorOFX.Domain.Types;

namespace Nibo.ConciliatorOFX.Domain.Entities
{
    public class BankStatement : IOfxElement
    {
        public BankStatement(string currency, BankAccount bankAccount, BankTransactionsList bankTransactionsList, LedgerBalanceAggregate ledgerBalanceAggregate)
        {
            Currency = currency;
            BankAccount = bankAccount;
            BankTransactionsList = bankTransactionsList;
            LedgerBalanceAggregate = ledgerBalanceAggregate;
        }

        public int BankStatementId { get; private set; }
        public string Currency { get; private set; }
        public BankAccount BankAccount { get; private set; }
        public BankTransactionsList BankTransactionsList { get; private set; }
        public LedgerBalanceAggregate LedgerBalanceAggregate { get; private set; }
    }
}
