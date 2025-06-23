namespace PatientAPI.Infrastructure.DbEntity
{
    public partial class DoctorTable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string DoctorId { get; set; } = null!;
        public string DoctorName { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; } = null!;
    }
}
