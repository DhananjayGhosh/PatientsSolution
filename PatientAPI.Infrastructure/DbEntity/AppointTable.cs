namespace PatientAPI.Infrastructure.DbEntity
{
    public partial class AppointTable
    {
        public int Id { get; set; }
        public string AutoId { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Department { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorId { get; set; }
        public DateTime? AppointDate { get; set; }
        public string? YourProblem { get; set; }
        public string? Remarks { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual PersonalInfo Auto { get; set; } = null!;
        public virtual PersonalInfo PhoneNumberNavigation { get; set; } = null!;
    }
}
