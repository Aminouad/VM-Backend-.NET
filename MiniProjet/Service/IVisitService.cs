using MiniProjet.Model;

namespace MiniProjet.Service
{
    public interface IVisitService
    {
        public Task<string> DeleteVisit(int id);
        public Task<Visit> AddVisit(Visit visit);
        public Task<ICollection<Visit>> GetAllVisit();
        public Task<ICollection<Visit>> GetAllVisitByCompany(Company company);
    }
}
