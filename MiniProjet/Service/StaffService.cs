using MiniProjet.Model;
using MiniProjet.Repository;

namespace MiniProjet.Service
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;


        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public async Task<Staff> AddStaff(Staff staff)
        {
            return await _staffRepository.AddStaff(staff);
        }

        public async Task<string> DeleteStaff(int id)
        {
            return await _staffRepository.DeleteStaff(id);
        }

        public async Task<ICollection<Staff>> GetAllStaff()
        {
            return await _staffRepository.GetAllStaff();
        }

        public async Task<ICollection<Staff>> GetAllStaffByCompany(Company company)
        {
            return await _staffRepository.GetAllStaffByCompany(company);
        }
    }
}
