using PatientAPI.Infrastructure;
using PatientAPI.Application;
namespace PatientAPI.App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceContainer(this IServiceCollection services, IConfiguration configuration)
        {
            // Ensure AddApplication is implemented or referenced correctly
            services.AddApplication(); // This method must exist in your project or referenced libraries
            services.AddInfrastructure(configuration); // This method must exist in your project or referenced libraries
            return services;
        }
    }
}
