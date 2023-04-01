using Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employees.Infrastructure.Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
