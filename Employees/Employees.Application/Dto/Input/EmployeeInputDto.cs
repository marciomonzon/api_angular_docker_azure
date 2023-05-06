namespace Employees.Application.Dto.Input
{
    public class EmployeeInputDto
    {
        public string Name { get; set; }
        public int PositionId { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateStartCompany { get; set; }
    }
}
