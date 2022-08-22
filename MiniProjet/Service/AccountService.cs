using MiniProjet.Data;
using MiniProjet.Model;
using MiniProjet.Repository;
using System.Security.Claims;

namespace MiniProjet.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public AccountService(IHttpContextAccessor httpContextAccessor, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public Task<Account> addAccount(Account account)
        {

            return _accountRepository.addAccount(account);

        }
        public object GetAccountInfo()
        {
            var email = string.Empty;
            var role = string.Empty;
            var userId = string.Empty;


            if (_httpContextAccessor.HttpContext != null)
            {
                userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
                email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
                role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

            }

            return new { email, role };

        }
        public async Task<string> DeleteAccount(int id)
        {
            return await _accountRepository.DeleteAccount(id);
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            return await _accountRepository.GetAccountByEmail(email);
        }

        public  List<Account> GetAccountByRole(string role)
        {
            return  _accountRepository.GetAccountByRole(role);

        }


    }
}
