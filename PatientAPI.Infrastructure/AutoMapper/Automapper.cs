using PatientAPI.Domain.DTOs;
using PatientAPI.Infrastructure.DbEntity;

namespace PatientAPI.Infrastructure.AutoMapper
{
    public static class Automapper
    {
        public static PersonalInfo MapToPersonalInfo(PersonalInfoDto personalInfoDto)
        {
            PersonalInfo personalInfo = new PersonalInfo()
            {
                Id = personalInfoDto.PatientId,
                FirstName = personalInfoDto.FirstName,
                LastName = personalInfoDto.LastName,
                Age = personalInfoDto.Age,
                Gender = personalInfoDto.Gender,
                Address = personalInfoDto.Address,
                Country = personalInfoDto.Country,
                State = personalInfoDto.State,
                City = personalInfoDto.City,
                PhoneNumber = personalInfoDto.Phone,
                Email = personalInfoDto.Email,
                CreatedOn = DateTime.UtcNow // Assuming CreatedOn is set to the current time
            };
            return personalInfo;
        }
        public static AppointTable MapToBookSchedule(BookScheduleDto bookScheduleDto)
        {
            AppointTable bookSchedule = new AppointTable()
            {
                AutoId = bookScheduleDto.PatientId,
                PhoneNumber = bookScheduleDto.PhoneNumber,
                Department = bookScheduleDto.Department,
                DoctorName = bookScheduleDto.DoctorName,
                DoctorId = bookScheduleDto.DoctorId,
                AppointDate = bookScheduleDto.AppointDate,
                YourProblem = bookScheduleDto.YourProblem,
                Remarks = bookScheduleDto.Remarks,
                CreatedOn = DateTime.UtcNow, // Assuming CreatedOn is set to the current time
                UpdatedOn = DateTime.UtcNow // Assuming UpdatedOn is set to the current time
            };
            return bookSchedule;
        }
    }
}
