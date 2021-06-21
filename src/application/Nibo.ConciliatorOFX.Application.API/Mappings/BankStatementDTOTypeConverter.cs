using AutoMapper;
using Nibo.ConciliatorOFX.Data.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Application.API.Mappings
{
    public class BankStatementDTOTypeConverter : BaseTypeConverter, ITypeConverter<BankStatementDTO, BankStatement>
    {
        public BankStatement Convert(BankStatementDTO source, BankStatement destination, ResolutionContext context) =>
            new BankStatement(
                source.Currency,
                new BankAccount(
                    source.BankAccount.BankId, 
                    source.BankAccount.AccountId, 
                    source.BankAccount.AccountType),
                new BankTransactionsList(
                    source.BankTransactionsList.StartDate, 
                    source.BankTransactionsList.EndDate, 
                    ConvertFromDTOs(source.BankTransactionsList.BankTransactions)),
                new LedgerBalanceAggregate(
                    source.LedgerBalanceAggregate.Amount, 
                    source.LedgerBalanceAggregate.Date));
    }
}
