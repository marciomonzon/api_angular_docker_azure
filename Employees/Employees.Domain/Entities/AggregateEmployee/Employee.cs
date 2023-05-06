using Employees.Domain.Entities.Base;
using Employees.Domain.Entities.Enums;
using Employees.Domain.Interfaces;
using Employees.Domain.Shared;

namespace Employees.Domain.Entities.AggregateEmployee
{
    public class Employee : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public int PositionId { get; set; }
        public Position Position { get; private set; }
        public decimal Salary { get; private set; }
        public DateTime DateStartCompany { get; private set; }
        public DateTime? DateLeftCompnay { get; private set; }

        public Employee(string name,
                        int positionId,
                        decimal salary,
                        DateTime dateStartCompany)
        {
            Name = name.ToUpperInvariant();
            PositionId = positionId;
            Salary = salary;
            DateStartCompany = dateStartCompany;

            Errors = new List<string>();

            Validate(this, new EmployeeValidator());
        }

        public void UpdateEmployee(string name,
                                   int positionId,
                                   decimal salary)
        {
            Name = name.Trim();
            PositionId = positionId;
            Salary = salary;

            Validate(this, new EmployeeValidator());
        }

        public void ValidateSalary(decimal salary, Position position)
        {
            switch (position.OccupationType)
            {
                case PositionTypeEnum.Assistant:
                    ValidarSalaryForAssistant(salary, position.OccupationType);
                    break;
                case PositionTypeEnum.Associate:
                    ValidarSalaryForAssociate(salary, position.OccupationType);
                    break;
                case PositionTypeEnum.Senior:
                    ValidarSalaryForSenior(salary, position.OccupationType);
                    break;
                case PositionTypeEnum.Principal:
                    ValidarSalaryForPrincipal(salary, position.OccupationType);
                    break;
                case PositionTypeEnum.Distinguished:
                    ValidarSalaryForDistinguished(salary, position.OccupationType);
                    break;
                default:
                    break;
            }
        }

        private void ValidarSalaryForAssistant(decimal salary, PositionTypeEnum type)
        {
            if (type == PositionTypeEnum.Assistant && (salary >= 4000 && salary < 5000))
                Errors.Add("Salary Range of Assistant is Invalid!");
        }

        private void ValidarSalaryForAssociate(decimal salary, PositionTypeEnum type)
        {
            if (type == PositionTypeEnum.Associate && (salary >= 5000 && salary < 7000))
                Errors.Add("Salary Range of Associate is Invalid!");
        }

        private void ValidarSalaryForSenior(decimal salary, PositionTypeEnum type)
        {
            if (type == PositionTypeEnum.Senior && (salary >= 7000 && salary < 9000))
                Errors.Add("Salary Range of Senior is Invalid!");
        }

        private void ValidarSalaryForPrincipal(decimal salary, PositionTypeEnum type)
        {
            if (type == PositionTypeEnum.Principal && (salary >= 9000 && salary < 12000))
                Errors.Add("Salary Range of Principal is Invalid!");
        }

        private void ValidarSalaryForDistinguished(decimal salary, PositionTypeEnum type)
        {
            if (type == PositionTypeEnum.Distinguished && (salary >= 12000 && salary < 18000))
                Errors.Add("Salary Range of Distinguished is Invalid!");
        }
    }
}