using Microsoft.VisualBasic;
using Nibo.ConciliatorOFX.Application.API.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;
using Nibo.ConciliatorOFX.Domain.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace Nibo.ConciliatorOFX.Application.API.Services.Factories
{
    public class OfxElementFactory
    {
        public static BankStatementDTO CreateElement(XmlDocument xmlDocument)
        {
            var stmtrs = xmlDocument.GetElementsByTagName("STMTRS");

            var bankStatement = new BankStatementDTO();

            bankStatement.Currency = xmlDocument.GetElementsByTagName("CURDEF").Item(0).InnerText;

            var bankAccount = new BankAccountDTO();

            bankAccount.BankId = int.Parse(xmlDocument.GetElementsByTagName("BANKID").Item(0).InnerText);
            bankAccount.AccountId = Convert.ToInt64(xmlDocument.GetElementsByTagName("ACCTID").Item(0).InnerText);
            bankAccount.AccountType = GetAccountType(xmlDocument.GetElementsByTagName("ACCTTYPE").Item(0).InnerText);

            bankStatement.BankAccount = bankAccount;

            var bankTransactionsList = new BankTransactionsListDTO();

            bankTransactionsList.StartDate = ParseToDateTime(xmlDocument.GetElementsByTagName("DTSTART").Item(0).InnerText);
            bankTransactionsList.EndDate = ParseToDateTime(xmlDocument.GetElementsByTagName("DTEND").Item(0).InnerText);

            bankTransactionsList.BankTransactions = new List<BankTransactionDTO>();

            bankStatement.BankTransactionsList = bankTransactionsList;

            var elements = xmlDocument.GetElementsByTagName("STMTTRN");

            foreach (XmlElement element in elements)
            {
                var bankTransaction = new BankTransactionDTO();

                bankTransaction.TransactionType = GetTransactionType(element.ChildNodes[0].InnerText);
                bankTransaction.PostedDate = ParseToDateTime(element.ChildNodes[1].InnerText);
                bankTransaction.Amount = decimal.Parse(element.ChildNodes[2].InnerText, CultureInfo.InvariantCulture);
                bankTransaction.Memo = element.ChildNodes[3].InnerText;

                bankTransactionsList.BankTransactions.Add(bankTransaction);
            }

            var ledgerBalanceAggregate = new LedgerBalanceAggregateDTO();
            
            ledgerBalanceAggregate.Amount = decimal.Parse(xmlDocument.GetElementsByTagName("BALAMT").Item(0).InnerText, CultureInfo.InvariantCulture);
            ledgerBalanceAggregate.Date = ParseToDateTime(xmlDocument.GetElementsByTagName("DTASOF").Item(0).InnerText);

            bankStatement.LedgerBalanceAggregate = ledgerBalanceAggregate;

            return bankStatement;
        }

        private static TransactionType GetTransactionType(string trasactionType) =>
            trasactionType switch
            {
                "DEBIT" => TransactionType.DEBIT,
                "CREDIT" => TransactionType.CREDIT,
            };

        private static AccountType GetAccountType(string accountType) =>
            accountType switch
            {
                "CHECKING" => AccountType.CHECKING,
            };

        private static DateTime ParseToDateTime(string date)
        {
            var dt = date.Split('[');
            var timestamp = dt[0];
            var timezone = dt[1].Substring(0, dt[1].Length - 1);

            while (timestamp.Length < 14) timestamp += "0";

            return DateTime.ParseExact(timestamp, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        }
    }
}
