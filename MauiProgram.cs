using AsaasChallenge.Services;
using AsaasChallenge.ViewModels;
using AsaasChallenge.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace AsaasChallenge;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		// Remove platform-default underline on Entry (Android Material) and border (iOS)
		EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
		{
#if ANDROID
			handler.PlatformView.BackgroundTintList =
				Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#elif IOS || MACCATALYST
			handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
		});

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// HTTP client for restcountries.com (v5)
		builder.Services.AddHttpClient<ICountryApiService, CountryApiService>(client =>
		{
			client.BaseAddress = new Uri("https://api.restcountries.com/");
			client.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue(
					"Bearer", Secrets.RestCountriesApiKey);
		});

		// Services
		builder.Services.AddSingleton<IAuthService, AuthService>();
		builder.Services.AddSingleton<ISessionService, SessionService>();
		builder.Services.AddSingleton<ICountryStorageService, CountryStorageService>();

		// ViewModels
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<HomeViewModel>();
		builder.Services.AddTransient<BlocksViewModel>();
		builder.Services.AddTransient<CountrySearchViewModel>();
		builder.Services.AddTransient<CountryListViewModel>();

		// Views
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<HomePage>();
		builder.Services.AddTransient<BlocksPage>();
		builder.Services.AddTransient<CountrySearchPage>();
		builder.Services.AddTransient<CountryListPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
