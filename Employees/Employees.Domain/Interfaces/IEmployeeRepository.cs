using Employees.Domain.Entities;

namespace Employees.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<bool> AddAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(int id);
        Task<Employee> GetByIdAsync(int id);
        Task<List<Employee>> GetEmployeesAsync();
    }
}
