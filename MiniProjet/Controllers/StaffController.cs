using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProjet.Model;
using MiniProjet.Service;
using Newtonsoft.Json;

namespace MiniProjet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private IStaffService _staffService;
        private ICompanyService _companyService;


        public StaffController(IStaffService staffService, ICompanyService companyService)
        {
            _staffService = staffService;
            _companyService = companyService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<Staff>> Register(StaffDto request)
        {
            var company = _companyService.GetCompanyByEmail(request.CompanyEmail);
            var staff = new Staff()
            {
                Name = request.Name,
                Position = request.Position,
                Cin = request.Cin,
                Date = request.Date,
                Company = company,
            };   
            await _staffService.AddStaff(staff);
            string json = JsonConvert.SerializeObject(staff, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }
        [HttpGet("GetAllStaffs")]
        public async Task<IActionResult> GetAllStaff()
        {
            string json = JsonConvert.SerializeObject(await _staffService.GetAllStaff(), Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(json);

        }
        [HttpGet("GetAllStaffByCompany")]
        public async Task<IActionResult> GetAllStaffByCompany(string EmailCompany)
        {
            var company = _companyService.GetCompanyByEmail(EmailCompany);

            string json = JsonConvert.SerializeObject(await _staffService.GetAllStaffByCompany(company), Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(json);

        }

        [HttpDelete("{staffId}")]
        public async Task<string> DeleteStaff(string staffId)
        {
            if (staffId == null) return null;
            var id = Int16.Parse(staffId);
            return await _staffService.DeleteStaff(id);


        }
    }
}
