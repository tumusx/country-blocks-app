using AsaasChallenge.ViewModels;

namespace AsaasChallenge.Views;

public partial class CountrySearchPage : ContentPage
{
    private readonly CountrySearchViewModel _viewModel;

    public CountrySearchPage(CountrySearchViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (_viewModel.LoadCommand.CanExecute(null))
            _viewModel.LoadCommand.Execute(null);
    }
}
