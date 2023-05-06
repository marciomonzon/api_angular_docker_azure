using Employees.Domain.Entities.AggregateEmployee;
using FluentValidation;

namespace Employees.Domain.Shared
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty");
        }
    }
}
