namespace Decapent.Ledger.Api.Dtos
{ 
    public sealed class LedgerEventDto
    {
        public string Id { get; set; }

        public string Date { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string City { get; set; }

        public string LedgerEntry { get; set; }

        public int LedgerPage { get; set; }
    }
}
