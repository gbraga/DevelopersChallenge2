using Nibo.ConciliatorOFX.Data.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;
using System.Collections.Generic;

namespace Nibo.ConciliatorOFX.Application.API.Services
{
    public interface IOfxConciliate
    {
        public List<BankTransactionDTO> Conciliate(IList<BankStatement> bankStatements);
    }
}
