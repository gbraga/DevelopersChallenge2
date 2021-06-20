using Nibo.ConciliatorOFX.Domain.Entities;
using Nibo.ConciliatorOFX.Domain.Models;

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

        public void Save(BankStatement bankStatement) => 
            _context.BankStatements.Add(bankStatement);
    }
}
