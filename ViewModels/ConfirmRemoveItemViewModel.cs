using CommunityToolkit.Mvvm.Input;
using Nkraft.MvvmEssentials.Services;
using Nkraft.MvvmEssentials.ViewModels;
using MenuItem = FoodDelivery.Models.MenuItem;

namespace FoodDelivery.ViewModels;

public partial class ConfirmRemoveItemViewModel(IPopupService popupService) : PopupViewModel<bool>(popupService)
{
    public MenuItem Item { get; set; } = null!;
 
    [RelayCommand]
    private void Confirm()
    {
        Dismiss(true);
    }
 
    [RelayCommand]
    private void Cancel()
    {
        Dismiss(false);
    }
}