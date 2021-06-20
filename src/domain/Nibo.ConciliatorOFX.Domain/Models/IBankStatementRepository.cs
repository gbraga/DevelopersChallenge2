using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Domain.Models
{
    public interface IBankStatementRepository
    {
        void Save(BankStatement bankStatement);
    }
}
