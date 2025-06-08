using PatientAPI.Domain.DTOs;

namespace PatientAPI.Domain.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequestDto emailRequest);
    }
}
