using Nexus.Cqrs.Queries;
using System.Collections.Generic;

namespace Decapent.Ledger.Domain.LedgerEvents.Queries
{
    public class AllLedgerEventQuery : BaseQuery<IEnumerable<LedgerEvent>>
    {
    }
}
