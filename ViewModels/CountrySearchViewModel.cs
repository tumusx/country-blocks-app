using System.Collections.ObjectModel;
using AsaasChallenge.Models;
using AsaasChallenge.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
    private Task LoadAsync()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private Task SearchNorthAmericaAsync()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private Task SearchSouthAmericaAsync()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private Task RemoveCountryAsync(Country country)
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private Task GoBackAsync()
    {
        throw new NotImplementedException();
    }
}
