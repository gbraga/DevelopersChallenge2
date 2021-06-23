using Nibo.ConciliatorOFX.Data.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nibo.ConciliatorOFX.Data.Repositories
{
    public interface IBankStatementRepository
    {
        void Save(BankStatement bankStatement);
        Task<ICollection<BankStatement>> Get(int skip = 0, int take = 20);
        Task<ICollection<BankStatement>> Get(int[] ids, int skip = 0, int take = 20);
        //Task<ICollection<BankStatementDTO>> Conciliation(int[] ids);
    }
}
