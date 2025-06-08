using PatientAPI.Domain.DTOs;
using PatientAPI.Domain.Repositories;
using PatientAPI.Domain.Services;

namespace PatientAPI.Application
{
    public class PatientService : IPatientService
    {
        private readonly IPatientIdGenerator _patientIdGenerator;
        private readonly IPatientRepository _patientRepository;
        private readonly IEmailService _email;

        public PatientService(IPatientIdGenerator patientId, IPatientRepository patient, IEmailService email)
        {
            _patientIdGenerator = patientId;
            _patientRepository = patient;
            _email = email;
        }
        public async Task<string> AddPatientAsync(PersonalInfoDto patient)
        {
            string res = "";
            patient.PatientId = _patientIdGenerator.GenerateId();
            res =  await _patientRepository.AddPatientAsync(patient);
            EmailRequestDto emailRequest = new EmailRequestDto() 
            {
                ToEmail = patient.Email,
                Subject = "Registration Successful",
                Body = $"Dear {patient.FirstName},\n\nYour registration is successful.",
                IsHtml = false
            };
            if (!string.IsNullOrEmpty(res)) 
            {
                await _email.SendEmailAsync(emailRequest);
                return res;
            }
            return res;
        }
        public async Task<bool> BookingAppoint(BookScheduleDto bookSchedule)
        {

            return await _patientRepository.BookingAppoint(bookSchedule);
        }
    }
}
