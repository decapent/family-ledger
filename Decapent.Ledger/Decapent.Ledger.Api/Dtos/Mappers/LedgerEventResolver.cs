using AutoMapper;
using Decapent.Ledger.Domain.LedgerEvents;
using System;

namespace Decapent.Ledger.Api.Dtos.Mappers
{
    public class LedgerEventResolver : IValueResolver<LedgerEvent, LedgerEventDto, string>
    {
        public string Resolve(LedgerEvent source, LedgerEventDto destination, string destMember, ResolutionContext context)
        {
            return Convert.ToBase64String(source.LedgerEntry);
        }
    }
}
