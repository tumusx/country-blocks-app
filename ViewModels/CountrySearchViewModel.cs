using System.Collections.ObjectModel;
using AsaasChallenge.Models;
using AsaasChallenge.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AsaasChallenge.Views;                                                                                   

namespace AsaasChallenge.ViewModels;

public partial class CountrySearchViewModel : ObservableObject
{
    private readonly ICountryStorageService _storageService;

    public ObservableCollection<Country> SelectedCountries { get; } = new();

    public CountrySearchViewModel(ICountryStorageService storageService)
    {
        _storageService = storageService;
    }

    [RelayCommand]
    private async Task LoadAsync()
    {
        var saved = await _storageService.GetSelectedAsync();

        SelectedCountries.Clear();
        foreach (var country in saved.OrderBy(c => c.Name))
            SelectedCountries.Add(country);
    }

    [RelayCommand]
    private Task SearchNorthAmericaAsync() => Shell.Current.GoToAsync($"{nameof(Views.CountryListPage)}?region=north america");

    [RelayCommand]
    private Task SearchSouthAmericaAsync() => Shell.Current.GoToAsync($"{nameof(Views.CountryListPage)}?region=south america");

    [RelayCommand]
    private async Task RemoveCountryAsync(Country country)
    {
        if (country is null) return;

        await _storageService.RemoveAsync(country);
        SelectedCountries.Remove(country);
    }

    [RelayCommand]
    private Task GoBackAsync() => Shell.Current.GoToAsync("..");
}
