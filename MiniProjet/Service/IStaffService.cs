using MiniProjet.Model;

namespace MiniProjet.Service
{
    public interface IStaffService
    {
        public Task<string> DeleteStaff(int id);
        public Task<Staff> AddStaff(Staff staff);
        public Task<ICollection<Staff>> GetAllStaff();
        public Task<ICollection<Staff>> GetAllStaffByCompany(Company company);
    }
}
