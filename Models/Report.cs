namespace KommunensFordon.Models
{
    public class Report
    {
        public int ReportId { get; set; }

        // Detta är Foreign Key
        // Användaren matar inte in Id för de vet dem inte.
        // De ska mata in regnr. Sedan ska en sökning göras på regnr
        // Och där tas fordonets id fram.
        public int VehicleId { get; set; } 
        public Vehicle Vehicle { get; set; }
        public DateTime Reported { get; set; }
        public string Description { get; set; }
        public string Reporter { get; set; }

        // Denna ska sättas som auto-false när man lämnar in sin rapport
        // Ska finnas en HttpPut sedan som kan ändra till true
        public bool Done { get; set; }
    }
}
