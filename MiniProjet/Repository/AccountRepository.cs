using Microsoft.EntityFrameworkCore;
using MiniProjet.Data;
using MiniProjet.Model;

namespace MiniProjet.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<AccountRepository> _logger;
        public AccountRepository(DataContext context, ILogger<AccountRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Account> addAccount(Account account)
        {
            try
            {
                _logger.LogInformation("*******addAccount********");
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                var savedAccount=  await _context.Accounts.FirstOrDefaultAsync(a => a.Email == account.Email);
                return savedAccount;
            }
            catch(Exception e)
            {
                Console.WriteLine("addAccount methode Error", e);
                return null;

            }
        }

        public async Task<string> DeleteAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
                return "error";
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return "deleted";
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);
            if (account == null)            
                 return null;          
            else return account;
        }
        public  List<Account> GetAccountByRole(string role)
        {
            try
            {
                var roleEnum = ((RoleEnum)int.Parse(role)).ToString();
                var accounts =  _context.Accounts.Where(a => a.Role == roleEnum).ToList();

                return accounts;
            }
            catch (Exception e)
            {
                Console.WriteLine("GetAccountByRole methode Error", e);
                return null;

            }
        }
    }
}
