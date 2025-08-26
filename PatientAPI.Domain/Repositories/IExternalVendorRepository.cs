namespace PatientAPI.Domain.Repositories
{
    public interface IExternalVendorRepository
    {
        Task<dynamic> GetExternalDataAsync();
    }
}
