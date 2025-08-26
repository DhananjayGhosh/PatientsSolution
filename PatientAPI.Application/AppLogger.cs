using PatientAPI.Domain.Services;
using Serilog;

namespace PatientAPI.Application
{
    public class AppLogger<T> : IAppLogger
    where T : class
    {
        public void LogError(string message, Exception ex = null)
        {
            Log.Error(ex, "[{Type}] {Message}", typeof(T).Name, message);
        }

        public void LogInformation(string message)
        {
            Log.Information("[{Type}] {Message}", typeof(T).Name, message);
        }
    }
}
