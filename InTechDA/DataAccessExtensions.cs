using InTechDA.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace InTechDA
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();

            return services;
        }
    }
}
