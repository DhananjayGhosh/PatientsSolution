using Microsoft.Extensions.DependencyInjection;
using PatientAPI.Domain.Services;

namespace PatientAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register application services here
            // For example, if you have a service interface and implementation:
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPatientIdGenerator, PatientIdGenerator>();
            services.AddScoped<IDoctorIdGenerator, DoctorIdGenerator>();
            services.AddScoped<IPatientService, PatientService>();
            return services;
        }
    }
}
