using AsaasChallenge.Services;

namespace AsaasChallenge;

public partial class App : Application
{
	private readonly ISessionService _sessionService;

	public App(ISessionService sessionService)
	{
		InitializeComponent();
		_sessionService = sessionService;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell(_sessionService));
	}
}
