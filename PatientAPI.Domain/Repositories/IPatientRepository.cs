using PatientAPI.Domain.DTOs;

namespace PatientAPI.Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<string> AddPatientAsync(PersonalInfoDto patient);
        Task<bool> BookingAppoint(BookScheduleDto bookSchedule);
    }
}
