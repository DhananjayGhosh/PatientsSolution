using PatientAPI.Domain.DTOs;
using PatientAPI.Domain.Entities;

namespace PatientAPI.Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<string> AddPatientAsync(PersonalInfoDto patient);
        Task<bool> BookingAppoint(BookScheduleDto bookSchedule);
        Task<List<DoctorEntity>?> GetDoctorDetails();
    }
}
