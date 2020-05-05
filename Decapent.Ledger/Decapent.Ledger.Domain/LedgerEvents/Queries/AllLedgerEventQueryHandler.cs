using Nexus.Cqrs.Queries.Handlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decapent.Ledger.Domain.LedgerEvents.Queries
{
    public class AllLedgerEventQueryHandler : BaseQueryHandler<AllLedgerEventQuery, IEnumerable<LedgerEvent>>
    {
        private readonly ILedgerEventRepository _ledgerEventRepository;

        public AllLedgerEventQueryHandler(ILedgerEventRepository ledgerEventRepository)
        {
            this._ledgerEventRepository = ledgerEventRepository;
        }

        public override async Task<IEnumerable<LedgerEvent>> Handle(AllLedgerEventQuery query)
        {
            return await this._ledgerEventRepository.GetEvents();
        }
    }
}
