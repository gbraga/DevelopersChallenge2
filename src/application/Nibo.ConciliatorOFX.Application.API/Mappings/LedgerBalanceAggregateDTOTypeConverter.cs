using AutoMapper;
using Nibo.ConciliatorOFX.Application.API.DTOs;
using Nibo.ConciliatorOFX.Domain.Entities;

namespace Nibo.ConciliatorOFX.Application.API.Mappings
{
    public class LedgerBalanceAggregateDTOTypeConverter : ITypeConverter<LedgerBalanceAggregateDTO, LedgerBalanceAggregate>
    {
        public LedgerBalanceAggregate Convert(LedgerBalanceAggregateDTO source, LedgerBalanceAggregate destination, ResolutionContext context) =>
            new LedgerBalanceAggregate(source.Amount, source.Date);
    }
}
