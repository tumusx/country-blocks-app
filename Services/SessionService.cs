namespace AsaasChallenge.Services;

public class SessionService : ISessionService
{
    public Task<string?> GetCurrentUserAsync() => throw new NotImplementedException();
    public Task SaveUserAsync(string username) => throw new NotImplementedException();
    public Task ClearAsync() => throw new NotImplementedException();
}
