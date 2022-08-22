using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniProjet.Data;
using MiniProjet.Model;
using MiniProjet.Service;
using Newtonsoft.Json;

namespace MiniProjet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpPost("register"), Authorize]
        public async Task<ActionResult<Account>> Register(CompanyDto request)
        {
            AuthenticationController.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new Account()
            {
                Email = request.Email,
                Role = request.Role,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            var company = new Company();
            company.Name = request.Name;
            company.Email = request.Email;
            company.Phone = request.Phone;
            company.Address = request.Address;
            company.Actif = Convert.ToBoolean(request.Actif);
            company.Date = request.Date;
            await _companyService.AddCompany(company, user);
            string json = JsonConvert.SerializeObject(company, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {


            string json = JsonConvert.SerializeObject(await _companyService.GetAllCompany(), Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(json);

        }

        [HttpDelete("{companyId}")]
        public async Task<string> DeleteCompany(string companyId)
        {
            if (companyId == null) return null;
            var id = Int16.Parse(companyId);
            return await _companyService.DeleteCompany(id);


        }
    }

}
