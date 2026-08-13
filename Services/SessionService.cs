namespace AsaasChallenge.Services;

public class SessionService : ISessionService
{
    private const string UsernameKey = "asaas.session.username";

    public async Task<string?> GetCurrentUserAsync()
    {
        try
        {
            return await SecureStorage.Default.GetAsync(UsernameKey);
        }
        catch
        {
            return null;
        }
    }

    public Task SaveUserAsync(string username) =>
        SecureStorage.Default.SetAsync(UsernameKey, username);

    public Task ClearAsync()
    {
        SecureStorage.Default.Remove(UsernameKey);
        return Task.CompletedTask;
    }
}
