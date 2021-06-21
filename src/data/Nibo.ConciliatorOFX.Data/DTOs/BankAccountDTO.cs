using Nibo.ConciliatorOFX.Domain.Types;

namespace Nibo.ConciliatorOFX.Data.DTOs
{
    public class BankAccountDTO
    {
        public int BankId { get; set; }
        public long AccountId { get; set; }
        public AccountType AccountType { get; set; }
    }
}