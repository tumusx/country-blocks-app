using AsaasChallenge.Services;
using AsaasChallenge.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsaasChallenge.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly ISessionService _sessionService;

    [ObservableProperty]
    private string username = "Murillo";

    [ObservableProperty]
    private string appVersion = $"Versão {AppInfo.VersionString}";

    public HomeViewModel(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [RelayCommand]
    private Task GoToBlocksAsync() =>
        Shell.Current.GoToAsync(nameof(BlocksPage));

    [RelayCommand]
    private Task GoToCountrySearchAsync() =>
        Shell.Current.GoToAsync(nameof(CountrySearchPage));

    [RelayCommand]
    private async Task LoadAsync()
    {
        var user = await _sessionService.GetCurrentUserAsync();
        if (!string.IsNullOrWhiteSpace(user))
            Username = user;
    }
}
