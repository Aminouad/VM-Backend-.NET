using MiniProjet.Data;
using MiniProjet.Model;

namespace MiniProjet.Repository
{
    public class VisitRepository : IVisitRepository
    {
        private readonly DataContext _context;

        public VisitRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Visit> AddVisit(Visit visit)
        {
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();
            return visit;
        }

        public async Task<string> DeleteVisit(int id)
        {
            var visit = await _context.Visits.FindAsync(id);
            if (visit == null)
                return "error";        
            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync();
            return "deleted";
        }

        public async Task<ICollection<Visit>> GetAllVisitByCompany(Company company)
        {
            return await _context.Visits.Where(v => v.Company==company).ToListAsync();
        }

        public async Task<ICollection<Visit>> GetAllVisit()
        {
           return  await _context.Visits.Include(v => v.Company).ToListAsync();
        }
    }
}
