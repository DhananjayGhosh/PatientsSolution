using PatientAPI.Application.Cache;
using PatientAPI.Domain.DTOs;
using PatientAPI.Domain.Entities;
using PatientAPI.Domain.Repositories;
using PatientAPI.Domain.Services; 

namespace PatientAPI.Application
{
    public class PatientService : IPatientService
    {
        private readonly IPatientIdGenerator _patientIdGenerator;
        private readonly IPatientRepository _patientRepository;
        private readonly IEmailService _email;
        private readonly ICacheService _cache;
        string firstName = string.Empty;
        string email = string.Empty;
        public PatientService(IPatientIdGenerator patientId, IPatientRepository patient, IEmailService email, ICacheService cache)

        {
            _patientIdGenerator = patientId;
            _patientRepository = patient;
            _email = email;
            _cache = cache;
        }
        
        public async Task<string> AddPatientAsync(PersonalInfoDto patient)
        {
            patient.PatientId = _patientIdGenerator.GenerateId();
            string res =  await _patientRepository.AddPatientAsync(patient);
            if(!string.IsNullOrEmpty(res))
            {
                firstName = patient.FirstName;
                email = patient.Email;
            }
            return res;
        }
        public async Task<bool> BookingAppoint(BookScheduleDto bookSchedule)
        {
            var placeholder = new Dictionary<string, string>();
            placeholder.Add("FirstName", firstName);
            placeholder.Add("PatientId", bookSchedule.PatientId);
            placeholder.Add("PhoneNumber", bookSchedule.PhoneNumber);
            placeholder.Add("DoctorName",bookSchedule.DoctorName);
            placeholder.Add("Department", bookSchedule.Department);
            placeholder.Add("AppointDate",(bookSchedule.AppointDate).ToString());
            placeholder.Add("YourProblem", bookSchedule.YourProblem);
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "RegistrationTemplate.html");
            string htmlBody = _email.LoadEmailTemplate(templatePath, placeholder);

            var emailRequest = new EmailRequestDto
            {
                ToEmail = email,
                Subject = "Your CarePlus Registration",
                Body = htmlBody,
                IsHtml = true
            };

            if(await _patientRepository.BookingAppoint(bookSchedule))
            {
                await _email.SendEmailAsync(emailRequest);
                firstName = null!;
                email = null!;
                return true;
            }
            return false;
        }

        public async Task<List<DoctorEntity>?> GetDoctorDetails()
        {
            var cacheKey = CacheKey.GetDoctors;
            var cachedDoctors = await _cache.GetAsync<List<DoctorEntity>>(cacheKey);
            if (cachedDoctors != null)
                return cachedDoctors;
            var doctorList = await _patientRepository.GetDoctorDetails();
            await _cache.SetAsync(cacheKey, doctorList, TimeSpan.FromMinutes(10));
            return doctorList;
        }
    }
}
