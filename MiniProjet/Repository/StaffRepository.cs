using MiniProjet.Data;
using MiniProjet.Model;

namespace MiniProjet.Repository
{
    public class StaffRepository:IStaffRepository
    {
        private readonly DataContext _context;

        public StaffRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Staff> AddStaff(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<ICollection<Staff>> GetAllStaff()
        {
            return await _context.Staffs.Include(s => s.Company).ToListAsync();
        }

        public async Task<ICollection<Staff>> GetAllStaffByCompany(Company company)
        {
            return await _context.Staffs.Where(s => s.Company == company).ToListAsync();
        }

        public async Task<string> DeleteStaff(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
                return "error";
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return "deleted";
        }
    }
}
