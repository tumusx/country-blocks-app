using AsaasChallenge.Models;

namespace AsaasChallenge.Services;

public class CountryApiService : ICountryApiService
{
    private readonly HttpClient _httpClient;

    public CountryApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<IReadOnlyList<Country>> GetByRegionAsync(string region)
    {
        throw new NotImplementedException();
    }
}
