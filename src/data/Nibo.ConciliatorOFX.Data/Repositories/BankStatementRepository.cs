using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nibo.ConciliatorOFX.Data.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nibo.ConciliatorOFX.Data.Repositories
{
    public class BankStatementRepository : IBankStatementRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ConciliatorOFXContext _context;
        private readonly IMapper _mapper;

        public BankStatementRepository(
            IUnitOfWork unitOfWork,
            ConciliatorOFXContext context,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<BankStatementDTO>> Conciliation(int[] ids) => 
            await _context.BankStatements
                .Select(s => new BankStatementDTO { 
                    Currency = s.Currency, 
                    BankAccount = _mapper.Map<BankAccountDTO>(s.BankAccount), 
                    BankTransactionsList = new BankTransactionsListDTO
                    {
                        StartDate = s.BankTransactionsList.StartDate,
                        EndDate = s.BankTransactionsList.EndDate,
                        BankTransactions = s.BankTransactionsList.BankTransactions
                            .Select(x => new BankTransactionDTO
                            {
                                TransactionType = x.TransactionType,
                                PostedDate = x.PostedDate,
                                Amount = x.Amount,
                                Memo = x.Memo
                            }).ToList()
                    },
                    LedgerBalanceAggregate = _mapper.Map<LedgerBalanceAggregateDTO>(s.LedgerBalanceAggregate) 
                })
                .ToListAsync();

        public async Task<ICollection<BankStatement>> Get(int skip = 0, int take = 20) =>
            await _context.BankStatements.Skip(skip).Take(take).ToListAsync();

        public void Save(BankStatement bankStatement) => 
            _context.BankStatements.Add(bankStatement);
    }
}
