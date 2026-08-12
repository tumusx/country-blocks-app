using AsaasChallenge.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsaasChallenge.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly ISessionService _sessionService;

    [ObservableProperty]
    private string username = "Usuário";

    [ObservableProperty]
    private string appVersion = $"Versão {AppInfo.VersionString}";

    public HomeViewModel(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [RelayCommand]
    private Task GoToBlocksAsync()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private Task GoToCountrySearchAsync()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private Task LoadAsync()
    {
        throw new NotImplementedException();
    }
}
