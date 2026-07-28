using CommunityToolkit.Mvvm.Input;
using Nkraft.MvvmEssentials.Attributes;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;
using MenuItem = FoodDelivery.Models.MenuItem;

namespace FoodDelivery.ViewModels;

public partial class ConfirmRemoveItemViewModel(IPopupService popupService) : PopupViewModel<bool>(popupService)
{
    [NavigationParameter]
    public MenuItem Item { get; set; } = null!;
 
    [RelayCommand]
    private async Task Confirm()
    {
        await Dismiss(true);
    }
 
    [RelayCommand]
    private async Task Cancel()
    {
        await Dismiss(false);
    }
}