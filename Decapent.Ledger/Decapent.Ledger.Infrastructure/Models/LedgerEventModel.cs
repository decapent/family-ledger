using System;

using ServiceStack.DataAnnotations;

namespace Decapent.Ledger.Infrastructure.Models
{
    internal sealed class LedgerEventModel
    {
        [PrimaryKey]
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string City { get; set; }

        public byte[] LedgerImage { get; set; }

        public int LedgerPage { get; set; }
    }
}
