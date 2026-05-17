using CommunityToolkit.Mvvm.Input;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels;

public partial class ProfileViewModel : PageViewModel
{
    private readonly INavigationService _navigationService;

    public ProfileViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    protected override void OnPageAppearing()
    {
        base.OnPageAppearing();
        System.Diagnostics.Debug.WriteLine("👤 Profile page appearing!");
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.NavigateBackAsync();
    }
}

public partial class SettingsViewModel : PageViewModel
{
    private readonly INavigationService _navigationService;

    public SettingsViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    protected override void OnPageAppearing()
    {
        base.OnPageAppearing();
        System.Diagnostics.Debug.WriteLine("⚙️ Settings page appearing!");
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

    protected override void OnPageAppearing()
    {
        base.OnPageAppearing();
        System.Diagnostics.Debug.WriteLine($"📄 Item detail appearing for item {ItemId}!");
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.NavigateBackAsync();
    }
}
