using AsaasChallenge.Models;

namespace AsaasChallenge.Services;

public interface ICountryStorageService
{
    Task<IReadOnlyList<Country>> GetSelectedAsync();
    Task SaveSelectedAsync(IEnumerable<Country> countries);
    Task RemoveAsync(Country country);
    Task ClearAsync();
}
