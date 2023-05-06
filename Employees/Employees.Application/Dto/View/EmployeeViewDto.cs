namespace Employees.Application.Dto.View
{
    public class EmployeeViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateStartCompany { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateLeftCompnay { get; set; }
    }
}
