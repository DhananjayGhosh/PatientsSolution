namespace PatientAPI.Domain.DTOs
{
    public class BookScheduleDto
    {
        public string PatientId { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string DoctorName { get; set; } = null!;
        public string DoctorId { get; set; } = null!;
        public DateTime AppointDate { get; set; }
        public string YourProblem { get; set; } = null!;
        public string Remarks { get; set; } = null!;

    }
}
