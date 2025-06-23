using PatientAPI.Domain.DTOs;

namespace PatientAPI.Domain.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequestDto emailRequest);

        // Fix for CS1520: Added a return type (string).
        // Fix for CS0501: Marked as abstract since it's an interface.
        // Fix for CS0526: Removed constructor-like syntax.
        string LoadEmailTemplate(string templatePath, Dictionary<string, string> placeholders);
    }
}
