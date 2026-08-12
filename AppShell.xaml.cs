using AsaasChallenge.Views;

namespace AsaasChallenge;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
		Routing.RegisterRoute(nameof(BlocksPage), typeof(BlocksPage));
		Routing.RegisterRoute(nameof(CountrySearchPage), typeof(CountrySearchPage));
		Routing.RegisterRoute(nameof(CountryListPage), typeof(CountryListPage));
	}
}
