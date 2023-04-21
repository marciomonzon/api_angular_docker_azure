using Employees.Application.Dto.Input;
using Employees.Application.Dto.View;

namespace Employees.Application.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> AddAsync(EmployeeInputDto employee);
        Task<bool> UpdateAsync(int id, EmployeeInputDto employee);
        Task<bool> DeleteAsync(int id);
        Task<EmployeeViewDto> GetByIdAsync(int id);
        Task<List<EmployeeViewDto>> GetEmployeesAsync();
    }
}
