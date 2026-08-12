using AsaasChallenge.ViewModels;

namespace AsaasChallenge.Views;

public partial class CountryListPage : ContentPage
{
    private readonly CountryListViewModel _viewModel;

    public CountryListPage(CountryListViewModel viewModel)
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
