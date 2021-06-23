using Moq;
using Nibo.ConciliatorOFX.Data.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;
using Nibo.ConciliatorOFX.Domain.Types;
using System;
using System.Collections.Generic;

namespace Nibo.ConciliatorOFX.ApplicationTests.Services
{
    public abstract class BaseServiceTests
    {
        protected readonly List<BankTransactionDTO> _listBankTransactionDTO;
        protected readonly List<BankTransaction> _listBankTransaction;
        protected readonly List<BankStatement> _listBankStatements;
        protected readonly Mock<BankAccount> _bankAccountMock = new Mock<BankAccount>();
        protected readonly Mock<LedgerBalanceAggregate> _ledgerBalanceAggregateMock = new Mock<LedgerBalanceAggregate>();

        public BaseServiceTests()
        {
            _listBankTransactionDTO = new List<BankTransactionDTO>
            {
                new BankTransactionDTO { TransactionType = TransactionType.CREDIT, PostedDate = new DateTime(2021,06,23, 13, 00, 00), Amount = 1.11M, Memo = "Transaction A" },
                new BankTransactionDTO { TransactionType = TransactionType.DEBIT, PostedDate = new DateTime(2021,06,23, 13, 00, 00), Amount = 1.11M, Memo = "Transaction A" },
                new BankTransactionDTO { TransactionType = TransactionType.CREDIT, PostedDate = new DateTime(2021,06,23, 14, 00, 00), Amount = 1.11M, Memo = "Transaction A" },
                new BankTransactionDTO { TransactionType = TransactionType.CREDIT, PostedDate = new DateTime(2021,06,23, 13, 00, 00), Amount = 2.22M, Memo = "Transaction A" },
                new BankTransactionDTO { TransactionType = TransactionType.CREDIT, PostedDate = new DateTime(2021,06,23, 13, 00, 00), Amount = 1.11M, Memo = "Transaction B" },
                new BankTransactionDTO { TransactionType = TransactionType.CREDIT, PostedDate = new DateTime(2021,06,23, 14, 00, 00), Amount = 1.11M, Memo = "Transaction C" },
                new BankTransactionDTO { TransactionType = TransactionType.CREDIT, PostedDate = new DateTime(2021,06,23, 14, 00, 00), Amount = 1.11M, Memo = "Transaction D" },
                new BankTransactionDTO { TransactionType = TransactionType.DEBIT, PostedDate = new DateTime(2021,06,23, 16, 00, 00), Amount = 4.11M, Memo = "Transaction D" },
            };

            _listBankTransaction = new List<BankTransaction>
            {
                new BankTransaction(TransactionType.CREDIT, new DateTime(2021,06,23, 13, 00, 00), 1.11M,"Transaction A"),
                new BankTransaction(TransactionType.DEBIT, new DateTime(2021,06,23, 13, 00, 00), 1.11M, "Transaction A"),
                new BankTransaction(TransactionType.CREDIT, new DateTime(2021,06,23, 14, 00, 00), 1.11M,"Transaction A"),
                new BankTransaction(TransactionType.CREDIT, new DateTime(2021,06,23, 13, 00, 00), 2.22M,"Transaction A"),
                new BankTransaction(TransactionType.CREDIT, new DateTime(2021,06,23, 13, 00, 00), 2.22M,"Transaction A"),
                new BankTransaction(TransactionType.CREDIT, new DateTime(2021,06,23, 13, 00, 00), 1.11M,"Transaction B"),
                new BankTransaction(TransactionType.CREDIT, new DateTime(2021,06,23, 13, 00, 00), 1.11M,"Transaction B"),
                new BankTransaction(TransactionType.CREDIT, new DateTime(2021,06,23, 14, 00, 00), 1.11M,"Transaction C"),
                new BankTransaction(TransactionType.CREDIT, new DateTime(2021,06,23, 14, 00, 00), 1.11M,"Transaction C"),
                new BankTransaction(TransactionType.CREDIT, new DateTime(2021,06,23, 14, 00, 00), 1.11M,"Transaction D"),
                new BankTransaction(TransactionType.DEBIT, new DateTime(2021,06,23, 16, 00, 00), 4.11M, "Transaction D"),
                new BankTransaction(TransactionType.DEBIT, new DateTime(2021,06,23, 16, 00, 00), 4.11M, "Transaction D"),
            };

            _listBankStatements = new List<BankStatement>
            {
                new BankStatement("BRL", _bankAccountMock.Object, new BankTransactionsList(DateTime.Today, DateTime.Today, _listBankTransaction.GetRange(0, 3)), _ledgerBalanceAggregateMock.Object),
                new BankStatement("BRL", _bankAccountMock.Object, new BankTransactionsList(DateTime.Today, DateTime.Today, _listBankTransaction.GetRange(4, 4)), _ledgerBalanceAggregateMock.Object),
                new BankStatement("BRL", _bankAccountMock.Object, new BankTransactionsList(DateTime.Today, DateTime.Today, _listBankTransaction.GetRange(9, 2)), _ledgerBalanceAggregateMock.Object),
            };
        }

        protected string ReadOfxFileIntoString(string filename) =>
            System.Text.Encoding.Default.GetString(Resources.extrato1);

        protected List<BankTransaction> ConcatAllBackTransactios(List<BankStatement> bankStatementsList)
        {
            var bankTransactionsList = new List<BankTransaction>();

            bankStatementsList.ForEach(b => bankTransactionsList.AddRange(b.BankTransactionsList.BankTransactions));

            return bankTransactionsList;
        }
    }
}
