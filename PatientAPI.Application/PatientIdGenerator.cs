using PatientAPI.Domain.Services;

namespace PatientAPI.Application
{
    public class PatientIdGenerator : IPatientIdGenerator
    {
        public string GenerateId()
        {
            // Example: PAT-20250525-XYZ123
            var random = Path.GetRandomFileName().Replace(".", "").Substring(0, 6).ToUpper();
            return $"PAT{DateTime.Now:yyyyMMdd}{random}";
        }
    }
}
