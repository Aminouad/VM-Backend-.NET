using MiniProjet.Model;

namespace MiniProjet.Service
{
    public interface IAccountService
    {
        public object GetAccountInfo();
        public  Task<Account> addAccount(Account account);
        public Task<Account> GetAccountByEmail(string email);
        public Task<string> DeleteAccount(int id);
        public List<Account> GetAccountByRole(string role);

    }
}
