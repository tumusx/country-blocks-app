using AsaasChallenge.Services;
using AsaasChallenge.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsaasChallenge.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IAuthService _authService;
    private readonly ISessionService _sessionService;

    [ObservableProperty]
    private string username = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string? errorMessage;

    public LoginViewModel(IAuthService authService, ISessionService sessionService)
    {
        _authService = authService;
        _sessionService = sessionService;
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (IsBusy) return;

        ErrorMessage = null;

        var user = Username?.Trim() ?? string.Empty;
        var pass = Password ?? string.Empty;

        if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
        {
            ErrorMessage = "Preencha usuário e senha";
            return;
        }

        try
        {
            IsBusy = true;

            var success = await _authService.LoginAsync(user, pass);
            if (!success)
            {
                ErrorMessage = "Usuário ou senha inválidos";
                return;
            }

            await _sessionService.SaveUserAsync(user);

            Password = string.Empty;
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Erro ao entrar: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
}
