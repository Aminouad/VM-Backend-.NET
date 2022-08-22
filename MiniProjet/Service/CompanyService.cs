using MiniProjet.Model;
using MiniProjet.Repository;

namespace MiniProjet.Service
{
    public class CompanyService:ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;


        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        
        async public Task<string> DeleteCompany(int id)
        {
            return await _companyRepository.DeleteCompany(id);
        }
        public async Task<Company> AddCompany(Company company, Account user)
        {
            return await _companyRepository.AddCompany(company, user);
        }
        public async Task<ICollection<Company>> GetAllCompany()
        {
            return await _companyRepository.GetAllCompany();       
        }

        public  Company GetCompanyByEmail(String companyEmail)
        {
            return   _companyRepository.GetCompanyByEmail(companyEmail);
        }
    }
}
