using AsaasChallenge.ViewModels;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;

namespace AsaasChallenge.Views;

public partial class BlocksPage : ContentPage
{
    private void ShowMakeUnicToast(String message)
    {
        var toast = Toast.Make(message, ToastDuration.Short, 14);
        toast.Show();
    }
    public BlocksPage(BlocksViewModel viewModel)
    {
        viewModel.MessageCommand = new RelayCommand<string>(
            message => ShowMakeUnicToast(message ?? string.Empty)
        );

        InitializeComponent();
        BindingContext = viewModel;
    }
}
