using Employees.Domain.Entities.AggregateEmployee;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Employees.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
