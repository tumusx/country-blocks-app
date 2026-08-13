namespace AsaasChallenge.Services;

public class AuthService : IAuthService
{
    public async Task<bool> LoginAsync(string username, string password)
    {
        await Task.Delay(600);
        return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
    }
}
