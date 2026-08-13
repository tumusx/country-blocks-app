using AsaasChallenge.Services;
using AsaasChallenge.Views;

namespace AsaasChallenge;

public partial class AppShell : Shell
{
	private readonly ISessionService _sessionService;
	private bool _initialRouteChecked;

	public AppShell(ISessionService sessionService)
	{
		InitializeComponent();

		_sessionService = sessionService;

		Routing.RegisterRoute(nameof(BlocksPage), typeof(BlocksPage));
		Routing.RegisterRoute(nameof(CountrySearchPage), typeof(CountrySearchPage));
		Routing.RegisterRoute(nameof(CountryListPage), typeof(CountryListPage));
	}

	protected override async void OnNavigated(ShellNavigatedEventArgs args)
	{
		base.OnNavigated(args);

		if (_initialRouteChecked) return;
		_initialRouteChecked = true;

		var user = await _sessionService.GetCurrentUserAsync();
		if (!string.IsNullOrWhiteSpace(user))
		{
			await GoToAsync($"//{nameof(HomePage)}");
		}
	}
}
