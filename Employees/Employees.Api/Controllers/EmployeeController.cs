﻿using Employees.Application.Dto.Input;
using Employees.Application.Services.Interfaces;
using Employees.Domain.Entities.AggregateEmployee;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("get-all-employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("get-employee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost("add-employee")]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeInputDto employee)
        {
            var result = await _employeeService.AddAsync(employee);
            return Ok(result);
        }

        [HttpPut("update-employee/{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeInputDto employee)
        {
            await _employeeService.UpdateAsync(id, employee);

            return NoContent();
        }

        [HttpDelete("delete-emplyee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteAsync(id);

            return NoContent();
        }
    }
}