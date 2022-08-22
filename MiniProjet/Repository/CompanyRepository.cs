using Microsoft.EntityFrameworkCore;
using MiniProjet.Data;
using MiniProjet.Model;

namespace MiniProjet.Repository
{
    public class CompanyRepository:ICompanyRepository
    {
        
        private readonly DataContext _context;

        public CompanyRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<string> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
                return "error";
            Account user = _context.Accounts.Where(u => u.Email == company.Email).FirstOrDefault();                 
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            _context.Accounts.Remove(user);
            await _context.SaveChangesAsync();
            return "deleted";
        }
        public async Task<Company> AddCompany(Company company, Account user)
        {
            _context.Accounts.Add(user);
            await _context.SaveChangesAsync();
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }
        public async Task<ICollection<Company>> GetAllCompany()
        {
            return await _context.Companies.ToListAsync();
        }

        public  Company GetCompanyByEmail(String companyEmail)
        {
            var company =   _context.Companies.Where(c => c.Email == companyEmail).SingleOrDefault();
            return company;
        }
    }
}

