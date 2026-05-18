using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels.Menus;

public partial class SettingsViewModel(INavigationService navigationService) : PageViewModel
{
    private readonly INavigationService _navigationService = navigationService;

    protected override void OnPageAppearing()
    {
        base.OnPageAppearing();
        Debug.WriteLine("⚙️ Settings page appearing!");
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.NavigateBackAsync();
    }
}