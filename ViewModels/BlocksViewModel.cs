using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsaasChallenge.ViewModels;

public partial class BlocksViewModel : ObservableObject
{
    private const int DefaultCount = 5;
    private const int MaxCount = 25;

    [ObservableProperty]
    private string blockCountText = DefaultCount.ToString();

    public ObservableCollection<int> Blocks { get; } = new();

    public IRelayCommand<string>? MessageCommand { get; set; }

    public BlocksViewModel()
    {
        Regenerate(DefaultCount);
    }

    partial void OnBlockCountTextChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            Blocks.Clear();
            return;
        }

        if (!int.TryParse(value, out var count) || count <= 0)
        {
            Blocks.Clear();
            return;
        }
        
        if (count > MaxCount)
        {
            Blocks.Clear();
            MessageCommand?.Execute($"O limite máximo de blocos a serem gerados é de {MaxCount}");
            return;
        }

        Regenerate(count);
    }

    [RelayCommand]
    private void GenerateBlocks()
    {
        if (string.IsNullOrWhiteSpace(BlockCountText)
            || !int.TryParse(BlockCountText, out var count)
            || count <= 0)
        {
            Blocks.Clear();
            MessageCommand?.Execute("Informe um número válido");
            return;
        }

        OnBlockCountTextChanged(BlockCountText);
    }
    
    [RelayCommand]
    private Task GoBackAsync() => Shell.Current.GoToAsync("..");

    private void Regenerate(int count)
    {
        Blocks.Clear();
        for (var i = 1; i <= count; i++)
            Blocks.Add(i);
    }
}
