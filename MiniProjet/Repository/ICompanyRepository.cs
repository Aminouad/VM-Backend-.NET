using MiniProjet.Model;

namespace MiniProjet.Repository
{
    public interface ICompanyRepository
    {
        public Task<string> DeleteCompany(int id);
        public Task<Company> AddCompany(Company company, Account user);
        public Task<ICollection<Company>> GetAllCompany();
        public Company GetCompanyByEmail(String companyEmail);

    }
}
