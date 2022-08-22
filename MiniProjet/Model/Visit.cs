

namespace MiniProjet.Model
{
    public class Visit
    {

        public int Id { get; set; }
        public string VisitorName { get; set; } =  string.Empty;
        public string Cin { get; set; } = string.Empty;
        public string DateIn { get; set; } = string.Empty;
        public string DateOut { get; set; } = string.Empty;
        public Company Company { get; set; }
        public int? CompanyId { get; set; }

    }
}
