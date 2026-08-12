using AsaasChallenge.Models;

namespace AsaasChallenge.Services;

public interface ICountryApiService
{
    Task<IReadOnlyList<Country>> GetByRegionAsync(string region);
}
