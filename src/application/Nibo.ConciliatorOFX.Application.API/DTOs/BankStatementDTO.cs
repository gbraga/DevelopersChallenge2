namespace Nibo.ConciliatorOFX.Application.API.DTOs
{
    public class BankStatementDTO
    {
        public string Currency { get; set; }
        public BankAccountDTO BankAccount { get; set; }
        public BankTransactionsListDTO BankTransactionsList { get; set; }
        public LedgerBalanceAggregateDTO LedgerBalanceAggregate { get; set; }
    }
}
