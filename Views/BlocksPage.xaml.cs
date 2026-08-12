using AsaasChallenge.ViewModels;

namespace AsaasChallenge.Views;

public partial class BlocksPage : ContentPage
{
    public BlocksPage(BlocksViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
