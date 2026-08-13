using CommunityToolkit.Mvvm.ComponentModel;

namespace AsaasChallenge.Models;

public partial class Country : ObservableObject
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string FlagUrl { get; set; } = string.Empty;

    [ObservableProperty]
    private bool isSelected;
}
