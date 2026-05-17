using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels;

public partial class ProfileViewModel(INavigationService navigationService) : PageViewModel
{
    private readonly INavigationService _navigationService = navigationService;

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.NavigateBackAsync();
    }
}

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

public partial class ItemDetailViewModel(INavigationService navigationService) : PageViewModel
{
    private readonly INavigationService _navigationService = navigationService;

    public int ItemId { get; set; }

    public int RestaurantId { get; set; }

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.NavigateBackAsync();
    }
}
