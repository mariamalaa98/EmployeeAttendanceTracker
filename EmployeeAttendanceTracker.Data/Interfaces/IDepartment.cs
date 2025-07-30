using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceTracker.Data.Entity;

namespace EmployeeAttendanceTracker.Repo.Interfaces
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task AddAsync(Department department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(int id);
        Task<bool> IsNameUniqueAsync(string name, int? excludeId = null);
        Task<bool> IsCodeUniqueAsync(string code, int? excludeId = null);
        Task<IEnumerable<Department>> GetForDropdownAsync();

        Task SaveChangesAsync();
    }
}
