using Microsoft.AspNetCore.Mvc;
using PatientAPI.Domain.DTOs;
using PatientAPI.Domain.Services;

namespace PatientAPI.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patientService;
        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }
        [HttpPost("personalInfo")]
        public async Task<IActionResult> AddPatientAsync([FromBody] PersonalInfoDto patient)
        {
            if (patient == null)
            {
                return BadRequest("Patient information is required.");
            }
            try
            {
                string result = await patientService.AddPatientAsync(patient);
                if (!string.IsNullOrEmpty(result))
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the patient.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
                
            }
        }
        [HttpPost("bookAppoint")]
        public async Task<IActionResult> BookingAppoint([FromBody] BookScheduleDto bookSchedule)
        {
            if (bookSchedule == null)
            {
                return BadRequest("Booking schedule information is required.");
            }
            if(string.IsNullOrEmpty(bookSchedule.PatientId) || string.IsNullOrEmpty(bookSchedule.DoctorId))
            {
                return BadRequest("Invalid booking schedule information.");
            }
            try
            {
                bool result = await patientService.BookingAppoint(bookSchedule);
                if (result)
                {
                    return Ok("Appointment booked successfully.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while booking the appointment.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
