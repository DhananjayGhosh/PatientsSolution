using Microsoft.Extensions.DependencyInjection;
using PatientAPI.Domain.Services;
namespace PatientAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMemoryCache(); 
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPatientIdGenerator, PatientIdGenerator>();
            services.AddScoped<IDoctorIdGenerator, DoctorIdGenerator>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<ICacheService, CacheService>();
            return services;
        }
    }
}
