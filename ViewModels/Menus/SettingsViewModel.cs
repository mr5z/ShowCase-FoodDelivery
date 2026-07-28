using CommunityToolkit.Mvvm.Input;
using Nkraft.MvvmEssentials;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;

namespace FoodDelivery.ViewModels.Menus;

public partial class SettingsViewModel(INavigationService navigationService) : PageViewModel
{
    private readonly INavigationService _navigationService = navigationService;
    
    [RelayCommand]
    private async Task ReloadPage()
    {
        await _navigationService.Absolute(withNavigation: false)
            .Push<MainHostViewModel>()
            .NavigateAsync();
    }
}
