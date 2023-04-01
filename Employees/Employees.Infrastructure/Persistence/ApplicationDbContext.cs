using Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employees.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
