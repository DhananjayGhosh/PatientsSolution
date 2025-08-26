using PatientAPI.Domain.Repositories;
using PatientAPI.Infrastructure.Services;

namespace PatientAPI.Infrastructure.Repositories
{
    
    public class ExternalVendorRepository : IExternalVendorRepository
    {
        private readonly ExternalHttpContextService _externalHttp;

        public ExternalVendorRepository(ExternalHttpContextService externalHttp)
        {
            _externalHttp = externalHttp;
        }
        public async Task<dynamic> GetExternalDataAsync() 
        {
            return await _externalHttp.GetDataAsync();
        }
    }
}
