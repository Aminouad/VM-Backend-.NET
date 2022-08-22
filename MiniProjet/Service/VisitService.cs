using MiniProjet.Model;
using MiniProjet.Repository;

namespace MiniProjet.Service
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;


        public VisitService(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }
        public async Task<Visit> AddVisit(Visit visit)
        {
            return await _visitRepository.AddVisit(visit);
        }

        public async Task<string> DeleteVisit(int id)
        {
            return await _visitRepository.DeleteVisit(id);

        }

        public async Task<ICollection<Visit>> GetAllVisit()
        {
            return await _visitRepository.GetAllVisit();
        }

        public async Task<ICollection<Visit>> GetAllVisitByCompany(Company company)
        {
            return await _visitRepository.GetAllVisitByCompany(company);
        }
    }
}
