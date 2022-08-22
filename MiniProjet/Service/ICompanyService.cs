using MiniProjet.Model;

namespace MiniProjet.Service
{
    public interface ICompanyService
    {
        public Task<string> DeleteCompany(int id);
        public  Task<Company> AddCompany(Company company, Account user);
        public  Task<ICollection<Company>> GetAllCompany();
        public Company GetCompanyByEmail(String companyEmail);

    }
}
