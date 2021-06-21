using Nibo.ConciliatorOFX.Domain.Entities;
using Nibo.ConciliatorOFX.Domain.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Nibo.ConciliatorOFX.Data.Repositories
{
    public class BankStatementRepository : IBankStatementRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ConciliatorOFXContext _context;

        public BankStatementRepository(IUnitOfWork unitOfWork, ConciliatorOFXContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<ICollection<BankStatement>> Get(int skip = 0, int take = 20) =>
            await _context.BankStatements.Skip(skip).Take(take).ToListAsync();

        public void Save(BankStatement bankStatement) => 
            _context.BankStatements.Add(bankStatement);
    }
}
