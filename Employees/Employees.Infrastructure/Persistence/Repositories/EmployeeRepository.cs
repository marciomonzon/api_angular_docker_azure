using Employees.Domain.Entities.AggregateEmployee;
using Employees.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employees.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public void Update(Employee employee)
        {
            _context.Entry(employee).CurrentValues.SetValues(employee);
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public void Delete(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Deleted;
        }
    }
}
