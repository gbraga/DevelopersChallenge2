using AutoMapper;
using Nibo.ConciliatorOFX.Data.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Nibo.ConciliatorOFX.Application.API.Services
{
    public class OfxConciliate : IOfxConciliate
    {
        private readonly IMapper _mapper;

        public OfxConciliate(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<BankTransactionDTO> Conciliate(IList<BankStatement> bankStatements)
        {
            var allTransactions = new List<BankTransaction>();

            foreach (var bankStatement in bankStatements)
                allTransactions.AddRange(bankStatement.BankTransactionsList.BankTransactions);

            var mergedTransactions = allTransactions
                .Distinct(new BankTransactionComparer())
                .Select(t => _mapper.Map<BankTransactionDTO>(t))
                .ToList();

            return mergedTransactions;
        }

        public class BankTransactionComparer : EqualityComparer<BankTransaction>
        {

            public override bool Equals(BankTransaction x, BankTransaction y)
            {
                if (x.TransactionType == y.TransactionType &&
                    x.PostedDate == y.PostedDate &&
                    x.Amount == y.Amount &&
                    x.Memo == y.Memo)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override int GetHashCode([DisallowNull] BankTransaction obj) => obj.GetHashCode();
        }
    }
}
