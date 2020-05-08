using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using Decapent.Ledger.Domain.LedgerEvents;
using Decapent.Ledger.Infrastructure.Extensions;
using Decapent.Ledger.Infrastructure.Models;

using Microsoft.Extensions.Logging;

using ServiceStack.OrmLite;

namespace Decapent.Ledger.Infrastructure
{
    public class SQLServerLedgerEventRepository : ILedgerEventRepository
    {
        private readonly OrmLiteConnectionFactory _connectionFactory;
        private readonly ILogger<SQLServerLedgerEventRepository> _logger;

        public SQLServerLedgerEventRepository(OrmLiteConnectionFactory connectionFactory, ILogger<SQLServerLedgerEventRepository> logger)
        {
            this._logger = logger;
            this._connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<LedgerEvent>> GetEvents()
        {
            var ledgerEvents = new List<LedgerEventModel>();

            try
            {
                using var db = this._connectionFactory.OpenDbConnection();
                ledgerEvents = await db.SelectAsync<LedgerEventModel>("SELECT * FROM VW_LedgerEvents");
            }
            catch (SqlException sqlEx)
            {
                this._logger.LogError(sqlEx.Message);
            }

            return ledgerEvents.Select(x => x.ToDomainObject());
        }
    }
}
