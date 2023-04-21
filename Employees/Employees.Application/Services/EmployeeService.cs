using Employees.Application.Dto.Input;
using Employees.Application.Dto.View;
using Employees.Application.Services.Interfaces;
using Employees.Domain.Entities;
using Employees.Domain.Interfaces.UoW;

namespace Employees.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(EmployeeInputDto employee)
        {
            var entitie = new Employee(employee.Name,
                                       employee.Ocuppation,
                                       employee.Salary,
                                       employee.DateStartCompany);

            await _unitOfWork.EmployeeRepository.AddAsync(entitie);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<EmployeeViewDto> GetByIdAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new Exception("Employee not found!");

            return new EmployeeViewDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                DateCreated = employee.DateCreated,
                DateStartCompany = employee.DateStartCompany,
                DateLeftCompnay = employee.DateLeftCompnay,
                Ocuppation = employee.Ocuppation
            };
        }

        public async Task<List<EmployeeViewDto>> GetEmployeesAsync()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetEmployeesAsync();

            if (employees == null)
                throw new Exception("Employee not found!");

            return (from employee in employees
                    select new EmployeeViewDto
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Salary = employee.Salary,
                        DateCreated = employee.DateCreated,
                        DateStartCompany = employee.DateStartCompany,
                        DateLeftCompnay = employee.DateLeftCompnay,
                        Ocuppation = employee.Ocuppation
                    }).ToList();
        }

        public async Task<bool> UpdateAsync(int id, EmployeeInputDto input)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new Exception("Employee not found!");

            employee.UpdateEmployee(input.Name,
                                    input.Ocuppation,
                                    input.Salary);

            _unitOfWork.EmployeeRepository.Update(employee);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new Exception("Employee not found!");

            _unitOfWork.EmployeeRepository.Delete(employee);
            return await _unitOfWork.CommitAsync();
        }
    }
}
