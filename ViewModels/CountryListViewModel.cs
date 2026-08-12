using System.Collections.ObjectModel;
using AsaasChallenge.Models;
using AsaasChallenge.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsaasChallenge.ViewModels;

[QueryProperty(nameof(Region), "region")]
public partial class CountryListViewModel : ObservableObject
{
    private readonly ICountryApiService _apiService;
    private readonly ICountryStorageService _storageService;

    [ObservableProperty]
    private string region = string.Empty;

    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private string loadingLabel = string.Empty;

    [ObservableProperty]
    private bool isLoading;

    public ObservableCollection<Country> Countries { get; } = new();

    public CountryListViewModel(ICountryApiService apiService, ICountryStorageService storageService)
    {
        _apiService = apiService;
        _storageService = storageService;
    }

    [RelayCommand]
    private Task LoadAsync()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private void ToggleSelection(Country country)
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private Task FinishAsync()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private Task GoBackAsync()
    {
        throw new NotImplementedException();
    }
}
