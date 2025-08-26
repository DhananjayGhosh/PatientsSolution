using System.Net.Http.Json;

namespace PatientAPI.Infrastructure.Services
{
    public class ExternalHttpContextService
    {
        private readonly HttpClient _httpClient;

        public ExternalHttpContextService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        public async Task<dynamic> GetDataAsync()
        {
            return await _httpClient.GetFromJsonAsync<dynamic>("https://api.example.com/data");
        }
    }
}
