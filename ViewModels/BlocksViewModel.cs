using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsaasChallenge.ViewModels;

public partial class BlocksViewModel : ObservableObject
{
    [ObservableProperty]
    private string blockCountText = string.Empty;

    public ObservableCollection<int> Blocks { get; } = new();

    [RelayCommand]
    private void GenerateBlocks()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private Task GoBackAsync()
    {
        throw new NotImplementedException();
    }
}
