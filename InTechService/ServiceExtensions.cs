using InTechService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InTechService
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
