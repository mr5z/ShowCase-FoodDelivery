using CommunityToolkit.Mvvm.Input;
using FoodDelivery.ViewModels.Menus;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels;

public partial class MenuViewModel(INavigationService navigationService) : FlyoutMenuViewModel
{
    private readonly INavigationService _navigationService = navigationService;

    [RelayCommand]
    private async Task NavigateToHome()
    {
        await ReplaceDetailAsync<MainTabbedViewModel>(_navigationService);
        IsPresented = false;
    }

    [RelayCommand]
    private async Task NavigateToOrders()
    {
        await ReplaceDetailAsync<OrdersViewModel>(_navigationService);
        IsPresented = false;
    }

    [RelayCommand]
    private async Task NavigateToProfile()
    {
        await ReplaceDetailAsync<ProfileViewModel>(_navigationService);
        IsPresented = false;
    }

    [RelayCommand]
    private async Task NavigateToSettings()
    {
        await ReplaceDetailAsync<SettingsViewModel>(_navigationService);
        IsPresented = false;
    }
}
