global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using MiniProjet.Model;
using MiniProjet.Service;

namespace MiniProjet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        public static Account account = new Account();
        public AuthenticationController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<ActionResult<Account>> Register(AccountDtoRegister request)
        {

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            account.Email = request.Email;
            account.Name = request.Name;
            account.Phone = request.Phone;
            var roleEnum = ((RoleEnum)int.Parse(request.Role)).ToString();
            account.Role = roleEnum;
            account.PasswordHash = passwordHash;
            account.PasswordSalt = passwordSalt;
            account.Date = request.Date;
            account.Id = 0;


            var savedAccount = await _accountService.addAccount(account);
            return Ok(savedAccount);
        }

        [HttpGet]
        public ActionResult<object> GetAccountInfo()
        {
            var accountInfo = _accountService.GetAccountInfo();
            return Ok(accountInfo);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(AccountDtoLogin request)
        {
            var account = await _accountService.GetAccountByEmail(request.Email);
            if (account == null)
            {
                return Ok("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, account.PasswordHash, account.PasswordSalt))
            {
                return Ok("Wrong password.");
            }
            string token = CreateToken(account);
            return Ok(token);

        }

        private string CreateToken(Account account)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, account.Role)

            };
            var key = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        public static void CreatePasswordHash(string password, out byte[] passwordHash,
                out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {

                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
