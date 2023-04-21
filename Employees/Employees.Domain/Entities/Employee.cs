using Employees.Domain.Shared;

namespace Employees.Domain.Entities
{
    public class Employee : Entity
    {
        public string Name { get; private set; }
        public string Ocuppation { get; private set; }
        public decimal Salary { get; private set; }
        public DateTime DateStartCompany { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateLeftCompnay { get; private set; }
        public bool IsDeleted { get; private set; }

        public Employee(string name,
                        string ocuppation,
                        decimal salary,
                        DateTime dateStartCompany)
        {
            Name = name.ToUpperInvariant();
            Ocuppation = ocuppation.ToUpperInvariant();
            Salary = salary;
            DateStartCompany = dateStartCompany;

            Validate(this, new EmployeeValidator());
        }

        public void UpdateEmployee(string name,
                                   string ocuppation,
                                   decimal salary)
        {
            Name = name;
            Ocuppation = ocuppation;
            Salary = salary;

            Validate(this, new EmployeeValidator());
        }
    }
}