using PatientAPI.Domain.Services;

namespace PatientAPI.Application
{
    public class DoctorIdGenerator : IDoctorIdGenerator
    {
        public string GenerateId()
        {
            // Example: DOC-20250525-XYZ123
            var random = Path.GetRandomFileName().Replace(".", "").Substring(0, 6).ToUpper();
            return $"DOC{DateTime.Now:yyyyMMdd}{random}";
        }
    }
}
