using AutoMapper;
using Decapent.Ledger.Api.Dtos;
using Decapent.Ledger.Domain.LedgerEvents;
using Decapent.Ledger.Domain.LedgerEvents.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nexus.Cqrs.Queries.Bus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decapent.Ledger.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LedgerEventController : ControllerBase
    {
        private readonly IQueryBus _queryBus;
        private readonly ILogger<LedgerEventController> _logger;
        private readonly IMapper _mapper;

        public LedgerEventController(ILogger<LedgerEventController> logger, IQueryBus queryBus, IMapper mapper)
        {
            this._logger = logger;
            this._queryBus = queryBus;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            this._logger.LogInformation("LedgerEventController: Entering function scope GET");
            var query = new AllLedgerEventQuery();
            var allLedgerEvents = await this._queryBus.Execute<AllLedgerEventQuery, IEnumerable<LedgerEvent>>(query);

            var dtos = this._mapper.Map<List<LedgerEventDto>>(allLedgerEvents);

            return this.Ok(dtos);
        }
    }
}
