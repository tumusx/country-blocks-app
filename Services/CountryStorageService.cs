using AsaasChallenge.Models;

namespace AsaasChallenge.Services;

public class CountryStorageService : ICountryStorageService
{
    public Task<IReadOnlyList<Country>> GetSelectedAsync() => throw new NotImplementedException();
    public Task SaveSelectedAsync(IEnumerable<Country> countries) => throw new NotImplementedException();
    public Task RemoveAsync(Country country) => throw new NotImplementedException();
    public Task ClearAsync() => throw new NotImplementedException();
}
