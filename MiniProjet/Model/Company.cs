namespace MiniProjet.Model
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Boolean Actif { get; set; } = false;
        public string Date { get; set; } = string.Empty;
        public ICollection<Visit> Visits { get; set; }
        public ICollection<Staff> Staffs { get; set; }




    }
}
