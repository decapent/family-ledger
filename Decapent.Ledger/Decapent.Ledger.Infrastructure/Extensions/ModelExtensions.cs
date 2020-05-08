using System;

using Decapent.Ledger.Domain.LedgerEvents;
using Decapent.Ledger.Infrastructure.Models;

namespace Decapent.Ledger.Infrastructure.Extensions
{
    internal static class ModelExtensions
    {
        internal static LedgerEvent ToDomainObject(this LedgerEventModel model)
        {
            return model == null ? null : new LedgerEvent
            {
                Author = model.Author,
                City = model.City,
                Date = model.Date,
                Description = model.Description,
                Id = model.Id,
                Type = Enum.Parse<LedgerEventType>(model.Type),
                LedgerImage = model.LedgerImage,
                LedgerPage = model.LedgerPage
            };
        }
    }
}
