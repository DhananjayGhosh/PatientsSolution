using PatientAPI.Domain.DTOs;
using PatientAPI.Domain.Entities;

namespace PatientAPI.Domain.Services
{
    public interface IPatientService
    {
        Task<string> AddPatientAsync(PersonalInfoDto patient);
        Task<bool> BookingAppoint(BookScheduleDto bookSchedule);
        Task<List<DoctorEntity>?> GetDoctorDetails();
    }
}
