namespace Employees.Domain.Entities
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Ocuppation { get; private set; }
        public decimal Salary { get; private set; }
        public DateTime DateStartCompany { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateLeftCompnay { get; private set; }

        public Employee(string name,
                        string ocuppation,
                        decimal salary,
                        DateTime dateStartCompany)
        {
            Name = name;
            Ocuppation = ocuppation;
            Salary = salary;
            DateStartCompany = dateStartCompany;
        }
    }
}
