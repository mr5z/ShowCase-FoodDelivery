using CommunityToolkit.Mvvm.Input;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;
using Nkraft.MvvmEssentials.Extensions;

namespace FoodDelivery.ViewModels;

public partial class MenuViewModel(INavigationService navigationService) : FlyoutMenuViewModel
{
    private readonly INavigationService _navigationService = navigationService;

    [RelayCommand]
    private async Task NavigateToHome()
    {
        await _navigationService.NavigateAsync<MainTabbedViewModel>();
        IsPresented = false;
    }

    [RelayCommand]
    private async Task NavigateToOrders()
    {
        await _navigationService.NavigateAsync<OrdersViewModel>();
        IsPresented = false;
    }

    [RelayCommand]
    private async Task NavigateToProfile()
    {
        await _navigationService.NavigateAsync<ProfileViewModel>();
        IsPresented = false;
    }

    [RelayCommand]
    private async Task NavigateToSettings()
    {
        await _navigationService.NavigateAsync<SettingsViewModel>();
        IsPresented = false;
    }
}
