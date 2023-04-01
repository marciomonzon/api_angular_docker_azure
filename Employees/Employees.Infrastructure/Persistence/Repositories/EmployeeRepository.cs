using Employees.Domain.Entities;
using Employees.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<bool> AddAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
