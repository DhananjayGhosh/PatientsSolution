using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientAPI.Domain.Repositories;
using PatientAPI.Infrastructure.DbEntity;
using PatientAPI.Infrastructure.Repositories;
using PatientAPI.Infrastructure.Services;

namespace PatientAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddDbContext<PatientAPIDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddHttpClient<ExternalHttpContextService>(); // Corrected method name
            return services;
        }
    }
}
