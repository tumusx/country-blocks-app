using System.Diagnostics;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using AsaasChallenge.Models;

namespace AsaasChallenge.Services;

public class CountryApiService : ICountryApiService
{
    private readonly HttpClient _httpClient;

    public CountryApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<Country>> GetByRegionAsync(string region)
    {
        var subregion = ToTitleCase(region);
        var endpoint = $"countries/v5?subregion={Uri.EscapeDataString(subregion)}&fields=names,codes,flag&limit=100";

        Debug.WriteLine($"[CountryApi] GET {_httpClient.BaseAddress}{endpoint}");

        var response = await _httpClient.GetFromJsonAsync<ResponseDto>(endpoint);
        var objects = response?.Data?.Objects ?? new List<CountryDto>();

        var countries = objects
            .Select(d => new Country
            {
                Id = d.Codes?.Alpha3 ?? string.Empty,
                Name = d.Names?.Common ?? string.Empty,
                FlagUrl = d.Flag?.UrlPng ?? string.Empty
            })
            .Where(c => !string.IsNullOrEmpty(c.Name))
            .OrderBy(c => c.Name)
            .ToList();

        Debug.WriteLine($"[CountryApi] Received {countries.Count} countries");

        return countries;
    }

    private static string ToTitleCase(string value)
        => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value.ToLowerInvariant());

    private sealed record ResponseDto(
        [property: JsonPropertyName("data")] DataDto? Data);

    private sealed record DataDto(
        [property: JsonPropertyName("objects")] List<CountryDto>? Objects);

    private sealed record CountryDto(
        [property: JsonPropertyName("names")] NamesDto? Names,
        [property: JsonPropertyName("codes")] CodesDto? Codes,
        [property: JsonPropertyName("flag")] FlagDto? Flag);

    private sealed record NamesDto(
        [property: JsonPropertyName("common")] string Common);

    private sealed record CodesDto(
        [property: JsonPropertyName("alpha_3")] string Alpha3);

    private sealed record FlagDto(
        [property: JsonPropertyName("url_png")] string UrlPng);
}
