using Decapent.Ledger.Domain.LedgerEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Decapent.Ledger.Infrastructure
{
    public class MongoDBLedgerEventRepository : ILedgerEventRepository
    {
        public async Task<IEnumerable<LedgerEvent>> GetEvents()
        {
            var random = new Random();
            var events = Enumerable.Range(1, 10).Select(x => new LedgerEvent
                    {
                        Author = "Patrick Lavallee",
                        City = "ChateauPoat",
                        Date = DateTime.Now,
                        Description = "Super event",
                        Id = Guid.NewGuid(),
                        LedgerEntry = new byte[1],
                        LedgerPage = Convert.ToInt32(Math.Ceiling(x / 3f)),
                        Type = (LedgerEventType)Convert.ToInt32(Math.Floor(x / 4f))
            });

            return await Task.FromResult(events);            
        }
    }
}
