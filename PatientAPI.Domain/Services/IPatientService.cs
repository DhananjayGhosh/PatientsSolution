using PatientAPI.Domain.DTOs;

namespace PatientAPI.Domain.Services
{
    public interface IPatientService
    {
        Task<string> AddPatientAsync(PersonalInfoDto patient);
        Task<bool> BookingAppoint(BookScheduleDto bookSchedule);
    }
}
