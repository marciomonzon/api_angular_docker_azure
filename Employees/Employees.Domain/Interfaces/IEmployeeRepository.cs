using Employees.Domain.Entities;

namespace Employees.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        Task<Employee> GetByIdAsync(int id);
        Task<List<Employee>> GetEmployeesAsync();
    }
}
