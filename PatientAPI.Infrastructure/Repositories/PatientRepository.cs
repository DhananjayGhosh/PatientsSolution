using Microsoft.EntityFrameworkCore;
using PatientAPI.Domain.DTOs;
using PatientAPI.Domain.Repositories;
using PatientAPI.Infrastructure.AutoMapper;
using PatientAPI.Infrastructure.DbEntity;

namespace PatientAPI.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientAPIDbContext context;

        public PatientRepository(PatientAPIDbContext context)
        {
            this.context = context;
        }
        public async Task<string> AddPatientAsync(PersonalInfoDto patient)
        {

            PersonalInfo personalInfo = Automapper.MapToPersonalInfo(patient);
                var existingPatient = await context.PersonalInfos.AsNoTracking()
                    .FirstOrDefaultAsync(p => p.PhoneNumber == personalInfo.PhoneNumber);
                if (existingPatient != null)
                {
                    return existingPatient.PhoneNumber;
                }
            
            await context.PersonalInfos.AddAsync(personalInfo);
            var records = await context.SaveChangesAsync();
            if (records > 0)
            {
                return personalInfo.Id; 
            }
            return string.Empty;
        }
        public async Task<bool> BookingAppoint(BookScheduleDto bookSchedule)
        {
            AppointTable appointTable = Automapper.MapToBookSchedule(bookSchedule);
            await context.AppointTables.AddAsync(appointTable);
            var records = await context.SaveChangesAsync();
            if(records>0)
            {
                return true;
            }
            return false;
        }
    }
}
