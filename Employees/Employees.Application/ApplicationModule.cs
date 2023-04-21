using Employees.Application.Services;
using Employees.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection RegisterApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
