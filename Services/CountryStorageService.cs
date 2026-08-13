using System.Text.Json;
using AsaasChallenge.Models;

namespace AsaasChallenge.Services;

public class CountryStorageService : ICountryStorageService
{
    private const string StorageKey = "selected_countries";

    public Task<IReadOnlyList<Country>> GetSelectedAsync()
    {
        var json = Preferences.Get(StorageKey, string.Empty);
        if (string.IsNullOrWhiteSpace(json))
            return Task.FromResult<IReadOnlyList<Country>>(Array.Empty<Country>());

        var items = JsonSerializer.Deserialize<List<StoredCountry>>(json)
                    ?? new List<StoredCountry>();

        var countries = items
            .Select(s => new Country { Id = s.Id, Name = s.Name, FlagUrl = s.FlagUrl, IsSelected = true })
            .ToList();

        return Task.FromResult<IReadOnlyList<Country>>(countries);
    }

    public Task SaveSelectedAsync(IEnumerable<Country> countries)
    {
        var items = countries
            .Select(c => new StoredCountry(c.Id, c.Name, c.FlagUrl))
            .ToList();

        var json = JsonSerializer.Serialize(items);
        Preferences.Set(StorageKey, json);
        return Task.CompletedTask;
    }

    public async Task RemoveAsync(Country country)
    {
        var current = await GetSelectedAsync();
        var updated = current.Where(c => c.Id != country.Id);
        await SaveSelectedAsync(updated);
    }

    public Task ClearAsync()
    {
        Preferences.Remove(StorageKey);
        return Task.CompletedTask;
    }

    private sealed record StoredCountry(string Id, string Name, string FlagUrl);
}
