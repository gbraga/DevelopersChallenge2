using Nibo.ConciliatorOFX.Domain.Types;

namespace Nibo.ConciliatorOFX.Domain.Entities
{
    //<STMTRS>
    public class BankStatement
    {
        public BankStatement() { }

        public BankStatement(string currency, BankAccount bankAccount, BankTransactionsList bankTransactionsList, LedgerBalanceAggregate ledgerBalanceAggregate)
        {
            Currency = currency;
            BankAccount = bankAccount;
            BankTransactionsList = bankTransactionsList;
            LedgerBalanceAggregate = ledgerBalanceAggregate;
        }

        public int BankStatementId { get; private set; }
        public string Currency { get; private set; }
        public virtual BankAccount BankAccount { get; private set; }
        public int BankAccountId { get; private set; }
        public virtual BankTransactionsList BankTransactionsList { get; private set; }
        public int BankTransactionsListId { get; private set; }
        public virtual LedgerBalanceAggregate LedgerBalanceAggregate { get; private set; }
        public int LedgerBalanceAggregateId { get; private set; }
    }
}
