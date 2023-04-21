using Employees.Domain.Interfaces;
using Employees.Domain.Interfaces.UoW;
using Employees.Infrastructure.Persistence;
using Employees.Infrastructure.Persistence.Repositories;
using Employees.Infrastructure.Persistence.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection RegisterInfrastrucutreModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                       configuration.GetConnectionString("DefaultConnection"),
                       b => b.MigrationsAssembly(typeof(ApplicationDbContext)
                             .Assembly.FullName)));

            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
