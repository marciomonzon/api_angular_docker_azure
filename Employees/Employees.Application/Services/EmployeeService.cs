using Employees.Application.Dto.Input;
using Employees.Application.Dto.View;
using Employees.Application.Exceptions;
using Employees.Application.Services.Interfaces;
using Employees.Domain.Entities;
using Employees.Domain.Entities.AggregateEmployee;
using Employees.Domain.Interfaces.UoW;
using Employees.Domain.Shared;

namespace Employees.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly NotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(NotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(EmployeeInputDto employee)
        {
            var entitie = new Employee(employee.Name,
                                       employee.PositionId,
                                       employee.Salary,
                                       employee.DateStartCompany);

            if (entitie.Invalid || entitie.Errors?.Count > 0)
            {
                _notificationContext.AddNotifications(entitie.ValidationResult);
                return false;
            }

            await _unitOfWork.EmployeeRepository.AddAsync(entitie);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<EmployeeViewDto> GetByIdAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new NotFoundException("Employee not found!");

            return new EmployeeViewDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                DateCreated = employee.DateCreated,
                DateStartCompany = employee.DateStartCompany,
                DateLeftCompnay = employee.DateLeftCompnay,
                PositionId = employee.PositionId
            };
        }

        public async Task<List<EmployeeViewDto>> GetEmployeesAsync()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetEmployeesAsync();

            if (employees == null)
                throw new NotFoundException("Employee not found!");

            return (from employee in employees
                    select new EmployeeViewDto
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Salary = employee.Salary,
                        DateCreated = employee.DateCreated,
                        DateStartCompany = employee.DateStartCompany,
                        DateLeftCompnay = employee.DateLeftCompnay,
                        PositionId = employee.PositionId
                    }).ToList();
        }

        public async Task<bool> UpdateAsync(int id, EmployeeInputDto input)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new NotFoundException("Employee not found!");

            employee.UpdateEmployee(input.Name,
                                    input.PositionId,
                                    input.Salary);

            if (employee.Invalid)
            {
                _notificationContext.AddNotifications(employee.ValidationResult);
                return false;
            }

            _unitOfWork.EmployeeRepository.Update(employee);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new NotFoundException("Employee not found!");

            _unitOfWork.EmployeeRepository.Delete(employee);
            return await _unitOfWork.CommitAsync();
        }
    }
}
