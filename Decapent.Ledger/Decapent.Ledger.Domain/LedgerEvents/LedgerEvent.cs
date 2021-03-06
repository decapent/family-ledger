﻿using System;

namespace Decapent.Ledger.Domain.LedgerEvents
{
    public sealed class LedgerEvent
    {
        public long Id { get; set; }
        
        public DateTime Date { get; set; }

        public LedgerEventType Type { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string City { get; set; }

        public byte[] LedgerImage { get; set; } 

        public int LedgerPage { get; set; }
    }
}
