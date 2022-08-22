using Microsoft.AspNetCore.Authorization;
using MiniProjet.Service;

namespace MiniProjet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet, Authorize]
        public ActionResult<object> GetAccountsByRole(string role)
        {
            return _accountService.GetAccountByRole(role);
        }
        [HttpDelete("{accountId}")]
        public async Task<string> DeleteAccount(string accountId)
        {
            if (accountId == null) return null;
            var id = Int16.Parse(accountId);
            return await _accountService.DeleteAccount(id);
        }
    }
}

