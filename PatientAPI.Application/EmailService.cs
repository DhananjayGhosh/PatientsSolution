using Microsoft.Extensions.Configuration;
using PatientAPI.Domain.DTOs;
using PatientAPI.Domain.Services;
using System.Net.Mail;

namespace PatientAPI.Application
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmailAsync(EmailRequestDto emailRequest)
        {
            // Fix for CS0118: Ensure SmtpClient is used as a type, not a variable name
            using (var smtpClient = new SmtpClient())
            {
                // Fix for CS1955: Correctly access configuration values using indexer syntax
                smtpClient.Host = configuration["Email:Host"];
                smtpClient.Port = int.Parse(configuration["Email:Port"]);
                smtpClient.EnableSsl = bool.Parse(configuration["Email:EnableSsl"]);
                smtpClient.Credentials = new System.Net.NetworkCredential(
                    configuration["Email:Username"],
                    configuration["Email:Password"]
                );
                //var fromAddress = string.IsNullOrWhiteSpace(emailRequest.From)? configuration["Email:From"]:emailRequest.From;
                // Example email sending logic (optional, for completeness)
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(string.IsNullOrWhiteSpace(emailRequest.From) ? configuration["Email:From"] : emailRequest.From),
                    Subject = emailRequest.Subject,
                    Body = emailRequest.Body,
                    IsBodyHtml = emailRequest.IsHtml
                };

                mailMessage.To.Add(emailRequest.ToEmail);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }

        // Helper function to load and replace placeholders in email templates
        public string LoadEmailTemplate(string templatePath, Dictionary<string, string> placeholders)
        {
            var template = File.ReadAllText(templatePath);

            foreach (var placeholder in placeholders)
            {
                template = template.Replace($"{{{{{placeholder.Key}}}}}", placeholder.Value);
            }

            return template;
        }

    }
}
