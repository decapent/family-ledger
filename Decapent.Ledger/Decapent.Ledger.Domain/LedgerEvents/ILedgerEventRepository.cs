using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decapent.Ledger.Domain.LedgerEvents
{
    public interface ILedgerEventRepository
    {
        Task<IEnumerable<LedgerEvent>> GetEvents();
    }
}
