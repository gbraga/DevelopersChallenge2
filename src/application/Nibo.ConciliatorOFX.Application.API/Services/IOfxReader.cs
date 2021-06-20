using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Application.API.Services
{
    public interface IOfxReader
    {
        BankTransactionsList ReadOfxFile(string filename);
    }
}
