
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProjet.Model;
using MiniProjet.Service;
using Newtonsoft.Json;

namespace MiniProjet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private IVisitService _visitService;
        private ICompanyService _companyService;


        public VisitController(IVisitService visitService, ICompanyService companyService)
        {
            _visitService  = visitService;
            _companyService = companyService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<Visit>> Register(VisitDto request)
        {
            var visit = new Visit();
            visit.VisitorName = request.VisitorName;
            visit.Cin = request.CIN;
            visit.DateIn = request.DateIn;
            visit.DateOut = request.DateOut;
            var company = _companyService.GetCompanyByEmail(request.CompanyEmail);
            visit.Company = company;


            await _visitService.AddVisit(visit);
            string json = JsonConvert.SerializeObject(visit, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }
        [HttpGet("GetAllVisits")]
        public async Task<IActionResult> GetAllVisits()
        {


            string json = JsonConvert.SerializeObject(await _visitService.GetAllVisit(), Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(json);

        }
        [HttpGet("GetAllVisitsByCompany")]
        public async Task<IActionResult> GetAllVisitsByCompany(string EmailCompany)
        {
            var company = _companyService.GetCompanyByEmail(EmailCompany);           
            var visits = await _visitService.GetAllVisitByCompany(company);
            string json = JsonConvert.SerializeObject(visits, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(json);

        }

        [HttpDelete("{visitId}")]
        public async Task<string> DeleteVisit(string visitId)
        {
            if (visitId == null) return null;
            var id = Int16.Parse(visitId);
            return await _visitService.DeleteVisit(id);


        }
    }
}
