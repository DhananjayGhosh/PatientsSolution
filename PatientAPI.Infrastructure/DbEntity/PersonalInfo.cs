using System;
using System.Collections.Generic;

namespace PatientAPI.Infrastructure.DbEntity
{
    public partial class PersonalInfo
    {

        public string Id { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<AppointTable> AppointTableAutos { get; set; } = null!;
        public virtual ICollection<AppointTable> AppointTablePhoneNumberNavigations { get; set; } = null!;
    }
}
