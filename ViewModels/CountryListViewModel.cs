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
    private async Task LoadAsync()
    {
        Title = "Buscador de países";
        LoadingLabel = "Buscando países...";
        IsLoading = true;
        try
        {
            var countries = await _apiService.GetByRegionAsync(Region);

            var savedIds = (await _storageService.GetSelectedAsync())
                .Select(c => c.Id)
                .ToHashSet();

            foreach (var country in countries)
                country.IsSelected = savedIds.Contains(country.Id);

            Countries.Clear();
            foreach (var country in countries)
                Countries.Add(country);

            System.Diagnostics.Debug.WriteLine($"[LoadAsync] OK — {countries.Count} países ({savedIds.Count} pré-selecionados)");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[LoadAsync] ERRO: {ex.GetType().Name} — {ex.Message}");
            LoadingLabel = $"Erro: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private void ToggleSelection(Country country)
    {
        if (country is null) return;
        country.IsSelected = !country.IsSelected;
    }

    [RelayCommand]
    private async Task FinishAsync()
    {
        var selected = Countries.Where(c => c.IsSelected).ToList();
        await _storageService.SaveSelectedAsync(selected);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private Task GoBackAsync() => Shell.Current.GoToAsync("..");
}
