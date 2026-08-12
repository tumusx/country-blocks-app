using AsaasChallenge.ViewModels;

namespace AsaasChallenge.Views;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel _viewModel;

    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            if (_viewModel.LoadCommand.CanExecute(null))
                _viewModel.LoadCommand.Execute(null);
        }
        catch (NotImplementedException) { }
    }
}
