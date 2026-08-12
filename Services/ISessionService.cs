namespace AsaasChallenge.Services;

public interface ISessionService
{
    Task<string?> GetCurrentUserAsync();
    Task SaveUserAsync(string username);
    Task ClearAsync();
}
