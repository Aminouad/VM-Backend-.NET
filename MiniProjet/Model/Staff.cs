namespace MiniProjet.Model
{
    public class Staff
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Cin { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public Company Company { get; set; }
        public int? CompanyId { get; set; }
    }
}
