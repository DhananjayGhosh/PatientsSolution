namespace PatientAPI.Domain.Services
{
    public interface IAppLogger
    {
        void LogInformation(string message);
        void LogError(string message, Exception ex = null);
    }
}
