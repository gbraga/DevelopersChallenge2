using Nibo.ConciliatorOFX.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nibo.ConciliatorOFX.Domain.Models
{
    public interface IBankStatementRepository
    {
        void Save(BankStatement bankStatement);
        Task<ICollection<BankStatement>> Get(int skip = 0, int take = 20);
    }
}
